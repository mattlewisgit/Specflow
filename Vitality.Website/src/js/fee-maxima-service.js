angular
   .module("FeemaximaService", [])
   .service("FeemaximaService", ["$q", "$http", function ($q, $http) {
       "use strict";
       var action = "/api/bsl/post?bslendpoint=";
       var feedSettings = window.angularData.feedSettings;

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
           $http.post(action + encodeURIComponent(feedSettings.Endpoint),
                { MockDataFile: encodeURI(feedSettings.MockDataFile), FeedType: feedSettings.FeedType })
               .success(function (dt) {
                   deferred.resolve(dt.BslResponse);
               })
               .error(function () {
                   deferred.reject();
               });
           return deferred.promise;
       };

       this.populateDatasets = function (chapters) {
           var datasetTypes = this.datasetTypes;
           this.datasets.chapters = _.uniq(_.map(chapters,
               function (chapter) {
                   return { Id: chapter.Id, Value: _.unescape(chapter.Name), Type: datasetTypes.Chapter };
               }));
           var sections = _.flatten(_.pluck(chapters, this.subArrayPropertyNames.Sections));
           this.datasets.sections = _.uniq(_.map(sections,
               function (section) {
                   return { Id: section.Id, Value: _.unescape(section.Name), Type: datasetTypes.Section };
               }));
           this.datasets.procedures = _.uniq(_.map(_.flatten(_.pluck(sections, this.subArrayPropertyNames.Procedures)),
               function (procedure) {
                   return { Code: procedure.Code, Value: _.unescape(procedure.Description), Type: datasetTypes.Procedure };
               }), false, function (item) {
                   return item.Code;
               });
       };


       this.searchDatasets = function (sourceName, text, searchKey1, searchKey2) {
           text = (text || "").toLowerCase();

           return _.sortBy(this.datasets[sourceName].filter(function (item) {
               if (searchKey2 == null) {
                   return item[searchKey1].toLowerCase().indexOf(text) > -1;
               } else {
                   return item[searchKey1].toLowerCase().indexOf(text) > -1 ||
                      item[searchKey2].toLowerCase().indexOf(text) > -1;
               }
           }), searchKey1);
       };
   }]);
