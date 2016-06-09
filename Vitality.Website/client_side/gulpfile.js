// jshint strict: false

var del = require("del");
var gulp = require("gulp");

var plugins = require("gulp-load-plugins")({
    pattern: ["gulp[\-\.]*"],
    replaceString: /\bgulp[\-\.]/
});

var tasks = {
    css: "css",
    "default": "default",
    sass: {
        build: "sass:build",
        lint: "sass:lint"
    }
};

var paths = {
    css: "../css",
    sass: "sass/**/*.scss"
}

gulp.task(tasks.sass.lint, function () {
    return gulp
        .src(paths.sass)
        .pipe(plugins.sassLint())
        .pipe(plugins.sassLint.format())
        .pipe(plugins.sassLint.failOnError());
});

gulp.task(tasks.sass.build, [tasks.sass.lint], function () {
    return gulp
        .src(paths.sass)
        .pipe(plugins.sass().on("error", plugins.sass.logError))
        .pipe(gulp.dest(paths.css));
});

gulp.task(tasks.css, [tasks.sass.build], function () {
    return gulp
        .src("../css/**/*.css")
        .pipe(plugins.cssnano())
        .pipe(gulp.dest(paths.css));
});

gulp.task(tasks.default, [
    tasks.css
]);
