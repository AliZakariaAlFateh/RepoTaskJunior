    var DateCreation = document.getElementsByClassName("DiasbledOldDate");
    var currentDate = new Date();

    var year = currentDate.getFullYear();
    var month = (currentDate.getMonth() + 1).toString().padStart(2, '0');
    var day = currentDate.getDate().toString().padStart(2, '0');
    var formattedDate = `${year}-${month}-${day}`;

    var hours = currentDate.getHours().toString().padStart(2, '0');
    var minutes = currentDate.getMinutes().toString().padStart(2, '0');
    var formattedTime = `${hours}:${minutes}`;

    DateCreation[0].setAttribute("min", `${formattedDate}`);
    DateCreation[1].setAttribute("min", `${formattedDate}T${formattedTime}`);