namespace nums{
    public class Numbers{
        public static List<int> NumberList = new List<int>();
        
        public void AddNumbers(int Numbers){

            NumberList.Add(Numbers);
        }

        public double GetGPAScored()
        {
            if (NumberList.Count == 0)
                return -1;

            double sum = 0;
            foreach (int n in NumberList)
            {
                sum += (n * 3);   // credit for each subject = 3
            }

            double gpa = sum / (NumberList.Count * 3);
            return gpa;
        }

        public char GetGradeScored(double gpa){
            
            if(gpa < 5 || gpa > 10 ) return '\0';
            if(gpa == 10) return 'S';
            else if(gpa >= 9 && gpa <10) return 'A';
            else if(gpa >= 8 && gpa <9) return 'B';
            else if(gpa >= 7 && gpa <8) return 'C';
            else if(gpa >= 6 && gpa <7) return 'D';
            else return 'E';

        }

    }
}