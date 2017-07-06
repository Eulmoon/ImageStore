$(document).ready(
    function () {
        'use strict';
        $('input:file').change(
            function () {
                $('input:submit').attr('disabled', true);
                var f = this.files[0];
                var Errorm = [];
                var ext = this.value.match(/\.(.+)$/)[1];
                if (f) {
                    $('#ErrorText').hide();
                }
                if (f && (f.size > 20971520)) {
                    Errorm.push('File above the limit (20MB)');
                    $('#Maxsizeallow').show();
                }
                else {
                    $('#Maxsizeallow').hide();
                }
                if (f && $.inArray(ext, ['gif', 'png', 'jpg', 'jpeg']) == -1) {
                    Errorm.push('File type not allowed');
                    $('#mimetypeallow').show();
                }
                else {
                    $('#mimetypeallow').hide();
                }
                if (Errorm.length > 0) {
                    alert(Errorm.join("\n"));                   
                }
                else {
                    $('input:submit').attr('disabled', false);
                }
            }
        );
    });
