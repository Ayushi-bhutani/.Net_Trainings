namespace insurance {
    public class Insurance {
        public virtual double CalculatePremium(double amount){
            return amount;
        }
    }

    public class Health : Insurance{
        public override double CalculatePremium(double amount){
            return amount + (amount*0.10);
        }
    }


    public class Life : Insurance{
        public override double CalculatePremium(double amount){
            return amount + (amount*0.30);
        }
    }

    public class Vehicle : Insurance{
        public override double CalculatePremium(double amount){
            return amount + (amount*0.20);
        }
    }

}