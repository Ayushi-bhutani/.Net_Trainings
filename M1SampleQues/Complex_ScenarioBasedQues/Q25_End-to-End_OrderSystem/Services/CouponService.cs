namespace order
{
    public class CouponService
    {
        public decimal ApplyCoupon(string couponCode, decimal amount)
        {
            if(string.IsNullOrWhiteSpace(couponCode))
                return amount;

            if(couponCode == "DISC10")
            {
                decimal discount = amount * 0.10m;
                discount = Math.Min(discount, 500);
                return amount - discount;

            }
            return amount;
        }
    }
}