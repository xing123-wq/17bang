function JqueryAjaxError(jqXHR, textStatus, errorThrown) {
    /* ---- DEBUG时使用 ---- */

    showModal("错误信息",
        "<span class='fa fa-exclamation-triangle text-warning'></span> JQuery Ajax请求发生错误，请稍后再试或联系管理员，以下为错误信息：\n" +
        jqXHR.responseText + "\n" +
        "status:" + textStatus + "\n" +
        "error:" + errorThrown);

    /* ---- DEBUG时使用 ---- */

    //showModal(getWarningIcon() + ' Ajax请求错误',
    //    '<p>( ⊙ o ⊙ ) 咦？出现了AJAX请求错误。我们已经记录了该问题，如果需要的话，还可能会联系你了解详细的情况。</p>' +
    //    '<p>如果这不是爬虫惹的祸，你也可以主动地 <a href="/Contact/Us"><span class="fa fa-fax"></span> 直接联系我们</a>，或者通过 <a href="/Suggest/New"><span class="fa fa-flag"></span> 提交反馈建议</a>，向我们报告这个错误。</p>');
}
function showModal(title, body, nofooter) {
    $modal = $("[zyf-global-modal]");
    $modal.find(".modal-title").html(title);
    $modal.find(".modal-body").html(body);
    if (nofooter) {
        $modal.find(".modal-footer").remove();
    }
    $modal.modal("show");
}