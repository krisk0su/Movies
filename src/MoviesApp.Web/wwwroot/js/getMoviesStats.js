async function clicked() {
    let name = $("#Name").val();

    //getting id from www.omdbapi.com  <--------ALSO SETTING SOME DATA--------------->
    let imdbId = await getImdbId(name);
    //getting movieId from www.themoviedb.org using imdbId <------------------------->
    let movieId = await getMovieId(imdbId);
    //getting info from www.themoviedb.org using their own movie Id <---------------->
    let movieInfo = await getDetails(movieId);
    setData(movieInfo);
    
} 
function setData(data) {

    console.log($("#Plot").val(data.overview));
    $("#Plot").val(data.overview);
    
    
    //let posterPath = data.poster_path;
    //let posterUrl = "https://image.tmdb.org/t/p/w185/" + posterPath;
    //$("#Poster").val(posterUrl);

}
async function getDetails(id) {
    let siteUrl = "https://api.themoviedb.org/3/movie/";
    let remaining = "?api_key=89d853248f1b704133ad61dbe906c51d&language=en-US";
    let url = siteUrl + id + remaining;

    let response = await fetch(url);
    let data = await response.json();

    return data;
}
async function getMovieId(imdbId) {
    
    let siteUrl = "https://api.themoviedb.org/3/find/";
    let remaining = "?api_key=89d853248f1b704133ad61dbe906c51d&language=en-US&external_source=imdb_id";

    let url = siteUrl + imdbId + remaining;

    let response = await fetch(url);
    let data = await response.json();

    return data["movie_results"][0]["id"];
}
async function getImdbId(name) {
    let siteUrl = `https://www.omdbapi.com/?t=${name}`;
    let key = `&apikey=be7583d7`;

    let url = siteUrl + key;

    let response = await fetch(url);
    let data = await response.json();

    //SET RATING FROM IMDB
    $("#Rating").val(data.imdbRating);
    //GET GENRES AND ACTORS FROM OMDB-API
    let gen = data["Genre"];
    $("#Genre").val(gen);
    let act = data["Actors"];
    $("#Actors").val(act);
    //SET Poster
    $("#Poster").val(data.Poster);
    //Set date
    $("#Date").val(data.Released);
    
    let imdbId = data.imdbID;
    return imdbId;
}



