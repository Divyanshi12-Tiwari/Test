$(document).ready(function () {
    var statecode = $('#statecode').val();
    var titleid = parseInt($('#titleid').val());
    StartProcessing();
    $.ajax({
        url: '/Annotation/GetAnnotationDetailByStateTitle',
        method: 'GET',
        data: {
            'StateCd': statecode,
            'TitleID': titleid
        },
        success: function (response) {
            StopProcessing();
            var divisionDescList = [];
            $('Annotation').append('<h1 class="headertitle">' + response[0].displayLabelForWeb + ' ' + response[0].titleNum + ' ' + response[0].titleDesc + '</h1>');
            $.each(response, function (index, item) {
                if (item.divisionDesc == 'CHAPTER') {
                    /* $('Annotation').append('<h1 class="headertitle">' + item.displayLabelForWeb + ' ' + item.titleNum + ' ' + item.titleDesc + '</h1>');*/
                    $('Annotation').append('<h2 class="headertitle">' + item.divisionHeaderlText + '</h2>');
                }

                if (item.divisionDesc == 'PART') {
                    $('Annotation').append('<h3 class="headertitle">' + item.divisionHeaderlText + '</h3>');
                }

                if (item.divisionDesc == 'SECTION') {
                    $('Annotation').append('<br /><div class="media-left sectionItem1"><u><a href="/Annotation/AnnotationDetail?divisionid=' + item.divisionID
                        + '">' + item.divisionHeaderlText + '</a></u><strong> -' + item.numAnnotations + ' annotations' + ' -' + item.annotationLastUserUpdate + '</strong></div>');
                }


                //if (item.divisionDesc == "CHAPTER") {
                //    if (!(divisionDescList.includes(item.divisionDesc))) {
                //        divisionDescList.push(item.divisionDesc);
                //        $('Annotation').append('<h3 class="headertitle">' + item.displayLabelForWeb + ' ' + item.titleNum + ' ' + item.titleDesc + '</h3>');
                //    }
                //}
            });

            //LoadDataTable(response);
        }
    })
})



$('.CreateAnnotation ').click(function () {
    $('#myModal').modal('show');
    $('#btnid').text('Create');
    $('#txtheading').text('Create Annotation');
    $('#txt_casename').val(' ');
    $('#txt_caselink').val(' ');
    $('#txt_citation').val(' ');
    $('#txt_blurb').val(' ');
})


$('.EditAnnotation').click(function () {
    debugger;
    $('#myModal').modal('show');
    $('#btnid').text('Save Changes');
    $('#txtheading').text('Edit Annotation');
    $('#txt_casename').val('801 S.E. 2d 225,239 W.Va. 347 (2017)');
    $('#txt_caselink').val('Lawyer Disciplinary Bd.v.Plants,');
    $('#txt_citation').val('SecMain III');
    $('#txt_blurb').val('I want to change this one for some prospectives.');
})



$('.DeleteAnnotation').click(function () {
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
            Swal.fire(
                'Deleted!',
                'Your file has been deleted.',
                'success'
            )
        }
    })
})


$('.CloseModal').click(function () {
    $('#myModal').modal('hide');
})


function LoadDataTable(dataSet) {
    $('#example').DataTable({
        "scrollX": true,
        destroy: true,
        "processing": true,
        "aaSorting": [],
        data: dataSet,
        columns: [
            {
                data: 'displayLabelForWeb',
                render: function (data, type, row, meta) {
                    return '<span title="' + data + '">' + data + '</span>';
                }
            },
            {
                data: 'divisionDesc',
                render: function (data, type, row, meta) {
                    return '<span title="' + data + '">' + data + '</span>';
                }
            },
            {
                data: 'titleDesc',
                render: function (data, type, row, meta) {
                    return '<span title="' + data + '">' + data + '</span>';
                }
            },
            {
                data: 'divisionHeaderlText',
                render: function (data, type, row, meta) {
                    return '<span title="' + data + '">' + data + '</span>';
                }
            },
            {
                data: 'divisionHeaderHTML',
                render: function (data, type, row, meta) {
                    return '<span title="' + data + '">' + data + '</span>';
                }
            },
            {
                data: 'divisionHeaderHTML',
                render: function (data, type, row, meta) {
                    return ' <input type="button" class="EditAnnotation btn btn-sm" value="Edit" style="background-color:#306fb0;color:white;margin-top: -24%;" /> </br> &nbsp; <input type="button" class="DeleteAnnotation btn btn-sm" value="Delete" style="background-color:#306fb0;color:white;margin-top: -24%;" onclick="Delete(this)" />';
                }
            }
        ]
    });
}