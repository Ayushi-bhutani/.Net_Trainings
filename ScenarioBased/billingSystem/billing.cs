namespace billing{
    public class Billing {

        public double CalculateTotal (double price){
            return price;
        }
        public double CalculateTotal (double price, double tax){
            return price + (price*tax/100);
        }
        public double CalculateTotal (double price, double tax, double discount){
            double total = price + (price*tax/100);
            total = total - (total*discount/100);
            return total;
        }


    }
}