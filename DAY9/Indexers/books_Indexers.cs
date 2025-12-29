namespace indexers{
    public class Student
    {
        public int? RollNo{get; set;}
        public string? Name{get; set;}
        private string? Address{get; set;}
        private string[] Books = new string[3];
        public string this [int index]
        {
            get
            {
                return Books[index];
            }
            set
            {
                Books[index] = value;
            }
        }

    }
    public class Indexers{
        public static void Main(String[] args){
            Student obj = new Student();
            obj[0] = "book1";
            obj[1] = "book2";
            obj[2] = "book3";

            Console.WriteLine($"first book :{obj[0]}");
            Console.WriteLine($"second book :{obj[1]}");
            Console.WriteLine($"third book :{obj[2]}");


        }
    }
}

