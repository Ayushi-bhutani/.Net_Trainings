namespace cab {
    public class Cab
    {
        public virtual double CalculateFare(int km)
        {
            return 0;
        }

        
    }
    public class Mini : Cab
    {
        public override double CalculateFare(int km)
        {
            return km*12;
        }
    }

    public class Sedan : Cab
    {
        public override double CalculateFare(int km)
        {
            return km*15 + 50;
        }
    }


    public class SUV : Cab
    {
        public override double CalculateFare(int km)
        {
            return km*18 + 100;
        }
    }
}