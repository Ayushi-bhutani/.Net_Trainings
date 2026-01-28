namespace word {

    public class Program {

        public static void Main(String[] args)
        {
            Console.WriteLine("Enter the sentence");
            string sentence = Console.ReadLine();

            if (!Word.IsValidSentence(sentence))
            {
                Console.WriteLine("Invalid Sentence");
                return;
            } 
            
            string wordcount = Word.WordCount(sentence);
            Console.WriteLine($"Word Count: {wordcount}");
            
            string result = Word.Operations(sentence);
            Console.WriteLine(result);
        }
    }
}