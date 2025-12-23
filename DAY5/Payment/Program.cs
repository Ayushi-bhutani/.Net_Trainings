using upipayment;
    public class Payments{
        public static void Main(String[] args){
            Payment pays = new Upipayment(1000, "Ayushi");
            pays.Pay();
            pays.PrintReciept();
            

        }
    }
