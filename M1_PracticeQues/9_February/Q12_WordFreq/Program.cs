namespace word
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string sentence = Console.ReadLine();
            sentence = sentence.ToLower();
            string[] words =sentence.Split(' ');
            Dictionary <string, int> freq = new Dictionary<string, int>();

            foreach(string word in words)
            {
                if(freq.ContainsKey(word)) freq[word]++;
                else freq[word] = 1;
            }
            

            foreach(var item in freq)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}