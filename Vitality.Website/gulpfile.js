// jshint strict: false

var browserSync = require("browser-sync");
var del = require("del");
var gulp = require("gulp");
var rimraf = require("rimraf");
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
    sass: "./src/sass/**/*.scss",
    ts: "src/ts/**/*.ts",
    html: "src/ts/**/*.html"
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
    return plugins.bower({ cmd: "update" });
});

gulp.task("typescript", function () {
    // Copy HTML templates, too.
    gulp
        .src("src/ts/**/*.html")
        .pipe(plugins.copy(paths.js.dest, { prefix: 2 }));

    var tsProject = plugins.typescript.createProject("tsconfig.json");

    var tsResult = gulp
        .src("src/ts/**/*.ts")
        .pipe(tsProject());

    return tsResult.js.pipe(gulp.dest(paths.js.dest));
});

gulp.task("watch", function () {
    gulp.watch(paths.sass, [
        "css"
    ]);

    gulp.watch([paths.ts, paths.html], [
        "typescript"
    ]);
});

gulp.task("serve", function () {
    browserSync({
        options: {
            proxy: {
                target: "http://presales.vitality.co.uk/"
            }
        }
    });

    gulp.watch(paths.sass, [
        "css",
        browserSync.reload
    ]);

    gulp.watch([paths.ts, paths.html], [
        "typescript",
        browserSync.reload
    ]);
});

gulp.task("clean", function (cb) {
    return rimraf(paths.js.dest, cb);
});
