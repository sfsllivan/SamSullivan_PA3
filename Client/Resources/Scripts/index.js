//let Drivers = document.getElementById("Drivers");
let drivers = [];
const allDriversApiUrl = "https://localhost:7181/api/drivers";
const body = document.getElementById('root');
let table = document.createElement('table');
let thead = document.createElement('thead')
table.appendChild(thead);


function getDrivers(){
    
    //console.log("1");
    fetch(allDriversApiUrl).then((response) =>response.json()).then(r => {
        console.log(r)
    }).then(function(json){
        console.log(json);
        drivers = json;
        CreateHeader();
        CreateBody();
    });
    //catch(function(error){
    //      console.log(error);
    // });  
}

function CreateHeader(){
    let tr = document.createElement('tr');
    let array = ['Id', 'Name', 'Rating', 'DateHired', 'Deleted'];
    array.forEach((heading)=> {
        let th = document.createElement('th');
        th.appendChild(document.createTextNode(heading));
        tr.appendChild(th);
    })
    thead.appendChild(tr);
    body.appendChild(table);
}

function CreateBody(){
    drivers.forEach((driver)=>{
        let tr = document.createElement('tr');

        let idTD = document.createElement('td');
        idTD.appendChild(document.createTextNode.apply(driver.Id));
        tr.appendChild(idTD);

        let nameTD = document.createElement('td');
        nameTD.appendChild(document.createTextNode.apply(driver.Name));
        tr.appendChild(nameTD);

        let ratingTD = document.createElement('td');
        ratingTD.appendChild(document.createTextNode.apply(driver.Rating));
        tr.appendChild(ratingTD);

        let DateHiredTD = document.createElement('td');
        DateHiredTD.appendChild(document.createTextNode.apply(driver.DateHired));
        tr.appendChild(DateHiredTD);

        let DeletedTD = document.createElement('td');
        DeletedTD.appendChild(document.createTextNode.apply(driver.Deleted));
        tr.appendChild(DeletedTD);


    })
    
}

function postDriver(){
    const postDriversApiUrl = "https://localhost:7181/api/drivers";
    const DriverID = document.getElementById("Id").value;
    const DriverName = document.getElementById("Name").value;
    const DriverRating = document.getElementById("Rating").value;
    const DriverDateHired = document.getElementById("DateHired").value;
    const DriverDeleted = document.getElementById("Deleted").value;

    fetch(postDriversApiUrl, {
        method: "Post",
        headers: {
            "Accept": 'application/json',
            "Context-Type" : 'application/json'
        },
        body: JSON.stringify({
            Name: DriverName,
            Id: DriverID,
            Rating: DriverRating,
            DateHired: DriverDateHired,
            Deleted: DriverDeleted

        })
    })
    .then((response)=>{
        console.log(response);
        getDrivers();
    })
}
