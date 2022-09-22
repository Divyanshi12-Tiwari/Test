
$(document).ready(function () {
    StartProcessing();
    $.ajax({
        url: '/Annotation/GetAnnotationDetailByDivisionId',
        method: 'GET',
        data: {
            'divisionID': parseInt($('#divisionID').val())
        },
        success: function (response) {
            StopProcessing();
            var annotationList = response.annotationList;
            var annotationStatus = response.annotationStatus;
            if (annotationList.length > 0) {
               
                $('Annotation').append('<h1 class="headertitle">' + annotationList[0].displayLabelForWeb + ' ' + annotationList[0].titleNum + ' ' + annotationList[0].titleDesc + '</h1>');
                $('Annotation').append('<br /><div class="media-left sectionItem1"><b>' + annotationList[0].divisionHeaderlText + '</b></div>');

                var ddlStatus = '<br /><b>Division Status:</b> &nbsp;&nbsp;&nbsp;<select id="editstatus" class="selectbox editstatus">';
                //$.each(annotationStatus, function (index, item) {
                //    if (item.value == status)
                //        ddlStatus += '<option value="' + item.value + '" selected>' + item.text + '</option>';
                //    else
                //        ddlStatus += '<option value="' + item.value + '">' + item.text + '</option>';
                //});
                ddlStatus += '</select><br />';
                $('Annotation').append(ddlStatus);
                $('Annotation').append('<input type="button" value="Add New Annotation" class="btn  AddAnnotation"/>');

                $('Annotation').append('<br />');
                $.each(annotationList, function (index, item) {
                    //if (item.divisionDesc == 'CHAPTER') {
                    //    $('Annotation').append('<br />' + (index + 1) + '.&nbsp;<u><a href="#">' + item.caseName + '</a></u>&nbsp;' + item.citation);
                    //    $('Annotation').append('<input type="button" class="btn-sm btn-info EditAnnotation" style="font-weight:bold;" annotationid=' + item.annotationID + ' value="Edit" />');
                    //    $('Annotation').append('<button class="btn-sm btn-primary" style="font-weight:bold;">Delete</button>');
                    //    $('Annotation').append('<br /><span class="headertitle" style="font-family:calibri;">' + item.caseBlurb + '</span><br />');
                    //}

                    //if (item.divisionDesc == 'PART') {
                    //    $('Annotation').append('<br />' + (index + 1) + '.&nbsp;<u><a href="#">' + item.caseName + '</a></u>&nbsp;' + item.citation);
                    //    $('Annotation').append('<input type="button" class="btn-sm btn-info EditAnnotation" style="font-weight:bold;" annotationid=' + item.annotationID + ' value="Edit" />');
                    //    $('Annotation').append('<a href="#" style="margin-left:2rem;"><button class="btn-sm btn-primary" style="font-weight:bold;">Delete</button>');
                    //    $('Annotation').append('<br /><span class="headertitle" style="font-family:calibri;">' + item.caseBlurb + '</span><br />');
                    //}

                    if (item.divisionDesc == 'SECTION') {
                        $('Annotation').append('<br /><b>' + (index + 1) + '.</b>&nbsp;&nbsp;<u><a href="#">' + item.caseName + '</a></u>,&nbsp;' + item.citation);
                        $('Annotation').append('<a href="javascript:void()" target="_self" data-casename="' + item.caseName + '" data-caselink="' + item.caseLink + '" data-citation="' + item.citation + '" data-blurb="' + item.caseBlurb + '" class="btn-sm btn-info EditAnnotation"  annotationid=' + item.annotationID + '>Edit</a>');
                        $('Annotation').append('<a href="javascript:void()" class="btn-sm btn-danger DeleteAnnotation"  annotationid=' + item.annotationID + '>Delete</a>');
                        $('Annotation').append('<br /><span class="headertitle" style="font-family:calibri;">' + item.caseBlurb + '</span><br />');
                    }

                });
            }


            else {
                var ddlStatus = '<br /><b>Division Status:</b> &nbsp;&nbsp;&nbsp;<select id="editstatus" class="selectbox editstatus">';
         
                ddlStatus += '</select><br />';
                $('Annotation').append(ddlStatus);
                $('Annotation').append('<input type="button" value="Add New Annotation" class="btn  AddAnnotation"/>');

            }
            BindDivisionStatus(annotationStatus);

        }
    })
})

$('body').on('click', '.CloseModal', function () {
    $('#myModal').hide();
})

function BindDivisionStatus(annotationStatus) {
    var ddlStatus = '';
    $.each(annotationStatus, function (index, item) {
        if (item.isChecked)
            ddlStatus += '<option value="' + item.id + '" selected>' + item.status + '</option>';
        else
            ddlStatus += '<option value="' + item.id + '">' + item.status + '</option>';
    });
    $('.editstatus').html(ddlStatus);
}

