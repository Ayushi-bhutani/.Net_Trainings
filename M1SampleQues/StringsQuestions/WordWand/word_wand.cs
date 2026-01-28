namespace word 
{
    public class Word
    {
        public static int WordCount(string sentence)
        {
            string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        public static bool IsValidSentence(string sentence)
        {
            foreach(char c in sentence){
                if(!(char.IsLetter(c) || c==' ')){
                    return false;
                }
            }
            return true;
        }
        
        public static string Operations (string sentence)
        {
            int wordcount = WordCount(sentence);
            string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            if(wordcount %2==0)
            {
                Array.Reverse(words);
                return string.Join(" ", words);
            }
          
            else {
                StringBuilder result = new StringBuilder();
                foreach(string word in words)
                {
                    char[] ch = word.ToCharArray();
                    Array.Reverse(ch);
                    result.Append(new string(ch)).Append(" ");
                }

                return result.ToString().Trim();
            }
        }
    }
}