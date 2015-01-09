var CommunityManagerAcceso = function () {
    var init = function() {
        setDocumentEvents();
    },
        setDocumentEvents = function() {
            var loginButton = $(loginButtonSelector);
            loginButton.on('click', submitLoginForm);
            $(emailInputSelector + ", " + passwordInputSelector).on("keypress", submitLoginOnEnterPress);
        },
        submitLoginForm = function() {
            var form = $(formSelector);
            if (!form.valid()) return false;

            CommunityManagerBase().ShowLoadingLogin($(loadingLoginSelector), "ingresando", form, "232px", "191px");
            $.post("/Acceso/Autentificar", form.serialize(), function(data) {
                if (data.result == "Redirect") console.log(data.url);
                //if (data.result == "Redirect") window.location = data.url;
                else {
                    var loginBox = $(loginBoxSelector);
                    form.remove();
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
        loginBoxSelector = ".login-box",
        loginButtonSelector = "#LoginButton",
        formSelector = "#LoginForm",
        loadingLoginSelector = "#LoadingLogin",
        emailInputSelector = "#Email",
        passwordInputSelector = "#Password";

    return {
        Init: init
    };
}