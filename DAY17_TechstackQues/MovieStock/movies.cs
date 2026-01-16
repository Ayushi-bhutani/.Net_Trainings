namespace movies {
    public class Movie 
    {
        public string? Title;
        public string? Artist;
        public string? Genre;
        public int? Ratings;

        public void AddMovie(string MovieDetails){
            string[] parts = MovieDetails.Split(',');

            Movie x = new Movie();
            x.Title = parts[0];
            x.Artist = parts[1];
            x.Genre = parts[2];
            x.Ratings = int.Parse(parts[3]);
            

            MovieList.Add(x);
        }

        public List <Movie> ViewMovieByGenre(string genre){
            List <Movie> ans = new Movie<Movie> ();
            foreach(var m in MovieList){
                if(MovieList.Contains(genre)){
                    ans.Add(genre);
                }
            }
            
            return ans;
        }


        public List<Movie> ViewMoviesByRatings(){
            return MovieList
                    .OrderBy(x=> x.Ratings)
                    .ToList();
                    
        }

    }
}