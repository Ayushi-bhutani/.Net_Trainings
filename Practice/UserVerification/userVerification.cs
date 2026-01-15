namespace user{

    public class InvalidPhoneNumberException: Exception {
        public InvalidPhoneNumberException (string message) : base(message){
            
        }
    }
    public class User{
        public string Name{get;set;}
        public string PhoneNumber{get; set;}

    }
}