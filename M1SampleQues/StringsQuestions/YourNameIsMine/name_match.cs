namespace name {

    public class Match{

        public static bool IsValidName(string name)
        {
            foreach(char c in name)
            {
                if(!char.IsLetter(c) && c!=' ')
                {
                    return false;
                }
                
            }
            return true;
        }

        public static bool IsSubsequence(string s1, string s2)
        {
            int i =0, j=0;
            while(i<s1.Length && j<s2.Length)
            {
                if(char.ToLower(s1[i]) == char.ToLower(s2[j]))
                {
                    i++;
                }
                j++;
            }
            return i == s1.Length;
        }

        public static int CompatibilityValue(string a , string b)
        {
            int m = a.Length;
            int n = b.Length;
            int[,] dp = new int[m+1, n+1];
            for(int i=0; i<=m ; i++)
            {
                dp[i,0] = i;
            }

            for(int j=0; j<=n; j++)
            {
                dp[0,j] = j;
            }

            for(int i=1; i<=m; i++)
            {
                for(int j=1; j<=n; j++)
                {
                    if(char.ToLower(a[i-1]) == char.ToLower(b[j-1]))
                    {
                        dp[i,j] = dp[i-1, j-1];
                    }
                    else
                    {
                        dp[i,j]= 1+ Math.Min(
                            dp[i-1, j-1],
                            Math.Min(dp[i-1, j], dp[i,j-1])
                        );
                    }
                }
                
            }
            return dp[m,n];
        }
    }
}