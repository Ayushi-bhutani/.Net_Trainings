namespace onlinegateway{
    public class Program{

        //entry point
        public static void Main(String[] args){

            //creating object for parent class and inheriting methods for child class 
            // //accessing child class from parent class
            Online o = new Gateway();
            o.ProcessPayment("CreditCard") ;
            o.ProcessPayment("UPI") ;
            o.ProcessPayment("NetBanking") ;


        }

    }
}