$(document).ready(function () {

    $('[zyf-new-category-submit]').on('click', function (event) {
        event.preventDefault();
        var $this = $(this),
            $form = $this.parents("form");
        if (!$form.valid()) {
            return false;
        }
    })

   

});