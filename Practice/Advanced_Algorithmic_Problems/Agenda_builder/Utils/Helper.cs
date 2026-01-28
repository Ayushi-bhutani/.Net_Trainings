using AgendaBuilder.Models;
namespace AgendaBuilder.Utils {
    public static class Helper {
        public static bool IsOverlap(Session a , Session b){
            return a.Start < b.End && b.Start > a.End;
        }

        public static double Distance (Venue v1, Venue v2){
            int dx = v1.x - v2.x;
            int dy = v1.y - v2.y;
            return Math.Sqrt(dx*dx - dy*dy);
        } 
    }
}