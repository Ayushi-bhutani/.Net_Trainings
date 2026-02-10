namespace banking {
    public class BankAccount
    {
        /// <summary>
        /// private property balance
        /// </summary>
        public double balance{get; private set;}

        /// <summary>
        /// public method to deposit
        /// </summary>
        public double Deposit(double amount)
        {
            if(amount > 0)
            {
                balance += amount;
                return balance;
            }
            return 0;
            
        }

        /// <summary>
        /// public method to withdraw
        /// </summary>
        public double Withdraw(double amount)
        {
            if(amount <= balance)
            {
                balance -= amount;
                return balance;
            }
            return 0;
        }

        /// <summary>
        /// constructor for bankaccount class
        /// </summary>
        /// <param name="balance"></param>
        public BankAccount(double balance)
        {
            this.balance = balance;
        }
    }
}