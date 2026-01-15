namespace user{
    public class Program {

        public User ValidatePhoneNumber(string name, string phoneNumber){
            
            User user = new User();
            user.Name = name;
            user.PhoneNumber= phoneNumber;
            if(phoneNumber.Length == 10){
                user.Name = name;
                user.PhoneNumber= phoneNumber;
            }else{
                throw new InvalidPhoneNumberException("Invalid phone number");
            }
            return user;
        }
        public static void Main(String[] args){
            Program p = new Program();
            string name = Console.ReadLine();
            string phoneNumber = Console.ReadLine();

            try{
                User user = p.ValidatePhoneNumber(name, phoneNumber);
                Console.WriteLine("Phone number is verified");

            }catch(InvalidPhoneNumberException ex){
                Console.WriteLine(ex.Message);
            }
        }
    }
}