$('body').on('change', '.editstatus', function () {
    StartProcessing();
    $.ajax({
        url: '/Annotation/UpdateDivisionStatus',
        method: 'POST',
        data: {
            'editStatusId': $(this).val(),
            'divisionID': parseInt($('#dividionID').val())
        },
        success: function (response) {
            StopProcessing();
            //BindDivisionStatus(response.annotationStatus)
        }
    })
})
$('body').on('click', '.SaveAnnotation', function () {
    StartProcessing();
    $.ajax({
        url: '/Annotation/UpdateAnnotationDetail',
        method: 'POST',
        data: {
            'annotationID': $('#txt_annotationid').val(),
            'caseName': $('#txt_casename').val(),
            'caseLink': $('#txt_caselink').val(),
            'citation': $('#txt_citation').val(),
            'blurb': $('#txt_blurb').val(),
            //'userID': $('#loggedinuserid').val(),
            //'userEmail': $('#loggedinmailid').val(),
            'divisionID': parseInt($('#dividionID').val())
        },
        success: function (updateresponse) {
            StopProcessing();
            if (updateresponse == true) {
                Swal.fire('', "Annotation Updated Successfully....", 'success');
                $('#myModal').hide();
            }
            else {
                Swal.fire('', "Some error occurred", 'error');
                $('#myModal').hide();
            }
        }
    })
})

$('body').on('click', '.AddAnnotation', function () {
    $('#myModal').show();
    $('#myModal').removeClass('modal-xl');
    $('#btnid').val('Add');
    $('#txtheading').text('Add Annotation');
    $('#btnid').removeClass('SaveAnnotation');
    $('#btnid').addClass('AddNewAnnotation');

    $('#txt_annotationid').val(' ');
    $('#txt_casename').val(' ');
    $('#txt_caselink').val(' ');
    $('#txt_citation').val(' ');
    $('#txt_blurb').val(' ');
})


$('body').on('click', '.AddNewAnnotation', function () {
   /* alert("Add Annotation");*/

    if ($('#txt_casename').val() == null || $('#txt_casename').val() == " ") {
        Swal.fire('', "Please Fill Case Name", 'error');
        $('#txt_casename').focus();
        return false;
    }
    else if ($('#txt_caselink').val() == null || $('#txt_caselink').val()==" ") {
        Swal.fire('', "Please Fill Case Link", 'error');
        $('#txt_caselink').focus();
        return false;
    }
    
    else if ($('#txt_citation').val() == null || $('#txt_citation').val() == " ") {
        Swal.fire('', "Please Fill Citation", 'error');
        $('#txt_citation').focus();
        return false;
    }
    
    else if ($('#txt_blurb').val() == null || $('#txt_blurb').val() == " ") {
        Swal.fire('', "Please Fill Blurb", 'error');
        $('#txt_blurb').focus();
        return false;
    }
    StartProcessing();
    $.ajax({
        url: '/Annotation/UpdateAnnotationDetail',
        method: 'POST',
        data: {
            'annotationID': $('#txt_annotationid').val(),
            'caseName': $('#txt_casename').val(),
            'caseLink': $('#txt_caselink').val(),
            'citation': $('#txt_citation').val(),
            'blurb': $('#txt_blurb').val(),
            //'userID': $('#loggedinuserid').val(),
            //'userEmail': $('#loggedinmailid').val(),
            'divisionID': parseInt($('#dividionID').val())

        },
        success: function (updateresponse) {
            StopProcessing();
            if (updateresponse == true) {
                Swal.fire('', "Annotation Added Successfully....", 'success');
                $('#myModal').hide();
            }
            else {
                Swal.fire('', "This annotation is already found. Please try to add another one.", 'error');
                $('#myModal').hide();
            }
        }
    })

})



//function BindAllData(no) {
//    $.each(function (no) {

//    })
//}


$('body').on('click', '.EditAnnotation', function () {
    debugger;


    $('#btnid').val('Save Changes');
    $('#txtheading').text('Edit Annotation');
    $('#btnid').removeClass('AddNewAnnotation');
    $('#btnid').addClass('SaveAnnotation');
    var annotationid = $('.EditAnnotation').attr('annotationid');
    $('#txt_annotationid').val(parseInt(annotationid));
    $('#txt_casename').val($(this).attr('data-casename'));
    $('#txt_caselink').val($(this).attr('data-caselink'));
    $('#txt_citation').val($(this).attr('data-citation'));
    $('#txt_blurb').val($(this).attr('data-blurb'));
    /*  setTimeout(showmodal,2000);*/
    $('#myModal').show();
    $('#myModal').addClass('modal-xl');
});

$('body').on('click', '.DeleteAnnotation', function () {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            StartProcessing();
            $.ajax({
                url: '/Annotation/DeleteAnnotation',
                method: 'GET',
                data: {
                    'annotationID': parseInt($('.DeleteAnnotation').attr('annotationid'))
                },
                success: function (deleteresponse) {
                    StopProcessing();
                    if (deleteresponse == true) {
                        Swal.fire('Deleted!', "Annotation Deleted Successfully....", 'success');
                    }
                    else {
                        Swal.fire('', "Some error occurred", 'error');
                    }
                }
            })
        }
    })
})