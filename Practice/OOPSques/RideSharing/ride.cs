namespace ride{
    public abstract class Ride
    {
        public double Distance{get; set;}

        protected Ride(double distance)
        {
            Distance = distance;
        }
        public abstract double GetFare();
       
    }
 
    public class CabRide : Ride
    {
        public CabRide(double distance) : base(distance){}
        public override double GetFare()
        {
            return Distance*20;
        }
    }

    public class AutoRide : Ride
    {
        public AutoRide(double distance) : base(distance) {}
        public override double GetFare()
        {
            return Distance*10;
        }
    }
 
    public class PremiumCabRide : Ride
    {
        public PremiumCabRide(double distance) : base(distance) {}
        public override double GetFare()
        {
            return Distance*30;
        }
    }


}