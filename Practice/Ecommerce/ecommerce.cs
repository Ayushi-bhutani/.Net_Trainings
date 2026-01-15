namespace ecommerce{

    public class InsufficientWalletBalanceException : Exception {
        public InsufficientWalletBalanceException(string message) : base(message){

        }
    }
    public class EcommerceShop{
        public string UserName{get; set;}
        public double WalletBalance {get; set;}
        public double TotalPurchaseAmount {get; set;}
        
    }
}