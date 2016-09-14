function kGridSearch(ds, e, availableFilters) {

    var searchTerm = e.currentTarget.value;

    if (searchTerm.length === 0) {

        if (availableFilters != null) {
            var filters = { logic: 'or', filters: [] };

            for (var i = 0; i < availableFilters.Categories.length; i++) {
                filters.filters.push({ "field": "CatalogCategoriesId", "operator": "eq", "value": parseInt(availableFilters.Categories[i].Id) });
            }

            ds.filter(filters);
        }
        else {
            ds.filter({});
        }
        return false;
    }
    else {
        var fields = ds.options.schema.model.fields;
        var innerFilters = [];

        for (var key in fields) {

            if (!fields.hasOwnProperty(key) || fields[key].type != 'string') continue;

            innerFilters.push({
                field: key,
                operator: 'contains',
                value: searchTerm
            });
        }

        var filters = { logic: 'or', filters: innerFilters };

        //if (availableFilters != null) {
        //    for (var i = 0; i < availableFilters.Categories.length; i++) {
        //        filters.filters.push({ "field": "CatalogCategoriesId", "operator": "contains", "value": availableFilters.Categories[i].Id.toLowerCase() });
        //    }
        //}

        console.log(filters);

        ds.filter(filters);

        return false;
    }
}




(function ($) {

    $.fn.kendoDdlVal = function (value) {
        $(this).val(value);
        var ddl = this.data("kendoDropDownList");
        ddl.value(value);
    };

    $.fn.kendoDdlRender = function () {
        var ddl = this.data("kendoDropDownList"),
            popup = ddl.popup,
            element = popup.wrapper[0] ? popup.wrapper : popup.element;

        //remove popup element;
        element.remove();

        //unwrap element
        ddl.element.show().insertBefore(ddl.wrapper);
        ddl.wrapper.remove();

        ddl.element.removeData("kendoDropDownList");

        this.kendoDropDownList();
        setWidth(this);
    };

})(jQuery);

function setWidth(el) {
    var d = el;
    var p = d.data("kendoDropDownList").popup.element;
    var w = p.css("visibility", "hidden").show().outerWidth();
    p.hide().css("visibility", "visible");
    d.closest(".k-widget").width(w);
}