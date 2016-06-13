// jshint strict: false

var del = require("del");
var gulp = require("gulp");

var plugins = require("gulp-load-plugins")({
    pattern: ["gulp[\-\.]*"],
    replaceString: /\bgulp[\-\.]/
});

var configs = {
    cssnano: require("./config/cssnano-config.json")
};

var tasks = {
    css: {
        build: "css",
        lint: "css:lint"
    },
    "default": "default",
    help: "help"
};

var paths = {
    css: "../css",
    sass: "sass/**/*.scss"
}

gulp.task(tasks.help, plugins.taskListing);

gulp.task(tasks.css.lint, function () {
    return gulp
        .src(paths.sass)
        .pipe(plugins.sassLint())
        .pipe(plugins.sassLint.format())
        .pipe(plugins.sassLint.failOnError());
});

gulp.task(tasks.css.build, [tasks.css.lint], function () {
    return gulp
        .src(paths.sass)
        .pipe(plugins.sass().on("error", plugins.sass.logError))
        .pipe(plugins.cssnano(configs.cssnano))
        .pipe(gulp.dest(paths.css));
});

gulp.task(tasks.default, [
    tasks.css.build
]);
