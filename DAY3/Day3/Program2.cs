/*
namespace OopsSessions
{
        public class Program2
        {

                public static void Main(string[] args)
                {
                Program2 program = new Program2();
                Person person = new Person() {Id = 1, Age = 20, Name = "Ayushi"};
                string output = program.GetDetails(person);
                Console.WriteLine(output);
                }

                public string GetDetails(Person person)
                {
                string result = string.Empty;
                if(person is Man){
                    Man man = (Man) person;
                    result = $"Id = {man.Id} Name = {man.Name} Playing = {man.Playing}";

                }
                if(person is Woman){
                    Woman woman = (Woman) person;
                    result =$"Id = {woman.Id} Name = {woman.Name} Playing = {woman.PlayManage}";
                }
                return result ;



                }
        }
}
*/
namespace OopsSessions
{

public class Program2
{

    public static void Main(string[] args)
    {
                

    }

    public string GetDetails(Person person)
                {
                    string result = string.Empty;
                    if(person is Man){
                    Man man = (Man) person;
                    result = $"Id = {man.Id} Name = {man.Name} Playing = {man.Playing}";

                }
                if(person is Woman){
                    Woman woman = (Woman) person;
                    result =$"Id = {woman.Id} Name = {woman.Name} Playing = {woman.PlayManage}";
                }
                return result ;



                }
    }
    
}
