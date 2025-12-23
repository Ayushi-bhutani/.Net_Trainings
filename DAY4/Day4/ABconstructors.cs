namespace Constructor{

    // defining class adding two numbers 
    public class ABConstructor{

        public int a{get; set;}
        public int b {get; set;}
        public int result {get;}

        //constructor customization for two numbers addition
        public ABConstructor(int num1,int num2){
            this.a = num1;
            this.b = num2;
            result = a+b;
            Console.WriteLine(result);
        }
        //if object is returning it will return namespace.baseclass by default for that we are overriding the tostring method
        public override string ToString(){
            return $"sum is {result}";
        }

    }

    
}