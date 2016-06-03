// jshint strict: false

// Include the libraries.
var amdOptimize = require("amd-optimize");
var del = require("del");
var gulp = require("gulp");
var fs = require("fs");
var runSequence = require('run-sequence');

var plugins = require("gulp-load-plugins")({
    pattern: ["gulp[\-\.]*"],
    replaceString: /\bgulp[\-\.]/
});

// Include custom configuration.
var configs = {
    cssnano: require("./cssnano-config.json"),
    favicon: require("./favicon-config.json"),
    svgSprite: require("./svgsprite-config.json")
};

// Store the tasks as names, so that they can be easily
// referenced from the individual and default tasks.
var tasks = {
    build: "build",
    clean: "clean",
    css: "css",
    "default": "default",
    favicon: "favicon",
    faviconTemplate: "favicon-template",
    js: {
        build: "js_build",
        staticAnalysis: "js_static_analysis",
        style: "js_style"
    },
    lint: "lint",
    resize: "resize",
    sass: {
        build: "sass",
        lint: "sass_lint"
    },
    sprite: "sprite",
    svg: "svg",
    watch: "watch"
};

var files = {
    gulp: "gulpfile.js",
    js: "src/js/**/*.js",
    sass: "src/sass/**/*.scss",
    sassGenerated: "src/sass/generated/*.scss"
};

// Lints all local JavaScript files, including this!
gulp.task(tasks.js.staticAnalysis, function () {
    return gulp
        .src([
            files.gulp,
            files.js
        ])
        .pipe(plugins.jshint())
        .pipe(plugins.jshint.reporter("default"))
        .pipe(plugins.jshint.reporter("fail"));
});

gulp.task(tasks.js.style, function () {
    return gulp
        .src([
            files.gulp,
            files.js
        ])
        .pipe(plugins.jscs())
        .pipe(plugins.jscs.reporter());
});

gulp.task(tasks.sass.lint, function () {
    return gulp
        .src([
            files.sass,
            "!" + files.sassGenerated,
            "!src/sass/utils/_svg-template.scss",
            "!src/sass/vendor/**/*.scss"
        ])
        .pipe(plugins.sassLint())
        .pipe(plugins.sassLint.format())
        .pipe(plugins.sassLint.failOnError());
});

// Cleans build artefacts.
gulp.task(tasks.clean, function () {
    return del([
        "src/sass/**/*.css",
        "src/sass/**/*.min.*",
        files.sassGenerated
    ]);
});

// TODO Delete all smaller images, remove @2x from the names, then resize.
gulp.task(tasks.resize, function () {
    gulp
        .src("src/images/**/*.png")
        .pipe(plugins.imageResize({
            width: "50%",
            height: "50%",
            crop: false,
            upscale: false
        }))
        .pipe(plugins.rename(function(path) {
            path.basename += "@half";
        }))
        .pipe(gulp.dest("images/"));
});

// Spritesheet generation.
gulp.task(tasks.sprite, function () {
    var spriteData = gulp
        .src("src/images/**/*.png")
        .pipe(plugins.spritesmith({
            retinaSrcFilter: "src/images/**/*@2x.png",
            imgName: "images/sprite-generated.png",
            padding: 5,
            retinaImgName: "images/sprite-generated@2x.png",
            cssName: "src/sass/generated/_sprite.scss",
            cssVarMap: function (sprite) {
                sprite.name = "sprite_" + sprite.name;
            }
        }));

    spriteData.img.pipe(gulp.dest("."));
    spriteData.css.pipe(gulp.dest("."));
});

gulp.task(tasks.svg, function () {
    return gulp
        .src("src/images/**/*.svg")
        .pipe(plugins.svgSprite(configs.svgSprite))
        .pipe(gulp.dest("."));
});

gulp.task(tasks.sass.build, [tasks.sprite, tasks.svg], function () {
    gulp
        .src(files.sass)
        .pipe(plugins.sourcemaps.init())
        .pipe(plugins.sass().on("error", plugins.sass.logError))
        .pipe(gulp.dest("src/sass/"))
        .pipe(plugins.sourcemaps.write())
        //.pipe(plugins.cssnano(configs.cssnano))
        .pipe(gulp.dest("css"));
});

// CSS tasks that forces dependencies to be run sequentially.
// Parallelisation is playing havoc, as the spritesheets
// must be generated first, as their SASS outputs
// are required for the SASS build!
gulp.task(tasks.css, [tasks.sprite, tasks.svg], function () {
    runSequence(tasks.sprite, tasks.svg, tasks.sass.build);
});

// Require JS build.
gulp.task(tasks.js.build, function () {
    return gulp
        .src(files.js)
        .pipe(amdOptimize("app", {
            name: "app",
            configFile: "src/js/app.js",
            baseUrl: "src/js"
        }))
        .pipe(plugins.concat("vitality-boilerplate.js"))
        .pipe(plugins.uglify())
        .pipe(gulp.dest("js"));
});

// A group of all lint tasks.
gulp.task(tasks.lint, [
    //jsStaticAnalysis,
    //jsStyle,
    tasks.sass.lint
]);

// A group of all build tasks.
gulp.task(tasks.build, [
    tasks.css,
    tasks.js.build
]);

// Default task that runs all the tasks.
gulp.task(tasks.default, [
    tasks.clean,
    tasks.lint,
    tasks.build
]);

// Favicon tasks, deliberately separate to the main build.
gulp.task(tasks.favicon, function () {
    plugins.realFavicon.generateFavicon(configs.favicon);
});

// Fill in the standard favicon HTML template.
gulp.task(tasks.faviconTemplate, function () {
    return gulp
        .src("src/favicon-template.html")
        .pipe(plugins.realFavicon.injectFaviconMarkups
            (JSON.parse(fs.readFileSync("favicon-data.json")).favicon.html_code))
        .pipe(gulp.dest("."));
});

// Default watch task that continuously compiles pre-processor code.
gulp.task(tasks.watch, function () {
    gulp.watch(files.sass, [
        tasks.clean,
        tasks.build
    ]);
});
