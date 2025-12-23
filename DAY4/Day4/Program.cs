namespace OopsSessions{

    public class Program
    {
        public static void Main(String[] args){
            
                // Visitor v1 = new Visitor();
                // Visitor v3 = new Visitor(1, "Ayushi", "Name change Request");
                  

                // Console.WriteLine(v1); 

                // Console.WriteLine(v2);
            try{
                Visitor v3 = new Visitor(2, "Ayushi", "Name change Request");     
                Console.WriteLine(v3);

            }
            catch(ArgumentException ex){
                Console.WriteLine(ex.Message);
            }
            
        }
        

        
}
}
