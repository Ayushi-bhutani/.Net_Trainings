namespace rate
{
    public class RateLimiter
    {
        private readonly int _maxRequests;
        private readonly TimeSpan _windowSize;
        private readonly Dictionary <string, Queue<DateTime>> _requests = new Dictionary<string, Queue<DateTime>>();
        private readonly object _lock = new object();
        public RateLimiter(int maxRequest, TimeSpan windowSize)
        {
            _maxRequests = maxRequest;
            _windowSize = windowSize;
        }

        public bool AllowRequest(string clientId, DateTime now)
        {
            lock(_lock)
            {
                if(!_requests.ContainsKey(clientId))
                    _requests[clientId] = new Queue<DateTime>();

                var queue = _requests[clientId];

                while(queue.Count > 0 && now - queue.Peek() > _windowSize)
                {
                    queue.Dequeue();
                }

                if(queue.Count < _maxRequests)
                {
                    queue.Enqueue(now);
                    return true;
                }

                return false;
         
            }
        }
    }
    


}