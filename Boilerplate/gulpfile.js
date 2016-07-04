// jshint strict: false

var browserify = require("browserify");
var browserSync = require("browser-sync");
var buffer = require("vinyl-buffer");
var critical = require("critical");
var del = require("del");
var gulp = require("gulp");
var fs = require("fs");
var runSequence = require("run-sequence");
var source = require("vinyl-source-stream");
var toTitleCase = require("to-title-case");

var plugins = require("gulp-load-plugins")({
    pattern: ["gulp[\-\.]*"],
    replaceString: /\bgulp[\-\.]/
});

var tasks = {
    clean: "clean",
    css: "css",
    "default": "default",
    favicon: {
        build: "favicon:build",
        checkForUpdate: "favicon:check-for-update",
        template: "favicon:template"
    },
    help: "help",
    html: "html",
    images: "images",
    js: {
        build: "js",
        devel: "js:devel",
        lint: "js:lint",
        polyfill: "js:polyfill",
        thirdParty: "js:third-party"
    },
    razor: "razor",
    report: "report",
    resize: "resize",
    sass: {
        build: "sass:build",
        critical: "sass:critical",
        devel: "sass:devel",
        json: "sass:json",
        lint: "sass:lint",
        modernizr: "sass:modernizr",
        spritesheet: {
            png: "sass:spritesheet-png",
            svg: "sass:spritesheet-svg"
        }
    },
    serve: "serve",
    watch: "watch"
};

