function RegistrarPronosticoPartido(jsonDato) {

    sendDataController("PartidoPorJornada", jsonDato, function (result) {

        location.href = '@Url.Action("PronosticoXCanal","Home")?idCanal='+1;
    });
}
