// jshint strict: false

var amdOptimize = require("amd-optimize");
var browserSync = require("browser-sync");
var buffer = require("vinyl-buffer");
var del = require("del");
var gulp = require("gulp");
var fs = require("fs");
var runSequence = require("run-sequence");

var plugins = require("gulp-load-plugins")({
    pattern: ["gulp[\-\.]*"],
    replaceString: /\bgulp[\-\.]/
});

var configs = {
    cssnano: require("./config/cssnano-config.json"),
    favicon: require("./config/favicon-config.json"),
    imageResize: require("./config/image-resize-config.json"),
    svgSprite: require("./config/svgsprite-config.json")
};

var tasks = {
    clean: "clean",
    "default": "default",
    favicon: {
        build: "favicon:build",
        template: "favicon:template"
    },
    help: "help",
    images: "images",
    js: {
        build: "js",
        lint: "js:lint"
    },
    resize: "resize",
    sass: {
        build: "sass",
        lint: "sass:lint",
        spritesheet: {
            png: "sass:spritesheet-png",
            svg: "sass:spritesheet-svg",
        }
    },
    serve: "serve",
    watch: "watch"
};

var paths = {
    base: ".",
    css: "css",
    favicon: {
        template: "src/favicon-template.html"
    },
    gulp: "gulpfile.js",
    html: [
        "**/*.html",
        "!bower_components/",
        "!node_modules/"
    ],
    img: {
        examples: {
            dest: "img/examples",
            src: "src/img/examples/**/*"
        },
        spritesheets: {
            // TODO move to "img/spritesheets"
            dest: "css",
            pngSrc: "src/images/**/*.png",
            svgSrc: "src/images/**/*.svg"
        }
    },
    js: {
        dest: "js",
        filename: "vitality-boilerplate.js",
        src: [
            "src/js/**/*.js",
            "!src/js/modernizr-custom.min.js",
            "!src/js/require.js",
            "!src/js/libraries/**/*.js",
            "!src/js/vendor/**/*.js"
        ],
        srcAll: "src/js/**/*.js"
    },
    sass: {
        generated: "src/sass/generated",
        src: [
            "src/sass/**/*.scss",
            "!src/sass/generated/*.scss",
            "!src/sass/utils/_svg-template.scss",
            "!src/sass/vendor/**/*.scss"
        ],
        srcAll: "src/sass/**/*.scss"
    },
    temp: "tmp"
};

gulp.task(tasks.help, plugins.taskListing);

gulp.task(tasks.js.lint, function () {
    return gulp
        .src([paths.gulp].concat(paths.js.src))
        .pipe(plugins.changed(paths.temp))
        .pipe(gulp.dest(paths.temp))
        .pipe(plugins.jshint())
        .pipe(plugins.jscs())
        .pipe(plugins.jscsStylish.combineWithHintResults())
        .pipe(plugins.jshint.reporter("jshint-stylish"));
});

gulp.task(tasks.sass.lint, function () {
    return gulp
        .src(paths.sass.src)
        .pipe(plugins.changed(paths.temp))
        .pipe(gulp.dest(paths.temp))
        .pipe(plugins.sassLint())
        .pipe(plugins.sassLint.format())
        .pipe(plugins.sassLint.failOnError());
});

gulp.task(tasks.clean, function () {
    return del([
        paths.css,
        paths.img.examples.dest,
        paths.img.spritesheets.dest,
        paths.js.dest + "/" + paths.js.filename,
        paths.sass.generated,
        paths.temp
    ]);
});

gulp.task(tasks.images, function() {
    return gulp
        .src(paths.img.examples.src)
        .pipe(plugins.changed(paths.img.examples.src))
        .pipe(plugins.imagemin())
        .pipe(gulp.dest(paths.img.examples.src));
});

