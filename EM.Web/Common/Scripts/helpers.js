var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('EM');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);