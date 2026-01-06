namespace abstraction{
    public class Program{

        //entry point
        public static void Main(String[] args){

            //creating of objects: car, bike, truck and accessing therir abstract methods
            Vehicle car = new Car(3);
            Console.WriteLine("car rent "+car.price());
            Vehicle bike = new Bike(3);
            Console.WriteLine("Bike rent "+bike.price());
            Vehicle truck = new Truck(3);
            Console.WriteLine("Truck rent "+truck.price());
        }
    }
}