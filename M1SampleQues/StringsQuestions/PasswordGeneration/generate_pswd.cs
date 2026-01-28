namespace password
{
    public class Generate
    {
        public static bool IsValidUsername(string user)
        {
            if(user.Length!=8) return false;

            for(int i=0; i<4; i++)
            {
                if(!char.IsUpper(user[i])) 
                    return false;
            }
            if(user[4] != '@') return false;

            string courseIdStr = user.Substring(5,3);

            if (!int.TryParse(courseIdStr, out int courseId))
                return false;

            if (courseId < 101 || courseId > 115)
                return false;
            return true;
        
        }

        public static string GetPassword(string user)
        {
            int asciiSum = 0;

            for (int i = 0; i < 4; i++)
            {
                char lower = char.ToLower(user[i]);
                asciiSum += (int)lower;
            }

            string lastTwoDigits = user.Substring(6, 2);

            return "TECH_" + asciiSum + lastTwoDigits;
        }
    }
}