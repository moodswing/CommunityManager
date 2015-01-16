var CommunityManagerBase = function () {
    var init = function () {
        $(document).on("submit", "form", cleanErrorSummary);
        $(document).on("change, blur", "form input", function () { validateForm($(this)); });
        $(document).on("ajax:complete", "form", reBindFormsValidations);
        $(document).ajaxComplete(reBindFormsValidations);
    },
        reBindFormsValidations = function (event, xhr) {
            var formElement = $(xhr.responseText).find("form").addBack("form");
            if (formElement.length == 0) return;
            formElement.each(function () {
                var form = $("#" + $(this).prop("id"));
                
                form.removeData("validator");
                form.removeData("unobtrusiveValidation");
                $.validator.unobtrusive.parse(form);
            });
            
        },
        validateForm = function (validate) {
            var isValid = true;

            validate.each(function () {
                var input = $(this);
                if (input.is("[type=checkbox]")) return;
                if (!input.valid()) {
                    isValid = false;
                    var form = input.parents("form").first();

                    var requiredError;
                    for (var i = 0; i < form.validate().errorList.length; i++) {
                        var error = form.validate().errorList[i];
                        if (error.element == input[0] && error.message.indexOf("required") > -1)
                            requiredError = true;
                    }
                    
                    if (requiredError) input.next(".field-validation-error").hide();
                    else input.next(".field-validation-error").show();
                }
            });

            return isValid;
        },
        cleanErrorSummary = function (form) {
            console.log(form);
            form.find(".validation-summary-errors").remove();
        },
        showLoadingLogin = function (target, texto, hideElement, width, height) {
            if (hideElement != null) hideElement.hide();

            target.html("<div id='loading' style='padding-bottom: 5px;" +
                (height != null ? "height: " + height + ";" : "") + (width != null ? "width:" + width + ";" : "") +
                (height != null ? "display: table-cell; vertical-align: middle;" : "") + "'>" +
                "<div class='bubblingG' style='margin: auto;'><span id='bubblingG_1'>" +
                "</span><span id='bubblingG_2'></span><span id='bubblingG_3'></span></div><div style='text-align: center;'>" + texto + "</div></div>");
            target.show();
        };

    return {
        Init: init,
        ShowLoadingLogin: showLoadingLogin
    };
}