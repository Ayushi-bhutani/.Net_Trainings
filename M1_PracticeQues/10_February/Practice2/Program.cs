namespace practice2
{
    public class Test{
        public static string equalSums(string s)
    {
        if(string.IsNullOrEmpty(s)) return "-404";
        int totalSum =0;
        foreach( char c in s)
        {
            totalSum += c-'a' + 1;
        }

        int leftSum = 0;
        for(int i = 0 ; i<s.Length; i++)
        {
            int currentValue = s[i] - 'a' + 1;
            int rightSum = totalSum - currentValue - leftSum;
            if(leftSum == rightSum)
            {
                return s[i].ToString();
            }
            leftSum += currentValue;
        }
        return "-404";
    }
    public static void Main(string[] args)
    {
        string s = Console.ReadLine();
        Console.WriteLine(equalSums(s));
    }
    }
}