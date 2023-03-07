<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <style>
        body {
            padding: 0 20px;
            text-align: center;
        }
        
        .uploadBtn img {
            position: relative;
            width: 100px;
            height: 100px;
        }
        
        li.uploadBtn img[src=""] {
            display: none;
        }
        
        li.uploadBtn {
            width: 100px;
            height: 100px;
            position: relative;
            background: #f7f8f8;
        }
        
        .uploadBtn input[type="file"] {
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            opacity: 0;
            width: 100%;
            height: 100%;
        }
        
        a.removePic {
            position: absolute;
            top: 5px;
            right: 5px;
            z-index: 999;
            font-size: 18px;
            color: #000;
            display: none;
        }
        
        li.uploadBtn.add:before {
            content: '+';
            position: absolute;
            font-size: 28px;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div class="choose-imagefile-wrap">

        <div class="result">
            <div id='gal'>
                <ul class="gallery">
                    <li class="uploadBtn add">
                        <img class="img" src>
                        <input type="file">
                        <a href="javascript:void(0);" class="removePic">X</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
        </form>
</body>
<script>
    var count = 0;
    document.addEventListener('change', function(e) {
        var ele = e.target;
        if ($(e.target).is('input[type="file"]')) {
            var files = e.target.files;
            for (var i = 0; i < files.length; i++) {
                var file = files[i];
                if (file.type.match('image')) {
                    var picreader = new FileReader();
                    picreader.addEventListener("load", function(event) {
                        var picture = event.target;
                        showPreview(picture.result, ele);
                    });
                    picreader.readAsDataURL(file);
                }
            }
        } else {
            console.log('not file');
        }
    }, true);
    var count = 1;

    function showPreview(pic, ele) {
        ele.previousElementSibling.src = pic;
        ele.setAttribute('style', 'display:none;');
        ele.nextElementSibling.setAttribute('style', 'display:block;');
        ele.closest('li').classList.remove('add');
        if ($('.uploadBtn').length < 5) {
            $('.gallery').append(' <li class="uploadBtn add"><img class="img" src><input type="file"><a href="javascript:void(0);" class="removePic">X</a></li>');
            count = 1;
        } else {
            return false;
        }
    }
    $('body').on('click', '.removePic', function() {
        $(this).parents('.uploadBtn').remove();
        if ($('.uploadBtn.add').length) {
            return false;
        } else {
            $('.gallery').append(' <li class="uploadBtn add"><img class="img" src><input type="file"><a href="javascript:void(0);" class="removePic">X</a></li>');
        }

    });
</script>
    
</html>
