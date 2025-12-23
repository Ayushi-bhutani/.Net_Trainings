namespace OopsSessions{

    public class Employee{

        private int id;  //fields should start with small letter 
        public int Id1 { set{
            if(value >0 ){
                id = value;
            }else{
                id =0;
                throw new InvalidOperationException("How id can be less than 0");
            }
        }
        
    }
    public string DisplayEmpDetails(){
            return $"Employee Id is {id}";
        }
    
}}