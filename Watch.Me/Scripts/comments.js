﻿var defaultAvatar = 'http://i.imgur.com/BDuNOi3.png';
var guestuserId = Math.floor(Math.random() * (150 - 10 + 1)) + 10;
var guestusername = '';

function stopLoader() {
    $('.loader').fadeOut('slow', function () {
        $('.comments .inner').fadeIn('slow');
    });
}

$(function () {
    /*
    You can paste here PHP code block to catch all comments
    (or connect it with JSON, if you know how)
    Example:
    <?php
      while($data = mysqli_fetch_object($comments_query)) {
          echo '{';
          echo "userid: {$data->userID}, name: {$data->username}... and so on";
          echo '},';
      }
    ?>
    */

    var allComments = [{
        userid: '1',
        name: 'Tester 1',
        avatar: 'default',
        before: '5 minutes before',
        message: 'That is cool!'
    }, {
        userid: '2',
        name: 'Chuck Norris',
        avatar: 'http://i.imgur.com/Nl7oXdq.png',
        before: '15 minutes before',
        message: 'I can totally say, that is not good as me, but whatever.'
    }, {
        userid: '3',
        name: 'Demo',
        avatar: 'default',
        before: '30 minutes before',
        message: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin condimentum non justo ut accumsan. Pellentesque hendrerit vitae urna at faucibus.'
    }];
    var loaded = 0;

    $.each(allComments, function (i, val) {
        var comment = $('<div class="comment"></div>');
        var avatar = this.avatar == 'default' ? defaultAvatar : this.avatar;
        $('<img class="avatar" alt="avatar" src="' + avatar + '" />').appendTo(comment);
        var contents = $('<div class="body"></div>');
        $('<a href="./users/' + this.userid + '/" target="_blank">' + this.name + '</a>').appendTo(contents);
        $('<span> • ' + this.before + '</span><br /><br />').appendTo(contents);
        $('<p>' + this.message + '</p>').appendTo(contents);

        contents.appendTo(comment);
        comment.appendTo('.comments .inner');
        loaded++;
    });

    if (loaded == allComments.length) stopLoader();

    $('.send-msg').click(function () {
        var name = $('.your-name').val();
        var msg = $('.your-msg').val();
        var comment = $('<div class="comment" style="display: none;"></div>');
        var contents = $('<div class="body"></div>');

        if ((name == '' && guestusername == '') || msg == '') return false;
        guestusername = guestusername == '' ? name : guestusername;
        $('.your-msg').val("");

        $('.your-name').fadeOut().remove();
        $('.your-msg').before('<div class="input your-name dived">' + guestusername + '</div>');

        $('<img class="avatar" alt="avatar" src="' + defaultAvatar + '" />').appendTo(comment);
        $('<a href="./users/' + guestuserId + '/" target="_blank">' + guestusername + '</a>').appendTo(contents);
        $('<span> • Right now</span><br /><br />').appendTo(contents);
        $('<p>' + msg + '</p>').appendTo(contents);

        contents.appendTo(comment);
        $('.add-new').after(comment);
        comment.fadeIn('slow');
    });
});