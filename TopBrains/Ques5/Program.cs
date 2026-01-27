namespace arit{
    public class Program 
    {
        public static void Main(String[] args){
            Console.WriteLine("Enter expression");
            string exp  = Console.ReadLine().Trim();
            string[] parts = exp.Split(' ');

            if(parts.Length != 3){
                Console.WriteLine("Error:InvalidExpression");

                return;
            }
            string aS = parts[0];
            string op = parts[1];
            string bS= parts[2];

            int a, b;

            if(!int.TryParse(aS, out a) || !int.TryParse(bS, out b)){
                Console.WriteLine("Error:InvalidNumber");
                return;
            }
            string result;



            switch(op){
                case "+":
                    result = (a+b).ToString();
                    break;
                case "-":
                    result = (a-b).ToString();
                    break;
                case "*":
                    result = (a*b).ToString();
                    break;
                    
                case "/":
                    if(b==0){
                         result = "Error:DivideByZero";
                    }else{
                    result = (a/b).ToString();
                    }
                    break;
                default:
                    result = "Error:UnknownOperator";
                    break;
                    

            }
            Console.WriteLine(result);

        }
    } 
}