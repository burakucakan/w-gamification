/// <reference path="_references.js" />
var itemIndex = 0;
$(document).ready(function () {

    $('.cb').colorbox();

});

function AddNewVarietyField() {
    itemIndex = $('.categoryInput').length / 2;
    var htmlTemplate = "<input type=\"text\" id=\"CatalogVarieties[" + itemIndex + "].VarietyName\" name=\"CatalogVarieties[" + itemIndex + "].VarietyName\"  class=\"categoryInput mr20px\"/>" +
        "<input type=\"text\" id=\"CatalogVarieties[" + itemIndex + "].VarietyStock\" name=\"CatalogVarieties[" + itemIndex + "].VarietyStock\"  class=\"categoryInput mr20px\"/>" +
        "<input type=\"button\" class=\"addNewVariety\" value=\"+\" onclick=\"AddNewVarietyField()\" />" +
        "<input type=\"button\" class=\"removeVariety\" value=\"X\" onclick=\"RemoveVarietyField()\" />";
    var lastItem = $('.categoryInput').last();
    $('.addNewVariety').remove();
    $('.removeVariety').remove();
    $(htmlTemplate).insertAfter(lastItem);
}

function RemoveVarietyField() {

    $('.removeVariety').remove();
    $('.addNewVariety').remove();
    $('.categoryInput').eq($('.categoryInput').length - 1).remove();
    $('.categoryInput').eq($('.categoryInput').length - 1).remove();
    itemIndex = $('.categoryInput').length / 2;
    var lastItem = $('.categoryInput').last();
    if (itemIndex == 1)
        $("<input type=\"button\" class=\"addNewVariety\" value=\"+\" onclick=\"AddNewVarietyField()\" />").insertAfter(lastItem);
    else if (itemIndex > 1) {
        $("<input type=\"button\" class=\"addNewVariety\" value=\"+\" onclick=\"AddNewVarietyField()\" /><input type=\"button\" class=\"removeVariety\" value=\"X\" onclick=\"RemoveVarietyField()\" />").insertAfter(lastItem);
    }

}