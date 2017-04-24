function showPopover(dica) {

    $('#' + dica).popover('show');

}

function hidePopover(dica) {

    $('#' + dica).popover('hide');

}

function changePopover(dica) {

    var msg = $('#' + dica).attr("data-content");

    if (msg == "Clique para ocultar os filtros!")
    {
        msg = "Clique para acessar os filtros!";

    } else {

        msg = "Clique para ocultar os filtros!";
    }

    $('#' + dica).attr("data-content", msg);
}