public class Program {
    public static void Main(String[] args){
        string word1 = Console.ReadLine();
        string word2 = Console.ReadLine();

        HashSet<char>word2Consonants = new HashSet<char>();
        foreach(char c in word2.ToLower())
        {
            if (!IsVowel(c))
            {
                word2Consonants.Add(c);
            }
        }
        List<char>step1Result = new List<char>();
        foreach(char c in word1)
        {
            if(IsVowel(c) || !word2Consonants.Contains(char.ToLower(c))){
                step1Result.Add(c);
            }

        }
        List<char> finalResult = new List<char>();
        for(int i =0; i<step1Result.Count; i++)
        {
            if(i==0|| step1Result[i] != step1Result[i - 1]){
                finalResult.Add(step1Result[i]);
            }
        }
        Console.WriteLine(new string(finalResult.ToArray()));
        
    }
    static bool IsVowel(char c)
    {
         
        char lower = char.ToLower(c);
        return lower == 'a' || lower == 'e' || lower == 'i' || lower == 'o' || lower == 'u';
    }
}