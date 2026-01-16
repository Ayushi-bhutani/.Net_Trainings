namespace user{
    public class Program {
        public User ValidatePassword (string name, string password, string confirmationPassword){
            
          
            if(password !=confirmationPassword ){
                throw new PasswordMismatchException("Password entered does not match");
            } 

            User u = new User();
            u.Name= name;
            u.Password = password;
            u.ConfirmationPassword = confirmationPassword;


            

            return u;
            


        }
        public static void Main(String[] args){
            Program p = new Program();
            string name = Console.ReadLine();
            string password = Console.ReadLine();
            string passwordConfirmation = Console.ReadLine();

            try{
                User u = p.ValidatePassword(name, password, confirmationPassword);
               
                Console.WriteLine("Registered Successfully");
                

            }catch(PasswordMismatchException ex){
                Console.WriteLine(ex.Message);
            }

        }
    }
}