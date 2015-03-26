"use strict";

app.service('numbersService', ['$q', '$resource', function ($q, $resource) {
    var NumberWriter = $resource('/api/numbers/writenumber',
     {}, {
         write: { method: 'POST' }
     });

    this.writeNumber = function (options) {
        var deferred = $q.defer();
        NumberWriter.write(options, function(data)
        {
            deferred.resolve(data);
        }, function (err) {
            deferred.reject(err);
        }
        );
        return deferred.promise;
    };    
}]);