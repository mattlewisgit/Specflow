// jshint strict: false

// Include the libraries.
var amdOptimize = require("amd-optimize");
var concat = require("gulp-concat");
var cssnano = require("gulp-cssnano");
var del = require("del");
var gulp = require("gulp");
var fs = require("fs");
var imageResize = require("gulp-image-resize");
var jshint = require("gulp-jshint");
var jscs = require("gulp-jscs");
var realFavicon = require("gulp-real-favicon");
var rename = require("gulp-rename");
var runSequence = require('run-sequence');
var sass = require("gulp-sass");
var sassLint = require("gulp-sass-lint");
var spritesmith = require("gulp.spritesmith");
var svgSprite = require("gulp-svg-sprite");
var uglify = require("gulp-uglify");

// Include custom configuration.
var configs = {
    cssnano: require("./cssnano_config.json")
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
        .pipe(jshint())
        .pipe(jshint.reporter("default"))
        .pipe(jshint.reporter("fail"));
});

gulp.task(tasks.js.style, function () {
    return gulp
        .src([
            files.gulp,
            files.js
        ])
        .pipe(jscs())
        .pipe(jscs.reporter());
});

gulp.task(tasks.sass.lint, function () {
    return gulp
        .src([
            files.sass,
            "!" + files.sassGenerated,
            "!src/sass/utils/_svg-template.scss",
            "!src/sass/vendor/**/*.scss"
        ])
        .pipe(sassLint())
        .pipe(sassLint.format())
        .pipe(sassLint.failOnError());
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
        .pipe(imageResize({
            width: "50%",
            height: "50%",
            crop: false,
            upscale: false
        }))
        .pipe(rename(function(path) {
            path.basename += "@half";
        }))
        .pipe(gulp.dest("images/"));
});

// Spritesheet generation.
gulp.task(tasks.sprite, function () {
    var spriteData = gulp
        .src("src/images/**/*.png")
        .pipe(spritesmith({
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
        .pipe(svgSprite({
            shape: {
                spacing: {
                    padding: 10
                }
            },
            mode: {
                css: {
                    dest: "",
                    bust: false,
                    sprite: "src/images/svg-sprite.svg",
                    render: {
                        scss: {
                            dest: "src/sass/generated/_svg-sprite.scss",
                            template: "src/sass/utils/_svg-template.scss"
                        }
                    },
                    dimensions: true
                }
            }
        }))
        .pipe(gulp.dest("."));
});

gulp.task(tasks.sass.build, [tasks.sprite, tasks.svg], function () {
    return gulp
        .src(files.sass)
        .pipe(sass().on("error", sass.logError))
        .pipe(gulp.dest("src/sass/"))
        .pipe(cssnano(configs.cssnano))
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
        .pipe(concat("vitality-boilerplate.js"))
        .pipe(uglify())
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
var favicon = {
    data: "favicon-data.json",
    image: "images/favicon/favicon.svg",
    iconsPath: "img/favicon/",
    template: "src/favicon-template.html"
};

gulp.task(tasks.favicon, function () {
    // TODO Use SASS variables from JSON.
    var backgroundColour = "#fff";
    var colour = "#f41c5e";
    var projectName = "Vitality";

    realFavicon.generateFavicon({
        dest: ".." + favicon.iconsPath,
        iconsPath: favicon.iconsPath,
        markupFile: favicon.data,
        masterPicture: favicon.image,
        design: {
            ios: {
                pictureAspect: "backgroundAndMargin",
                backgroundColor: backgroundColour,
                margin: "14%",
                appName: projectName
            },
            desktopBrowser: {},
            windows: {
                pictureAspect: "whiteSilhouette",
                backgroundColor: colour,
                onConflict: "override",
                appName: projectName
            },
            androidChrome: {
                pictureAspect: "backgroundAndMargin",
                margin: "17%",
                backgroundColor: backgroundColour,
                themeColor: backgroundColour,
                manifest: {
                    name: projectName,
                    display: "browser",
                    orientation: "notSet",
                    onConflict: "override",
                    declared: true
                }
            },
            safariPinnedTab: {
                pictureAspect: "silhouette",
                themeColor: colour
            },
            openGraph: {
                pictureAspect: "backgroundAndMargin",
                backgroundColor: backgroundColour,
                margin: "30%",
                ratio: "1.91:1",
                siteUrl: "https://www.vitality.co.uk/"
            }
        },
        settings: {
            compression: 1,
            scalingAlgorithm: "Mitchell",
            errorOnImageTooSmall: false
        }
    });
});

// Fill in the standard favicon HTML template.
gulp.task(tasks.faviconTemplate, function () {
    return gulp
        .src(favicon.template)
        .pipe(realFavicon.injectFaviconMarkups
            (JSON.parse(fs.readFileSync(favicon.data)).favicon.html_code))
        .pipe(gulp.dest("."));
});

// Default watch task that continuously compiles pre-processor code.
gulp.task(tasks.watch, function () {
    gulp.watch(files.sass, [
        tasks.clean,
        tasks.build
    ]);
});
