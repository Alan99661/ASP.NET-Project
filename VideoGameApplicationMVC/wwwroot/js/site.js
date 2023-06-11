function SelectGames(appendId) {
    $(document).ready(function () {
        $.ajax({
            method: "get",
            url: "/Game/GetGameSelectModel",
            success: function (data) {
                console.log(data);
                $.each(data, function (i, item) {
                    var html = '<option value="' + data[i].id + '">' + data[i].name + '</option>';
                    console.log(html);
                    $(appendId).append(html);
                })
            }
        });
    });
};
