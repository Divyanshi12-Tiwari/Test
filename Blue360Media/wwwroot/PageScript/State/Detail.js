
$(document).ready(function () {
	StartProcessing();
	$.ajax({
		url: '/State/GetStateTitles',
		method: 'GET',
		data: {
			'stateCode': $('#state_id').val(),
		},
		success: function (response) {
			StopProcessing();
			LoadDataTable(response);
		}
	})
}) 


function LoadDataTable(dataSet) {
	var stateCode = $('#state_id').val();
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
				data: 'titleNum',
				render: function (data, type, row, meta) {
					return '<span title="' + data + '">' + data + '</span>';
				}
			},
			{
				data: 'titleDesc',
				render: function (data, type, row, meta) {
					return '<a href="/Annotation/Index?id=' + row.titleID + '&StateCode=' + stateCode +'">' + data + '<a>';
				}
			},
			{
				data: 'numAnnotations',
				render: function (data, type, row, meta) {
					return '<span title="' + data + '">' + data + '</span>';
				}
			},
			{
				data: '_AnnotationLastUpdatedDtm',
				render: function (data, type, row, meta) {
					return '<span title="' + data + '">' + data + '</span>';
				}
			},
			{
				data: 'annotationLastUserUpdate',
				render: function (data, type, row, meta) {
					return '<span title="' + data + '">' + data + '</span>';
				}
			},
        ]
    });
}