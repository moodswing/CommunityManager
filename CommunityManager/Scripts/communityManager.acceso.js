var CommunityManagerAcceso = function () {
    var init = function() {
        setDocumentEvents();
    },
        setDocumentEvents = function() {
            $(loginButtonSelector).on('click', submitLoginForm);
            $(enterDataButtonSelector).on('click', submitEnterDataForm);
            $(emailInputSelector + ", " + passwordInputSelector).on("keypress", submitLoginOnEnterPress);
            $(enterDataFormSelector + " input").on("keypress", submiAccesstDataOnEnterPress);
        },
        submitLoginForm = function() {
            var form = $(loginFormSelector);
            if (!form.valid()) return false;

            CommunityManagerBase().ShowLoadingLogin($(loadingLoginSelector), "ingresando", form, "232px", "191px");
            $.post("/Acceso/Autentificar", form.serialize(), function(data) {
                if (data.result == "Redirect") window.location = data.url;
                else {
                    var loginBox = $(loginBoxSelector);
                    $(loadingLoginSelector).hide();
                    loginBox.html(data);
                    setDocumentEvents();
                } 
            });

            return false;
        },
        submitEnterDataForm = function() {
            var form = $(enterDataFormSelector);
            if (!form.valid()) return false;

            CommunityManagerBase().ShowLoadingLogin($(loadingLoginSelector), "ingresando", form, "232px", "191px");
            $.post("/Acceso/IngresarDatos", form.serialize(), function(data) {
                if (data.result == "Redirect") window.location = data.url;
                else {
                    var loginBox = $(loginBoxSelector);
                    loginBox.html(data);
                    setDocumentEvents();
                    $(loadingLoginSelector).hide();
                }
            });

            return false;
        },
        submitLoginOnEnterPress = function (e) {
            if (e.which == 13) submitLoginForm();
        },
        submiAccesstDataOnEnterPress = function (e) {
            if (e.which == 13) submitEnterDataForm();
        },
        loginBoxSelector = ".login-box",
        loginButtonSelector = "#LoginButton",
        loginFormSelector = "#LoginForm",
        enterDataFormSelector = "#EnterDataForm",
        loadingLoginSelector = "#LoadingLogin",
        emailInputSelector = "#Email",
        passwordInputSelector = "#Password",
        enterDataButtonSelector = "#EnterDataButton";

    return {
        Init: init
    };
}