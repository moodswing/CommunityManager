var CommunityManagerPortada = function () {
    var init = function() {
        setDocumentEvents();
    },
        setDocumentEvents = function() {
            $(listaPublicacionesSelector).jScrollPane();
            $(document).on("click", publicacionSelector, mostrarPublicacion);
        },
        mostrarPublicacion = function() {
            var publicacionId = $(this).find(idPublicacionSelector).val();

            CommunityManagerBase().ShowLoadingLogin($(cargandoPublicacion), "cargando", $(publicacionContenedor));
            $.post("/Portada/CargarPublicacion", { id: publicacionId }, function (data) {
                if (data.result == "Redirect") window.location = data.url;
                else {
                    $(cargandoPublicacion).hide();
                    $(publicacionContenedor).html(data);
                    $(publicacionContenedor).show();
                    setDocumentEvents();
                }
            });

            return false;
        },
        listaPublicacionesSelector = ".summary-posts",
        publicacionSelector = ".summary-posts .container",
        idPublicacionSelector = "#Id",
        cargandoPublicacion = "#LoadingPublication",
        publicacionContenedor = ".post-container";

    return {
        Init: init
    };
}