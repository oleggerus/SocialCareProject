var DateFormat =
{
    LongDateTimeString: "ddd D MMM YY HH:mm",
    LongDateString: "ddd D MMM YY",
    ShortDateString: "D MMM YY",
    ShortDateStringUS: "dd/MM/yyyy",
    DateString: "dd-MM-yyyy",
    ShortTimeString: "HH:mm"
};

var Strings = {
    GeneralErrorMessage: "Error occured. Please try again"
};

function getLocalDate(date) {
    return moment.utc(date, DateFormat.LongDateTimeString).local().format(DateFormat.LongDateString);
}

function getLocalTime(date) {
    return moment.utc(date, DateFormat.LongDateTimeString).local().format(DateFormat.ShortTimeString);
}

function parseStringToLocalDateTime(date) {
    return getLocalDate(date) + " " + getLocalTime(date);
}

function getFullLocalDateTime(date) {
    return parseStringToLocalDateTime(moment(date).format('ddd d MMM YY HH:mm'));
}

ko.bindingHandlers.datePicker = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var unwrap = ko.utils.unwrapObservable;
        var dataSource = valueAccessor();
        var binding = allBindingsAccessor();
        var options = {
            keyboardNavigation: true,
            todayHighlight: true,
            autoclose: true,
            daysOfWeekDisabled: [0, 6],
            format: 'mm/dd/yyyy'
        };
        if (binding.datePickerOptions) {
            options = $.extend(options, binding.datePickerOptions);
        }
        $(element).datepicker(options);
        $(element).datepicker('update', dataSource());
        $(element).on("changeDate", function (ev) {
            var observable = valueAccessor();
            if ($(element).is(':focus')) {
                // Don't update while the user is in the field...
                // Instead, handle focus loss
                $(element).one('blur', function (ev) {
                    var dateVal = $(element).datepicker("getDate");
                    observable(dateVal);
                });
            }
            else {
                observable(ev.date);
            }
        });
        //handle removing an element from the dom
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).datepicker('remove');
        });
    },
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        $(element).datepicker('update', value);
    }
};


//############ Bootstrap Notify Template ############
var notifyTemplate =
    '<div data-notify="container" class="col-xs-10 col-sm-6 col-md-5 col-lg-3 alert alert-{0}" role="alert">' +
    '   <button type="button" aria-hidden="true" class="close" data-notify="dismiss">&times;</button>' +
    '   <span data-notify="icon"></span>' +
    '   <span data-notify="title">{1}</span>' +
    '   <span data-notify="message">{2}</span>' +
    '   <div class="progress" data-notify="progressbar">' +
    '       <div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
    '   </div> ' +
    '   <a href="{3}" target="{4}" data-notify="url"></a>' +
    '</div>';

var notify = {
    ok: function (msg) {
        $.notify({ icon: "glyphicon glyphicon-ok", message: msg },
            { type: "success", delay: 3000, z_index: 1080, placement: { align: "center" }, template: notifyTemplate });
    },
    info: function (msg) {
        $.notify({ message: msg }, { type: "info", placement: { align: "center" }, template: notifyTemplate });
    },
    fail: function (msg, keepOpen) {
        var delay = keepOpen ? 0 : 4000;
        var message = '<ul style="list-style-type: disc; padding-left: 20px; margin: 0;">';

        if ($.isArray(msg) && msg.length > 1) {
            for (var i = 0; i < msg.length; i++) {
                message += "<li>" + msg[i] + "</li>";
            }
            message += "</ul>";

        } else {
            message = $.isArray(msg) && msg[0] ? msg[0] : msg;
        }

        $.notify({ message: message }, { type: "danger", delay: delay, z_index: 1080, placement: { align: "center" }, template: notifyTemplate });
    },
    failModelState: function (modelState) {
        notify.close();
        var errors = [];

        $.each(modelState, function (key) {
            $.each(modelState[key], function (item, val) {
                errors.push(val);
            });
        });

        notify.fail(errors, true);
    },
    close: function () {
        $.notifyClose();
    }
};




//Bootbox defaults
$(function () {
    if (window.bootbox) {
        bootbox.addLocale('en',
            {
                OK: "OK",
                CANCEL: "Відмінити",
                CONFIRM: "Підтвердити"
            });
        $(document).on("show.bs.modal", function (e) {
            if (window.notify) {
                notify.close();
            }
        });
    }
});