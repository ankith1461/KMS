$(document).ready(function () {
 $("#btnUserPublishedUpdate").click(function () {

           if ($("input[id$='txtCollectionName']").val() == '')
            alert('Collection Name Should not be blank');
        if ($("input[id$='txtTagName']").val() == '')
            alert('Tag Name Should not be blank');
             if ($("input[id$='txtTitle']").val() == '')
            alert('Title  Should not be blank');
         if ($("input[id$='editorDetails']").val() == '')
             alert('Details Should not be Blank');
         //var newVal1 = $("#txtTitle").val();
           //      var quantityRegexp1 =/^[\d\W\w]{1,500}$/;
             //    if (!(quantityRegexp.test(newVal)))
             //        alert('Maximum 500 Character  Should be there in Title');


     });
 

