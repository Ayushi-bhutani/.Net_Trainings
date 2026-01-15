namespace delivery{
    public interface IOrderTracker{
        public void TrackOrder();
        public void CancelOrder();
    }
    public class SwiggyOrder : IOrderTracker{
        public void TrackOrder(){
            Console.WriteLine("Tracking order SwiggyOrder");
        }
        public void CancelOrder(){
            Console.WriteLine("Cancelling order SwiggyOrder");
        }
    }
    public class ZomatoOrder : IOrderTracker{
        public void TrackOrder(){
            Console.WriteLine("Tracking order ZomatoOrder");
        }
        public void CancelOrder(){
            Console.WriteLine("Cancelling order ZomatoOrder");
        }
    }
}