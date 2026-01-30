namespace ExceptionsHandling.Core;

public class ExceptionService
{
    public double ProcessUserData(string username, int age, int salary, int divisor)
    {
        // 1️⃣ Null check
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentNullException(nameof(username), "Username cannot be null or empty");

        // 2️⃣ Range check
        if (age < 18 || age > 60)
            throw new ArgumentOutOfRangeException(nameof(age), "Age must be between 18 and 60");

        // 3️⃣ Business rule check
        if (salary < 0)
            throw new InvalidOperationException("Salary cannot be negative");

        // 4️⃣ Divide by zero check
        if (divisor == 0)
            throw new DivideByZeroException("Divisor cannot be zero");

        // If everything is valid
        return salary / divisor;
    }
}
