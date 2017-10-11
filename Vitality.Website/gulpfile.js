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

var tasks = {
    bower: {
        "default": "bower",
        run: "run"
    },
    clean: "clean",
    css: {
        "default": "css",
        lint: "css:lint"
    },
    "default": "default",
    help: "help",
    js: {
        "default": "js",
        typescript: "typescript"
    },
    serve: "serve",
    watch: "watch"
};

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
gulp.task(tasks.help, plugins.taskListing);

// CSS SQA.
gulp.task(tasks.css.lint, function () {
    return gulp
        .src(paths.sass)
        .pipe(plugins.sassLint())
        .pipe(plugins.sassLint.format())
        .pipe(plugins.sassLint.failOnError());
});

// Compiles all SASS to CSS.
gulp.task(tasks.css.default, [tasks.css.lint], function () {
    return gulp
        .src(paths.sass)
        .pipe(plugins.sass().on("error", plugins.sass.logError))
        .pipe(plugins.cssnano(configs.cssnano))
        .pipe(gulp.dest(paths.css));
});

// Concatenates and minifies all custom Presales scripts.
gulp.task(tasks.js.default, [tasks.js.typescript], function () {
    return gulp
        .src(paths.js.src)
        .pipe(plugins.concat(paths.js.minified))
        .pipe(plugins.uglify())
        .pipe(gulp.dest(paths.js.dest));
});

// Standard task runner that installs and builds eveything.
gulp.task(tasks.default, function () {
    runSequence(
        tasks.bower.default,
        [
            tasks.css.default,
            tasks.js.default
        ]
    );
});

// Run bower and copy required assets.
gulp.task(tasks.bower.default, [tasks.bower.run], function () {
    var boilerplateDist = "./bower_components/vitality.boilerplate/dist/";

    gulp
        .src(boilerplateDist + "sprite-generated*.png")
        .pipe(gulp.dest("./images/"));

    return gulp
        .src(boilerplateDist + "svg-sprite.svg")
        .pipe(gulp.dest("./img/spritesheets/"));
});

gulp.task(tasks.bower.default, [tasks.bower.run], function () {
    var boilerplateDist = "./bower_components/quote.boilerplate/images/";

    return gulp
        .src(boilerplateDist + "*.*")
        .pipe(gulp.dest("./images/"));
});

gulp.task(tasks.bower.run, function () {
    return plugins.bower({ cmd: "update" });
});

gulp.task(tasks.js.typescript, function () {
    // Copy HTML templates, too.
    gulp
        .src("src/ts/**/*.html")
        .pipe(plugins.copy(paths.js.dest, { prefix: 2 }));

    var tsProject = plugins.typescript.createProject("tsconfig.json");

    var tsResult = gulp
        .src("src/ts/**/*.ts")
        .pipe(tsProject());

    return tsResult.js
        .pipe(plugins.uglify())
        .pipe(gulp.dest(paths.js.dest));
});

gulp.task(tasks.watch, function () {
    gulp.watch(paths.sass, [
        "css"
    ]);

    gulp.watch([paths.ts, paths.html], [
        "typescript"
    ]);
});

gulp.task(tasks.serve, function () {
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

gulp.task(tasks.clean, function (cb) {
    return rimraf(paths.js.dest, cb);
});
