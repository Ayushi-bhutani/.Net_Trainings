using MathLib;
using ScienceLib;

namespace Console.App{
    public class Program{
        static void Main(String[] args){
            NormalMath maths = new NormalMath();
            MathsLogin login = new MathsLogin();
            login.Login("Ayushi", "112");

            maths.Add(1,2);
            maths.subtract(2,2);
            login.Logout();

            // AeroScience aero = new AeroScience();
            // SciLogin sciLogin = new SciLogin();
            // MathsLogin mathLogin = new MathsLogin();
        }
    }
}