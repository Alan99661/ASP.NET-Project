
const Оbserver = new IntersectionObserver((entries) => {
    entries.forEach((entry) => {
        console.log(entry);
        if (entry.isIntersecting) {
            entry.target.classList.add("show");
        } else {
            entry.target.classList.remove("show");
        }
    });
});

const hiddenElements = document.querySelectorAll(
    ".hidden,.hidden_nav,.hidden_text,.hiddenS"
);
hiddenElements.forEach((el) => Оbserver.observe(el));






function SelectAppend(controllerRoute, appendId) {
    $(document).ready(function () {
        $.ajax({
            method: "get",
            url: controllerRoute,
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

function CreateTopgameCard(controllerRoute, appendId) {
    $.ajax({
        method: "get",
        url: controllerRoute,
        success: function (data) {
            console.log(data);
            if (data != null) {
                var htmlCard = '<div class="card" style="min-width: 29rem; min-height: 4rem;">' +
                    '<div class="card-header">' +
                    'Top Rated in:' +
                    '</div>' +
                    '<ul id="cardlist" class="list-group list-group-flush">' +
                    '</ul>' +
                    '</div>';
                $(appendId).append(htmlCard);
                $.each(data, function (i, item) {
                    var listHtml = '<a asp-action="GetById" asp-controller="Genre" asp-route-id="' + data[i].id + '" class="list-group-item list-group-item-action">' + data[i].name + '</a>';
                    $("#cardlist").append(listHtml);
                });
            }
        }
    });
}



