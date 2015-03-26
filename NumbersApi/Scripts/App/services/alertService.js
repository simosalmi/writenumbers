"use strict";

app.service('alertService', ['$timeout', function ($timeout) {
    var _fn;
    this.visible = false;
    this.title = "";
    this.message = "";
    this.level;

    var self = this;

    this.show = function(level, title, message, hideAfterSecs) {
        self.title = title;
        self.message = message;
        self.level = level;        
        self.visible = true;
        self.onShow()();
        if (hideAfterSecs) {
            $timeout(this.hide, hideAfterSecs*1000);
        }
    };

    this.onShow = function (fn) {
        if (fn) {
            _fn = fn;
        }        
        if (_fn) {
            return _fn;
        }
        else {
            return function () {
                //noop
            };
        }
    }

    this.hide = function () {
        self.title = "";
        self.message = "";
        self.visible = false;
    };    
}]);