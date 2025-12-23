
using System.Dynamic;

namespace OopsSessions
{
    public class Visitor
    {
        public int? Id{get; set;}
        public string? Name{get; set;}
        public string? Requirement{get; set;}
        public string? LogHistory{get; set;}
        public Visitor()
        {
            LogHistory += $"Object created at {DateTime.Now.ToString()}   {Environment.NewLine}";
            // Console.WriteLine(LogHistory);
        }
        public Visitor(int id) : this()
        {
            this.Id = id;
            LogHistory += $"ID created at {DateTime.Now.ToString()}  {Environment.NewLine}";
            // Console.WriteLine(LogHistory);
            

        }
        public Visitor(int id, string name): this(id)
        {
            this.Name = name;
            if(name.ToLower().Contains("idiot")){
                throw new ArgumentException("dont type");
            }
           
            LogHistory += $"Name created at {DateTime.Now.ToString()}  {Environment.NewLine}";
            // Console.WriteLine(LogHistory);
        }

        public Visitor(int id, string name, string Requirement): this(id, name)
        {
            this.Requirement = Requirement;
            LogHistory += $"Requirement created at {DateTime.Now.ToString()}  {Environment.NewLine}";
            
            Console.WriteLine(LogHistory);


        }
        
        public override string ToString()
{
    
    return $"Id: {Id}, Name: {Name}";
}





    }
}
