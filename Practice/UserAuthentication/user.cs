namespace user {

    public class PasswordMismatchException : Exception {
        public PasswordMismatchException(string message): base(message){
            
        }
    }
    public class User{
        public string Name;
        public string Password;
        public string ConfirmationPassword;
    }
}