var counter = 0;
function AddFileUpload() {
    var div = document.createElement('DIV');
    div.innerHTML = '<input id="file' + counter + '" name = "file' + counter + '" type="file" /><input id="Button' + counter + '" type="button" value="Remove" onclick = "RemoveFileUpload(this)" />';
    document.getElementById("FileUploadContainer").appendChild(div);
    counter++;
    if (counter == 3) {
        document.getElementById("Button1").style.visibility = "hidden";
        alert('u upload max 3 file');
    }
    if (counter < 3) {
        document.getElementById("Button1").style.visibility = "visible";

    }
}
        function RemoveFileUpload(div) {
            document.getElementById("FileUploadContainer").removeChild(div.parentNode);
            counter--;
            if (counter == 3) {
                document.getElementById("Button1").style.visibility = "hidden";
                alert('u upload max 3 file');
            }
            if (counter < 3) {
                document.getElementById("Button1").style.visibility = "visible";

            }
        }