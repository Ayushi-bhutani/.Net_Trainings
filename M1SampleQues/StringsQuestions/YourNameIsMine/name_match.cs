namespace name {

    public class Match{

        public static bool IsValidName(string name)
        {
            foreach(char character in name)
            {
                if(!char.IsLetter(character) && character !=' ')
                {
                    return false;
                }
                
            }
            return true;
        }

        public static bool IsSubsequence(string man, string woman)
        {
            int index1 = 0, index2 = 0;
            while(index1 < man.Length && index2 < woman.Length)
            {
                if(char.ToLower(man[index1]) == char.ToLower(woman[index2]))
                {
                    index1++;
                }
                index2++;
            }
            return index1 == man.Length;
        }

        public static int CompatibilityValue(string man , string woman)
        {
            int Man = man.Length;
            int Woman = woman.Length;
            int[,] dp = new int[Man + 1, Woman + 1];

            for(int index1 = 0; index1 <= Man ; index1++)
            {
                dp[index1 , 0] = index1;
            }

            for(int index2 = 0; index2 <= Woman; index2++)
            {
                dp[0,index2] = index2;
            }

            for(int i = 1; i <= Man; i++)
            {
                for(int j = 1; j <= Woman; j++)
                {
                    if(char.ToLower( man [i-1] ) == char.ToLower( woman [j-1] ))
                    {
                        dp[i,j] = dp [i-1 , j-1];
                    }
                    else
                    {
                        dp [i,j]= 1 + Math.Min(
                            dp [i-1, j-1],
                            Math.Min (dp[i-1, j] , dp[i,j-1])
                        );
                    }
                }
                
            }
            return dp[Man,Woman];
        }
    }
}