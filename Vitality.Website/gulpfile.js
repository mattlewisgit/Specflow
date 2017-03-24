// jshint strict: false

var del = require("del");
var gulp = require("gulp");
var runSequence = require("run-sequence");

// Pull all Gulp plugins into a single object.
var plugins = require("gulp-load-plugins")({
    pattern: ["gulp[\-\.]*"],
    replaceString: /\bgulp[\-\.]/
});

// Set paths that are used eveywhere.
var paths = {
    config: "./config/",
    css: "./css",
    js: {
        dest: "./js/",
        minified: "vitality.presales.min.js",
        src: "./src/js/*.js"
    },
    sass: "./src/sass/**/*.scss"
}

// Include all configuration files in a single object.
var configs = {
    cssnano: require(paths.config + "cssnano-config")
};

// Task listing.
gulp.task("help", plugins.taskListing);

// CSS SQA.
gulp.task("css:lint", function () {
    return gulp
        .src(paths.sass)
        .pipe(plugins.sassLint())
        .pipe(plugins.sassLint.format())
        .pipe(plugins.sassLint.failOnError());
});

// Compiles all SASS to CSS.
gulp.task("css", ["css:lint"], function () {
    return gulp
        .src(paths.sass)
        .pipe(plugins.sass().on("error", plugins.sass.logError))
        .pipe(plugins.cssnano(configs.cssnano))
        .pipe(gulp.dest(paths.css));
});

// Concatenates and minifies all custom Presales scripts.
gulp.task("js", function () {
    return gulp
        .src(paths.js.src)
        .pipe(plugins.concat(paths.js.minified))
        .pipe(plugins.uglify())
        .pipe(gulp.dest(paths.js.dest));
});

// Standard task runner that installs and builds eveything.
gulp.task("default", function () {
    runSequence(
        "bower",
        [
            "css",
            "js"
        ]
    );
});

// Simply runs bower, but saves running the command separately.
gulp.task("bower", function () {
    return plugins.bower({ cmd: 'update' });
});
