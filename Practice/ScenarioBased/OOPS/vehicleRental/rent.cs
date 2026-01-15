namespace abstraction{
    public abstract class Vehicle{
        public int days;
        public Vehicle(int days){
            this.days = days;
        }
        public abstract double price();
    }

    public class Car: Vehicle{
        public Car(int days) : base(days){}
        public override double price(){
            return days*1000;
        }
    }

    public class Bike: Vehicle{
        public Bike(int days): base(days){}

        public override double price(){
            return days*500;
        }
    }

    public class Truck : Vehicle {
        public Truck(int days) : base(days) {}

        public override double price(){
            return days*2000;
        }
    }

}