angular
    .module("FeemaximaService", [])
    .service("FeemaximaService", ["$q", "$http", function ($q, $http) {
        "use strict";
        var baseUrl = "/api/feemaxima/";

        // Typehead currently doesn't return dataset name on select. 
        this.datasetTypes =
        {
            Chapter: "Chapter",
            Section: "Section",
            Procedure: "Procedure"
        }

        this.datasets = {
            chapters: [],
            sections: [],
            procedures: []
        };

        this.subArrayPropertyNames =
        {
            Procedures: "Procedures",
            Sections: "Sections"
        }

        this.getChapters = function () {
            var deferred = $q.defer();

            $http.get(baseUrl + 'list/')
                .success(function (dt) {
                    deferred.resolve(dt);
                })
                .error(function (data, status) {
                    deferred.reject();
                });
            return deferred.promise;
        };

        this.populateDatasets = function (chapters) {
            var datasetTypes = this.datasetTypes;
            this.datasets.chapters = _.uniq(_.map(chapters,
                function (chapter) {
                    return { Id: chapter.Id, Value: chapter.Name, Type: datasetTypes.Chapter };
                }));
            var sections = _.flatten(_.pluck(chapters, this.subArrayPropertyNames.Sections));
            this.datasets.sections = _.uniq(_.map(sections,
                function (section) {
                    return { Id: section.Id, Value: section.Name, Type: datasetTypes.Section };
                }));
            this.datasets.procedures = _.uniq(_.map(_.flatten(_.pluck(sections, this.subArrayPropertyNames.Procedures)),
                function (procedure) {
                    return { Code: procedure.Code, Value: procedure.Description, Type: datasetTypes.Procedure };
                }), false, function (item) {
                    return item.Code;
                });
        };

        this.searchDatasets = function (sourceName, key, text) {
            text = (text || "").toLowerCase();

            return _.sortBy(this.datasets[sourceName].filter(function (item) {
                return item[key].toLowerCase().indexOf(text) > -1;
            }), key);
        };
    }]);
