namespace movies{

    public class program {

        public static List <Movie> MovieList = new List<Movie> ();

        public static void Main(String[] args){
            Program p = new Program();
            int n = int.Parse(Console.ReadLine());
            for(int i =0; i<n; i++)
            {
                Console.WriteLine("Enter movie details: ");
                string details = Console.ReadLine();
                p.AddMovie(details);
            }
                Console.WriteLine("Enter searchGenre: ");
                string searchGenre = Console.ReadLine();

                var byGenre = p.ViewMoviesByGenre(searchGenre);

                if(byGenre.Count ==0){
                    Console.WriteLine("No movies found in genre" + searchGenre);

                }else{
                    foreach( var x in byGenre ){
                        Console.WriteLine(x.Title+" "+ m.Artist +" "+m.Genre+" "+m.Ratings);
                    }
                }
                var sorted = p.ViewMoviesByRatings();
                foreach(var x in sorted){
                    Console.WriteLine(x.Title+" "+ m.Artist +" "+m.Genre+" "+m.Ratings);
                }





            
        }
    }
}