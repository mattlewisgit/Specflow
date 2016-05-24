// jshint strict: false

// Include the libraries.
var amdOptimize = require("amd-optimize");
var concat = require("gulp-concat");
var cssnano = require("gulp-cssnano");
var del = require("del");
var gulp = require("gulp");
var fs = require("fs");
var jshint = require("gulp-jshint");
var jscs = require("gulp-jscs");
var realFavicon = require("gulp-real-favicon");
var sass = require("gulp-sass");
var sassLint = require("gulp-sass-lint");
var spritesmith = require("gulp.spritesmith");
var svgSprite = require("gulp-svg-sprite");
var uglify = require("gulp-uglify");

// Include custom configuration.
var cssnanoConfig = require("./cssnano_config.json");

// Store the tasks as names, so that they can be easily
// referenced from the individual and default tasks.
var buildTask = "build";
var cleanTask = "clean";
var cssMinify = "css_minify";
var faviconTask = "favicon";
var faviconTemplateTask = "favicon-template";
var jsBuildTask = "js_build";
var jsStaticAnalysis = "js_static_analysis";
var jsStyle = "js_style";
var lintTask = "lint";
var sassBuildTask = "sass_build";
var sassLintTask = "sass_lint";
var spriteTask = "sprite";
var spritesTask = "sprites";
var svgTask = "svg";

// Lints all local JavaScript files, including this!
gulp.task(jsStaticAnalysis, function () {
    return gulp
        .src([
            "gulpfile.js",
            "js/**/*.js"
        ])
        .pipe(jshint())
        .pipe(jshint.reporter("default"))
        .pipe(jshint.reporter("fail"));
});

gulp.task(jsStyle, function () {
    return gulp
        .src([
            "gulpfile.js",
            "js/**/*.js"
        ])
        .pipe(jscs())
        .pipe(jscs.reporter());
});

gulp.task(sassLintTask, function () {
    return gulp
        .src([
            "sass/**/*.scss",
            "!sass/generated/*.scss",
            "!sass/utils/_svg-template.scss",
            "!sass/vendor/**/*.scss"
        ])
        .pipe(sassLint())
        .pipe(sassLint.format())
        .pipe(sassLint.failOnError());
});

// Cleans build artefacts.
gulp.task(cleanTask, function () {
    return del([
        "sass/**/*.css",
        "sass/**/*.min.*",
        "sass/generated/*.scss"
    ]);
});

// Spritesheet generation.
gulp.task(spriteTask, function () {
    var source = "images/sprite/**/";

    var spriteData = gulp
        .src(source + "*.png")
        .pipe(spritesmith({
            src: source + "*.png",
            retinaSrcFilter: source + "*@2x.png",
            imgName: "../images/sprite-generated.png",
            padding: 5,
            retinaImgName: "../images/sprite-generated@2x.png",
            cssName: "sass/generated/_sprite.scss",
            cssVarMap: function (sprite) {
                sprite.name = "sprite_" + sprite.name;
            }
        }));

    spriteData.img.pipe(gulp.dest("."));
    spriteData.css.pipe(gulp.dest("."));
});

gulp.task(svgTask, function () {
    return gulp
        .src("images/**/*.svg")
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
                    sprite: "images/svg-sprite.svg",
                    render: {
                        scss: {
                            dest: "sass/generated/_svg-sprite.scss",
                            template: "sass/utils/_svg-template.scss"
                        }
                    },
                    dimensions: true
                }
            }
        }))
        .pipe(gulp.dest("."));
});

gulp.task(sassBuildTask, [spriteTask, svgTask], function () {
    return gulp
        .src("sass/**/*.scss")
        .pipe(sass().on("error", sass.logError))
        .pipe(gulp.dest("sass/"));
});

// Minifies CSS.
gulp.task(cssMinify, function () {
    return gulp
        .src("sass/app.css")
        .pipe(cssnano(cssnanoConfig))
        .pipe(gulp.dest("../css"));
});

// Require JS build.
gulp.task(jsBuildTask, function () {
    return gulp
        .src("src/**/*.js")
        .pipe(amdOptimize("app", {
            name: "app",
            configFile: "./js/app.js",
            baseUrl: "./js"
        }))
        .pipe(concat("vitality-boilerplate.js"))
        .pipe(uglify())
        .pipe(gulp.dest("../js"));
});

// A group of all lint tasks.
gulp.task(lintTask, [
    //jsStaticAnalysis,
    //jsStyle,
    sassLintTask
]);

// A group of all build tasks.
gulp.task(buildTask, [
    sassBuildTask,
    cssMinify,
    jsBuildTask
]);

// Default task that runs all the tasks.
gulp.task("default", [
    cleanTask,
    lintTask,
    buildTask
]);

// Favicon tasks, deliberately separate to the main build.

var favicon = {
    data: "favicon-data.json",
    image: "images/favicon/favicon.svg",
    iconsPath: "/img/favicon/",
    template: "favicon-template.html"
};

gulp.task(faviconTask, function () {
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
gulp.task(faviconTemplateTask, function () {
    return gulp
        .src(favicon.template)
        .pipe(realFavicon.injectFaviconMarkups
            (JSON.parse(fs.readFileSync(favicon.data)).favicon.html_code))
        .pipe(gulp.dest("../"));
});
