
$(document).ready(function () {
	StartProcessing();
	$.ajax({
		url: '/State/GetAllState',
		method: 'GET',
		data: {},
		success: function (response) {
			StopProcessing();
			$.each(response, function (index, item) {
				$('#txt_StateCode').append('<option value="' + item.value + '">' + item.text + '</option>');
			});
		}
	})
}) 

$('.go').click(function () {
    //debugger;
	var stateCode = $('#txt_StateCode').val();
	var statename = $('#txt_StateCode option:selected').text();
	if (stateCode == "0") {
		Swal.fire('',"Please Select Any State",'error');
		$('#txt_StateCode').focus();
	}
	else {
		StartProcessing();
		window.location.href = "/State/Detail?state_code=" + stateCode + "&statename=" + statename;
	}
})


