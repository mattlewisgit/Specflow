// jscs:disable maximumNumberOfLines
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
        thirdParty: "js:third-party",
        unitTests: "js:unit-tests"
    },
    razor: "razor",
    report: "report",
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
    critical: "critical-css.html",
    css: "css",
    dist: "dist",
    favicon: {
        template: "src/favicon-template.html"
    },
    gulp: "gulpfile.js",
    html: [
        "index.html",
        "components/**/*.html",
        "global/**/*.html",
        "pages/**/*.html"
    ],
    img: {
        examples: {
            dest: "img/examples",
            src: "src/img/examples/**/*"
        },
        spritesheets: {
            // Move to "img/spritesheets"
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
        thirdPartyTemplate: "src/js-third-party.html",
        unitTests: "src/unit-tests/**/*.js"
    },
    sass: {
        generated: "src/sass/generated",
        src: [
            "src/sass/**/*.scss",
            // Ignore list.
            // Cannot control generated source.
            "!src/sass/generated/*.scss",
            // Add this back when SASS lint bug is fixed!
            "!src/sass/utils/_background-positions.scss",
            // One-off, very dynamic function set.
            "!src/sass/utils/_svg-template.scss",
            // Do not lint vendor source.
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
    "package": require("./package.json"),
    sizeReport: require("./config/sizereport-config.json"),
    svgSprite: require("./config/svgsprite-config.json")
};

var cdnReplacements = configs.cdnizer.files
    .map(function (file) {
        return "./" + file.file;
    });

gulp.task(tasks.help, plugins.taskListing);

gulp.task(tasks.js.lint, function () {
    return gulp
        .src([paths.gulp, paths.js.src, paths.js.unitTests])
        .pipe(plugins.changed(paths.temp))
        .pipe(gulp.dest(paths.temp))
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
        paths.sass.generated,
        paths.temp,
        paths.tempFiles
    ]);
});

gulp.task(tasks.images, function () {
    return gulp
        .src(paths.img.examples.src)
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
        .pipe(plugins.spritesmith({
            cssName: "_sprite.scss",
            cssVarMap: function (sprite) {
                sprite.name = "sprite_" + sprite.name;
            },
            imgName: "sprite-generated.png",
            padding: 5,
            retinaImgName: "sprite-generated@2x.png",
            retinaSrcFilter: "src/images/**/*@2x.png"
        }));

    spriteData.img
        .pipe(buffer())
        .pipe(plugins.imagemin())
        .pipe(gulp.dest(paths.img.spritesheets.dest));

    return spriteData.css.pipe(gulp.dest(paths.sass.generated));
});

gulp.task(tasks.sass.spritesheet.svg, function () {
    return gulp
        .src(paths.img.spritesheets.svgSrc)
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
    var dimensions = Object.keys(configs.breakpoints).map(function (key) {
        var width = parseInt(configs.breakpoints[key].replace("px", ""));

        return {
            height: width * 0.6,
            width: width
        };
    });

    critical.generate({
        base: ".",
        dest: paths.templates.dest + paths.critical,
        dimensions: dimensions,
        inline: true,
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

    return browserify("./src/js/main.js")
        .bundle()
        .pipe(source("app.js"))
        .pipe(gulp.dest("./js/"));
});

gulp.task(tasks.js.unitTests, function () {
    del("./js/unit-tests.js");

    return browserify("./src/unit-tests/unit-tests.js")
        .bundle()
        .pipe(source("unit-tests.js"))
        .pipe(gulp.dest("./js/"));
});

gulp.task(tasks.js.thirdParty, function () {
    gulp
        .src(cdnReplacements, {
            base: "."
        })
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
    // Copy the bower failover JS paths only and add the app.
    var allJs = cdnReplacements
        .splice(0)
        .filter(function (fileConfig) {
            return fileConfig.test;
        });

    allJs.push(paths.js.src);

    return gulp
        .src(allJs)
        .pipe(plugins.autopolyfiller(paths.js.polyfill, {
            browsers: ["last 3 versions", "ie 9"]
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
        .pipe(plugins.changed(paths.temp))
        .pipe(gulp.dest(paths.temp))
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

// Creates razor versions of the templates.
// Does this by renaming to a .NET-friendly format,
// and replacing tags and adding NWebsec tags.
gulp.task(tasks.razor, function () {
    gulp
        .src(paths.templates.dest + "*.html")
        .pipe(plugins.replace("@", "@@"))
        .pipe(plugins.replace("<script", "<script @Html.CspScriptNonce()"))
        .pipe(plugins.replace("<link", "<link @Html.CspScriptNonce()"))
        .pipe(plugins.rename(function (path) {
            path.basename = asRazorPartialName(path.basename);
            path.extname = ".cshtml";
        }))
        .pipe(gulp.dest(paths.templates.dest));
});

// Favicon tasks, deliberately separate to the main build.
// Conditionally run these!
gulp.task(tasks.favicon.build, function () {
    plugins.realFavicon.generateFavicon(configs.favicon);
});

gulp.task(tasks.favicon.template, function () {
    // jscs:disable requireCamelCaseOrUpperCaseIdentifiers
    return gulp
        .src(paths.favicon.template)
        .pipe(plugins.realFavicon.injectFaviconMarkups
            (JSON.parse(fs
                .readFileSync(configs.favicon.markupFile))
                .favicon.html_code))
        .pipe(gulp.dest(paths.base));
    // jscs:enable requireCamelCaseOrUpperCaseIdentifiers
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
        .src([
            paths.dist + "/" + paths.baseAssetName + "*.*",
            paths.templates.dest + "*.html"
        ])
        .pipe(plugins.sizereport(configs.sizeReport));
});

gulp.task(tasks.watch, function () {
    gulp.watch(paths.js.src, [
        tasks.js.devel
    ]);

    gulp.watch(paths.sass.src, [
        tasks.sass.devel
    ]);
});

gulp.task(tasks.serve, function () {
    browserSync({
        server: {
            baseDir: paths.base,
            serveStaticOptions: {
                extensions: ["html"]
            }
        }
    });

    var options = {
        cwd: paths.base
    };

    gulp.watch(paths.html, options, browserSync.reload);

    gulp.watch(
        [paths.js.src, paths.js.unitTests],
        options,
        [tasks.js.devel, tasks.js.unitTests, browserSync.reload]);

    gulp.watch(
        [paths.sass.srcAll],
        options,
        [tasks.sass.devel, browserSync.reload]);
});
