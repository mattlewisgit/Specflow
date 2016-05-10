// jshint strict: false

// Include the libraries.
var cssnano = require("gulp-cssnano");
var del = require("del");
var gulp = require("gulp");
var jshint = require("gulp-jshint");
var jscs = require("gulp-jscs");
var sass = require("gulp-sass");
var sassLint = require("gulp-sass-lint");

// Store the tasks as names, so that they can be easily
// referenced from the individual and default tasks.
var buildTask = "build";
var cleanTask = "clean";
var cssMinify = "css_minify";
var jsStaticAnalysis = "js_static_analysis";
var jsStyle = "js_style";
var lintTask = "lint";
var sassBuildTask = "sass_build";
var sassLintTask = "sass_lint";

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
        .src("sass/**/*.scss")
        .pipe(sassLint())
        .pipe(sassLint.format())
        .pipe(sassLint.failOnError());
});

// Cleans up.
gulp.task(cleanTask, function () {
    return del([
        "sass/**/*.css"
    ]);
});

gulp.task(sassBuildTask, function () {
    return gulp
        .src("sass/**/*.scss")
        .pipe(sass().on("error", sass.logError))
        .pipe(gulp.dest("../css"));
});

// Minifies CSS.
gulp.task(cssMinify, function () {
    return gulp
        .src("../css/app.css")
        .pipe(cssnano())
        .pipe(gulp.dest("../css"));
});

// A group of all lint tasks.
gulp.task(lintTask, [
    jsStaticAnalysis,
    jsStyle,
    sassLintTask,
]);

// A group of all build tasks.
gulp.task(buildTask, [
    sassBuildTask,
    cssMinify
]);

// Default task that runs all the tasks.
gulp.task("default", [
    cleanTask,
    lintTask,
    buildTask
]);