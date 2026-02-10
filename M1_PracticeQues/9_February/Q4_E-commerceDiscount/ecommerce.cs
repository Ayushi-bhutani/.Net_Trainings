using System.Reflection.Metadata.Ecma335;

namespace ecommerce {

    /// <summary>
    /// defining abstract class DiscountPolicy
    /// </summary>
    public abstract class DiscountPolicy
    {
        /// <summary>
        /// abstract method GetFinalAmount
        /// </summary>
        /// <param name="amount"></param>
        public abstract double GetFinalAmount(double amount);
       
    }
    public class FestivalDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            double discount ;
            if(amount >= 5000)
            {
                discount = amount * 0.10;
                return amount - discount;
            }
            else
            {
                discount = amount * 0.05;
                return amount - discount;
            }
        }    
    }
    public class MemberDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            double discount;
            if(amount >= 2000)
            {
                discount = amount - 300;
                return amount - discount;
            }
            else
            {
                return amount;
            }          
        }
    }
}