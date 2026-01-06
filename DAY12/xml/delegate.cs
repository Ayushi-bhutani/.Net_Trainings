namespace delegate1 {
    public delegate int DelegateAddFunctionName (int a, int b);
    public class ExampleOfDelegate{
        public int? a;
        public int? b;

        public void DelegateEx1(){
            DelegateAddFunctionName variable1 = new DelegateAddFunctionName(addMethod2);
    

           int result = variable1(20,25);
           Console.WriteLine(result);
        

          



            
        }

        private int AddMethod1(int a, int b){
            return a+b+10;
        }

        private int AddMethod2(int a, int b){
            return a+b+40;
        }


        
    }

    public class Program12{
        public static void Main(String[] args){
            
            ExampleOfDelegate ev = new ExampleOfDelegate();
            ev.DelegateEx1();
            
            
        }
    }

    
}