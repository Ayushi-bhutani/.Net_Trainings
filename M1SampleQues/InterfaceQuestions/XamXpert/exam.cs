namespace xam {

    public interface Exam
    {
        public double calculateScore();
        public static string evaluateResult(double percentage)
        {
            if(percentage >= 85)
            {
                return "Merit";
            }
            else if(percentage >= 60 && percentage < 85)
            {
                return "Pass";
            }
            else 
            {
                return "Fail";
            }
        }
        
    }

    public class OnlineTest 
    {
        public string studentName{get; set;}
        public int totalQuestions{get; set;}
        public int correctAnswers {get; set;}
        public int wrongAnswers {get; set;}
        public string questionType{get; set;}

        public OnlineTest(string name, int total, int correct, int wrong, string type)
        {
            studentName = name;
            totalQuestions = total;
            correctAnswers = correct;
            wrongAnswers = wrong;
            questionType = type;
        }

        public double calculateScore()
        {
            double MarksPerQue ;
         
            if(questionType == "MCQ" )
            {
                MarksPerQue = 2;
            }
            else
            {
                MarksPerQue = 5;
            }

            double totalscore  = ( correctAnswers * MarksPerQue ) - ( wrongAnswers * MarksPerQue * 0.10 );
            double percentage = ( totalscore / ( totalQuestions * MarksPerQue )) * 100;

            return percentage; 
        }
    }
}