var timer
$("#lbl_buhin").mouseup(function () {
	clearInterval(timer);
}).mousedown(function () {
	timer = setTimeout(function () {
		if ($("#btn_next").prop("disabled") == true) {
			$("#btn_next").prop("disabled", false);
		}
		else {
			$("#btn_next").prop("disabled", true);
		};
	}, 2000);
});

$(".touch").mousedown(function () {
	//alert("touch!!")
	//id取得
	console.log($(this).attr("id"));
	//値取得
	console.log($(this).attr("id"));
});
