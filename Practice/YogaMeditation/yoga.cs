using System.Collections;
using System.Runtime.Intrinsics.X86;

namespace yoga{
    public class MeditationCenter
    {
        public int? MemberId{get; set;}
        public int? Age{get; set;}
        public double Weight{get; set;}
        public double Height{get; set;}
        public string? Goal{get; set;}
        public double BMI{get; set;}

        public static ArrayList MemberList = new ArrayList();
        public void AddYogaMember(int memberId, int age, double weight, double height, string goal)
        {
            MeditationCenter m = new MeditationCenter();
            m.MemberId = memberId;
            m.Age = age;
            m.Weight = weight;
            m.Height = height;
            m.Goal= goal;
            MemberList.Add(m);

        }

        public double CalculateBMI(int memberId)
        {
            foreach(MeditationCenter m in MemberList){
                if(m.MemberId == memberId){
                    double bmi = m.Weight / (m.Height* m.Height);
                    bmi = Math.Floor(bmi*100)/100;
                    m.BMI = bmi;
                    return bmi;
                }
            }
            return 0;
            
        }

        public int CalculateYogaFee(int memberId)
        {
            foreach(MeditationCenter m in MemberList ){
                if(m.MemberId == memberId){
                    if(Goal=="Weight Loss")
            {
                if(BMI >= 25 && BMI < 30)
                {
                    return 2000;
                }
                else if(BMI >= 30 && BMI < 35)
                {
                    return 2500;
                }
                else if(BMI>=35)
                {
                    return 3000;
                }
            }
            else
            {
                return 2500;
            }
                }
            }
            return 0;
            
        }

    }
}