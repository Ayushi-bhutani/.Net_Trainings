namespace employee
{
    /// <summary>
    /// defining employee class 
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// public property Id
        /// </summary>
        public int Id{get; set;}

        /// <summary>
        /// public property Name
        /// </summary>
        public string Name{get; set;}

        /// <summary>
        /// public property Email
        /// </summary>
        public string Email {get; set;}

        /// <summary>
        /// public property Salary
        /// </summary>
        public decimal Salary {get; set;}


        /// <summary>
        /// defining parameterised constructor for employee class 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="salary"></param>
        public Employee(int id, string name, string email, decimal salary)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Salary = salary;
        }

        
    }
}