(function () {
    $('document').ready(function () {
        preparePage();
    });

    function preparePage() {
        hideAllTabs();
        showDefaultTab();
    }

    function hideAllTabs() {
        var $tabcontainers = $('.tab-content');
        $tabcontainers.hide();
    }

    function showDefaultTab() {
        var $defaultTabButton = $('.tabs-nav .active');
        $defaultTabButton.trigger('click');
    }

    document.loadTab = function (ev, tabId) {
        var $button = $(ev.target);
        $('.tabs-nav .btn-tab').removeClass('active');
        $button.addClass('active');

        $('.tab-content').each(function (i, el) {
            var $element = $(el),
                elementId = $element.prop('id');

            if (elementId !== tabId) {
                $element.hide();
            } else {
                $element.show();
            }
        });        
    }
})();