var paths = {
    base: ".",
    baseAssetName: "vitality-boilerplate-",
    css: "css",
    critical: "critical-css.html",
    dist: "dist",
    favicon: {
        template: "src/favicon-template.html"
    },
    gulp: "gulpfile.js",
    html: [
        "index.html",
        "components/**/*.html",
        "global/**/*.html"
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
        breakpoints: "src/js/breakpoints.json",
        dest: "js/",
        modernizr: "modernizr-custom.js",
        polyfill: "polyfill-custom.js",
        src: "src/js/**/*.js",
        thirdPartyTemplate: "src/js-third-party.html"
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
    temp: "tmp",
    tempFiles: "tmp-*.*",
    templates: {
        dest: "dist/templates/",
        src: "src/templates/"
    }

};

var configs = {
    breakpoints: require("./" + paths.js.breakpoints),
    cdnizer: require("./config/cdnizer-config.json"),
    cssnano: require("./config/cssnano-config.json"),
    favicon: require("./config/favicon-config.json"),
    htmlMin: require("./config/htmlmin-config.json"),
    imageResize: require("./config/image-resize-config.json"),
    "package": require("./package.json"),
    sizeReport: require("./config/sizereport-config.json"),
    svgSprite: require("./config/svgsprite-config.json")
};

var cdnReplacements = configs.cdnizer.files
    .map(function (file) { return "./" + file.file; });

gulp.task(tasks.help, plugins.taskListing);

gulp.task(tasks.js.lint, function () {
    return gulp
        .src([paths.gulp, paths.js.src])
        .pipe(plugins.jscpd({
            "min-lines": 10,
            verbose: true
        }))
        .pipe(plugins.jshint())
        .pipe(plugins.jscs())
        .pipe(plugins.jscsStylish.combineWithHintResults())
        .pipe(plugins.jshint.reporter("jshint-stylish"))
        .pipe(plugins.jshint.reporter("fail"));
});

gulp.task(tasks.sass.lint, function () {
    return gulp
        .src(paths.sass.src)
        .pipe(plugins.sassLint())
        .pipe(plugins.sassLint.format())
        .pipe(plugins.sassLint.failOnError());
});

gulp.task(tasks.clean, function () {
    return del([
        paths.css,
        paths.img.examples.dest,
        paths.img.spritesheets.dest,
        paths.sass.generated,
        paths.temp,
        paths.tempFiles
    ]);
});

gulp.task(tasks.images, function() {
    return gulp
        .src(paths.img.examples.src)
        .pipe(plugins.changed(paths.img.examples.src))
        .pipe(plugins.imagemin())
        .pipe(gulp.dest(paths.img.examples.dest));
});

// Use the breakpoints JSON config to create a map for sass-mq.
// The same config is used directly via browersify as a JavaScript module,
// so changing a single value there and rebuilding via Gulp will change it
// everywhere, ensuring JS and CSS is kept in sync.
gulp.task(tasks.sass.json, function () {
    var mapContents = Object.keys(configs.breakpoints).map(function (key) {
        return "    ".concat(key, ": ", configs.breakpoints[key]);
    })
    .join(",\n");

    var mqMap = "$mq-breakpoints: (\n" + mapContents + "\n);\n";

    return gulp
        .src(paths.js.breakpoints)
        .pipe(plugins.changed(paths.temp))
        .pipe(plugins.file("_breakpoints.scss", mqMap))
        .pipe(gulp.dest(paths.sass.generated));
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
});

gulp.task(tasks.sass.devel, function () {
    return gulp
        .src(paths.sass.srcAll)
        .pipe(plugins.sourcemaps.init())
        .pipe(plugins.sass().on("error", plugins.sass.logError))
        .pipe(plugins.sourcemaps.write("."))
        .pipe(gulp.dest(paths.css));
});

gulp.task(tasks.sass.build, function () {
    return gulp
        .src(paths.css + "/*.css")
        .pipe(plugins.cssnano(configs.cssnano))
        .pipe(plugins.rename(function (path) {
            path.basename += "-" + configs.package.version + ".min";
        }))
        .pipe(gulp.dest(paths.dist));
});

// Creates a critical CSS template from a sample main navigation page.
// This means that the page will render incredibly quickly, then load
// the rest of the styles via JavaScript.
gulp.task(tasks.sass.critical, function () {
    // Use all the breakpoints to generate the critical CSS for each media query.
    // The height is not important here, so use an estimate.
    var dimensions = Object.keys(configs.breakpoints).map(function(key) {
        var width = configs.breakpoints[key];

        return {
            height: width * 0.6,
            width: width
        };
    });

    critical.generate({
        inline: true,
        base: ".",
        dest: paths.templates.dest + paths.critical,
        dimensions: dimensions,
        src: paths.templates.src + paths.critical
    }, function () {
        gulp.start(tasks.razor);
    });
});

// CSS task that forces dependencies to be run sequentially.
// Parallelisation is playing havoc, as the spritesheets
// must be generated first, as their SASS outputs
// are required for the SASS build!
gulp.task(tasks.css, function () {
    runSequence(
        tasks.sass.spritesheet.png,
        tasks.sass.spritesheet.svg,
        tasks.sass.json,
        tasks.sass.lint,
        tasks.sass.devel,
        tasks.sass.build,
        tasks.sass.modernizr,
        tasks.sass.critical);
});

gulp.task(tasks.js.devel, function () {
    del("./js/app.js");

    return browserify("./src/js/modules/main.js")
        .bundle()
        .pipe(source("app.js"))
        .pipe(gulp.dest("./js/"));
});

gulp.task(tasks.js.thirdParty, function () {
    gulp
        .src(cdnReplacements, { base: "." })
        .pipe(gulp.dest("dist"));

    gulp
        .src(paths.js.thirdPartyTemplate)
        .pipe(plugins.changed(paths.temp))
        .pipe(gulp.dest(paths.temp))
        .pipe(plugins.cdnizer(configs.cdnizer))
        .pipe(gulp.dest(paths.templates.dest));

    return gulp.start(tasks.razor);
});

gulp.task(tasks.js.polyfill, function () {
    // Copy the bower failover paths and add the app.
    var allJs = cdnReplacements.splice(0);
    allJs.push(paths.js.src);

    return gulp
        .src(allJs)
        .pipe(plugins.autopolyfiller(paths.js.polyfill, {
            browsers: ["last 3 versions", "ie 8", "ie 9"]
        }))
        .pipe(gulp.dest(paths.js.dest));
});

gulp.task(
    tasks.js.build,
    [
        tasks.js.lint,
        tasks.js.devel,
        tasks.js.thirdParty,
        tasks.js.polyfill
    ],
    function () {
        return gulp
            .src([
                paths.js.dest + paths.js.modernizr,
                paths.js.dest + paths.js.polyfill,
                paths.js.dest + "app.js"
            ])
            .pipe(plugins.concat
                (paths.baseAssetName + configs.package.version + ".min.js"))
            .pipe(plugins.uglify())
            .pipe(gulp.dest(paths.dist));
    });

gulp.task(tasks.html, function () {
    return gulp
        .src(paths.html)
        .pipe(plugins.htmlhint(".htmlhintrc"))
        .pipe(plugins.htmlhint.reporter("htmlhint-stylish"))
        .pipe(plugins.htmlhint.failReporter());
});

gulp.task(tasks.default, [
    tasks.css,
    tasks.images,
    tasks.js.build,
    tasks.html
]);

gulp.task(tasks.sass.modernizr, function () {
    return gulp
        .src(paths.sass.src)
        .pipe(plugins.modernizr({
            cache: true,
            crawl: true,
            options: [
                "html5shiv",
                "mq",
                "setClasses"
            ]
        }))
        .pipe(plugins.rename(paths.js.modernizr))
        .pipe(gulp.dest(paths.js.dest));
});

function asRazorPartialName(filename) {
    return "_" + toTitleCase(filename
        .replace(/[ -_]/g, " "))
        .replace(/ /g, "");
}

gulp.task(tasks.razor, function () {
    gulp
        .src(paths.templates.dest + "*.html")
        .pipe(plugins.replace("@", "@@"))
        .pipe(plugins.rename(function (path) {
            path.basename = asRazorPartialName(path.basename);
            path.extname = ".cshtml";
        }))
        .pipe(gulp.dest(paths.templates.dest));
});

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
                .readFileSync(configs.favicon.markupFile))
                .favicon.html_code))
        .pipe(gulp.dest(paths.base));
});

gulp.task(tasks.favicon.checkForUpdate, function () {
    var currentVersion = JSON.parse
        (fs.readFileSync(configs.favicon.markupFile)).version;

    plugins.realFavicon.checkForUpdates(currentVersion, function (err) {
        if (err) {
            throw err;
        }
    });
});

gulp.task(tasks.report, function () {
    return gulp
        .src(paths.dist + "/**/*")
        .pipe(plugins.sizereport(configs.sizeReport));
});

gulp.task(tasks.watch, function () {
    gulp.watch(paths.js.src, [
        tasks.js.build
    ]);

    gulp.watch(paths.sass.src, [
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
        [paths.js.src],
        { cwd: paths.base },
        [tasks.js.devel, browserSync.reload]);

    gulp.watch(
        [paths.sass.srcAll],
        { cwd: paths.base },
        [tasks.sass.devel, browserSync.reload]);
});