gulp.task(tasks.sass.spritesheet.png, function () {
    var spriteData = gulp
        .src(paths.img.spritesheets.pngSrc)
        .pipe(plugins.changed(paths.temp))
        .pipe(gulp.dest(paths.temp))
        .pipe(plugins.spritesmith({
            retinaSrcFilter: "tmp/**/*@2x.png",
            imgName: "sprite-generated.png",
            retinaImgName: "sprite-generated@2x.png",
            cssName: "_sprite.scss",
            padding: 5,
            cssVarMap: function (sprite) {
                sprite.name = "sprite_" + sprite.name;
            }
        }));

    spriteData.img
        .pipe(buffer())
        .pipe(plugins.imagemin())
        .pipe(gulp.dest(paths.img.spritesheets.dest));

    spriteData.css.pipe(gulp.dest(paths.sass.generated));
});

gulp.task(tasks.sass.spritesheet.svg, function () {
    return gulp
        .src(paths.img.spritesheets.svgSrc)
        .pipe(plugins.changed(paths.temp))
        .pipe(gulp.dest(paths.temp))
        .pipe(plugins.svgSprite(configs.svgSprite))
        .pipe(gulp.dest(paths.base));
        //.pipe(plugins.wait(1000));
});

gulp.task(tasks.sass.build, [
    tasks.sass.lint,
    //tasks.sass.spritesheet.png,
    //tasks.sass.spritesheet.svg
], function () {
    // TODO Enable source maps and use auto-prefixer.
    return gulp
        .src(paths.sass.srcAll)
        .pipe(plugins.sourcemaps.init())
        .pipe(plugins.sass().on("error", plugins.sass.logError))
        .pipe(gulp.dest(paths.temp))
        //.pipe(plugins.sourcemaps.write())
        .pipe(plugins.cssnano(configs.cssnano))
        .pipe(gulp.dest(paths.css));
});

/*
// CSS tasks that forces dependencies to be run sequentially.
// Parallelisation is playing havoc, as the spritesheets
// must be generated first, as their SASS outputs
// are required for the SASS build!
gulp.task("css", function () {
    runSequence(
        tasks.sass.lint,
        tasks.sass.spritesheet.png,
        tasks.sass.spritesheet.svg,
        tasks.sass.build);
});
*/

// TODO Use gulp-if and lazypipe to only run this when any files has changed.
gulp.task(tasks.js.build, [tasks.js.lint], function () {
    return gulp
        .src(paths.js.srcAll)
        .pipe(amdOptimize("app", {
            name: "app",
            configFile: "src/js/app.js",
            baseUrl: "src/js"
        }))
        .pipe(plugins.concat(paths.js.filename))
        .pipe(plugins.uglify())
        .pipe(gulp.dest(paths.js.dest));
});

gulp.task(tasks.default, [
    tasks.js.build,
    tasks.images,
    tasks.sass.build
]);

// Favicon tasks, deliberately separate to the main build.
// TODO Conditionally run these!
gulp.task(tasks.favicon.build, function () {
    plugins.realFavicon.generateFavicon(configs.favicon);
});

gulp.task(tasks.favicon.template, function () {
    return gulp
        .src(paths.favicon.template)
        .pipe(plugins.realFavicon.injectFaviconMarkups
            (JSON.parse(fs
                .readFileSync(configs.favicon-config.markupFile))
                .favicon.html_code))
        .pipe(gulp.dest(paths.base));
});

gulp.task(tasks.watch, function () {
    gulp.watch(paths.js.src, [
        tasks.js.build
    ]);

    gulp.watch(paths.sass.srcAll, [
        tasks.sass.build
    ]);
});

gulp.task(tasks.serve, function() {
    browserSync({
        server: {
            baseDir: paths.base
        }
    });

    gulp.watch(
        paths.html,
        { cwd: paths.base },
        browserSync.reload);

    gulp.watch(
        [paths.js.srcAll],
        { cwd: paths.base },
        [tasks.js.build, browserSync.reload]);

    gulp.watch(
        [paths.sass.srcAll],
        { cwd: paths.base },
        [tasks.sass.build, browserSync.reload]);
});
