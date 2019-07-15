async function clicked() {
    let name = $("#Name").val();
    let data = await getInfo(name);

    let $poster = $("#Poster").val(data.Poster);
    let $rating = $("#Rating").val(data.imdbRating);
    let $year = $("#Year").val(data.Year.substring(0,  data.Year.length - 1));
   
    //Genre
    let gen = data["Genre"];
    let $sg = $("#Genre").val(gen);
    //Actors
    let act = data["Actors"];
    let $actors = $("#Actors").val(act);

    $("#Plot").val(data.Plot);
}

async function getInfo(name) {
    let site = `https://www.omdbapi.com/`;
    let target = `?t=${name}`;

    let url = site + target;

    let result = await $.ajax({
        url,
        method: 'GET',
        data: {
            'apikey': 'be7583d7'
        },
        success: function (data) {

        },
        error: function (err) {
            console.log('error:' + err);
        }
    });


    return result;
}