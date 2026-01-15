namespace FlipFlop{
public class Flipflop
    {
        public string CleanseAndInvert(string input)
        {
            // 1 Validate null or length < 6
        
            if (string.IsNullOrEmpty(input) || input.Length < 6)
                return string.Empty;

            // 2 Validate spaces, digits, or special characters
            foreach (char ch in input)
            {
                if (!char.IsLetter(ch))
                    return string.Empty;
            }

            // Convert to lowercase
            string lower = input.ToLower();

            // 3 Remove characters whose ASCII is EVEN
            string filtered = "";
            foreach (char ch in lower)
            {
                if (ch % 2 != 0)
                    filtered += ch;
            }

            // 4 Reverse the string
            char[] arr = filtered.ToCharArray();
            Array.Reverse(arr);
            string reversed = new string(arr);

            // 5️ Uppercase characters at EVEN index (0-based)
            char[] finalChars = reversed.ToCharArray();
            for (int i = 0; i < finalChars.Length; i++)
            {
                if (i % 2 == 0)
                    finalChars[i] = char.ToUpper(finalChars[i]);
            }

            return new string(finalChars);
        }
    }
}