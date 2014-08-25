var counter = 0;
var counter1 = 0;

function AddFileUpload() {
    var div = document.createElement('DIV');
    div.innerHTML = '<input id="file' + counter + '" name = "file' + counter + '" type="file" /><input id="Button' + counter + '" type="button" value="Remove" onclick = "RemoveFileUpload(this)" />';
    document.getElementById("FileUploadContainer").appendChild(div);
    counter++;
    if (counter == 3) {
        document.getElementById("btnAdd").style.visibility = "hidden";
        alert('u upload max 3 file');
    }
    if (counter < 3) {
        document.getElementById("btnAdd").style.visibility = "visible";

    }
    
}
function RemoveFileUpload(div) {
    document.getElementById("FileUploadContainer").removeChild(div.parentNode);
    counter--;
    if (counter == 3) {
        document.getElementById("btnAdd").style.visibility = "hidden";
        alert('u upload max 3 file');
    }
    if (counter < 3) {
        document.getElementById("btnAdd").style.visibility = "visible";

    }
    
}

        
          function AddFileUpload1() {
              var div = document.createElement('DIV');
              div.innerHTML = '<input id="file' + counter1 + '" name = "file' + counter1 + '" type="file" /><input id="Button' + counter1 + '" type="button" value="Remove" onclick = "RemoveFileUpload1(this)" />';
              document.getElementById("FileUploadContainer1").appendChild(div);
              counter1++;
              if (counter1 == 1) {
                  document.getElementById("btnAdd1").style.visibility = "hidden";
                  alert('u upload max 1 file');
              }
              if (counter1 < 1) {
                  document.getElementById("btnAdd1").style.visibility = "visible";

              }
              
          }
          function RemoveFileUpload1(div) {
              document.getElementById("FileUploadContainer1").removeChild(div.parentNode);
              counter1--;
              if (counter1 == 1) {
                  document.getElementById("btnAdd1").style.visibility = "hidden";
                  alert('u upload max 1 file');
              }
              if (counter1 < 1) {
                  document.getElementById("btnAdd1").style.visibility = "visible";

              }

          }


          function removeallpan2(div) {
              while (counter1>=1) {
                  document.getElementById("FileUploadContainer1").removeChild(div.parentNode);
                  counter--;
              }
          }
          
          function removeallpan1(div) {
              while (counter>=1) {
                  RemoveFileUpload(div);
              }

          } 