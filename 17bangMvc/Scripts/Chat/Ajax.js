function moveRight($dom) {
    $dom.addClass('text-right');
    $dom.find('[zyf-chat-reply-btn]').addClass('invisible');
}
$(document).ready(function () {

    $('[zyf-chat-author-id]').each(function () {
        if ($(this).attr('id') === $.cookie('UserId')) {
            moveRight($(this).parent('div'));
        }
    });


    var timeOut = 2000,
        refreshHanderId = 0;
    $('[zyf-chat-send]').click(function () {
        var content = $('[zyf-chat-send-content]').val();
        if (content) {
            var id = $('[zyf-chat-reply-reminder]').attr('id');
            $.ajax({
                method: 'POST',
                data: { 'Content': content, 'ReplyId': id },
                url: '/Chat/Room',
                success: function (data) {
                    $('[ zyf-chats-items-container]').append(data);
                },
                complete: function () {
                    $('[zyf-chat-send-content]').val('');
                    $('[zyf-chat-reply-reminder]').text('');
                    clearTimeout(refreshHanderId);
                    refreshChat(timeOut);
                }
            })
        } else {
            alert('* 内容不能为空')
            return false;
        }
    })
    $('[zyf-chat-reply-btn]').on('click', function () {
        var id = $(this).attr('id');
        var contents = $(this).parent().find('[zyf-chat-item-content]').text();
        $('[zyf-chat-reply-reminder]').removeAttr('hidden').attr('id', id).text(contents);
        clearTimeout(refreshHanderId);
        refreshChat(timeOut);
    })

    function refreshChat(timeOut) {
        refreshHanderId = setTimeout(function () {
            var id = $('[zyf-chat-item-id]').last().val();
            $.ajax({
                url: '/Chat/Room?id=' + id,
                method: 'GET',
                success: function (data) {
                    $('[ zyf-chats-items-container]').append(data);
                }
            })
            timeOut += 100;
            if (timeOut <= 60000) {
                refreshChat(timeOut);
            } else {
                alert("longtime you was doing nothing ,now system will break connect. if you wanna connect again ,please refresh current page");
                clearTimeout(refreshHanderId);
            }
        }, timeOut);
    }

    $('[zyf-ad-chats]').css('top', 120);
    $(document).scroll(function () {
        var top = $(document).scrollTop();
        if (top < 300) {
            top = 120;
        }
        else {
            top = 300 - top;
        }
        $('[zyf-ad-chats]').css('top', top);
    })
})
