namespace items{
    public class Items
    {
        public SortedDictionary<string, long> FindItemDetails(long soldCount)
        {
            SortedDictionary<string,long > sorted = new SortedDictionary<string,long>();

            foreach( var i in itemDetails)
            {
                if(i.Value == soldCount)
                {
                    sorted.Add(i.Key, i.Value);
                }

            }
            
            return sorted;
        }

        public List <string> FindMinandMaxSoldItems()
        {
            List <string> ans = new List<string>();
            long mini = long.MaxValue;
            long maxi = long.MinValue;
            string minString = "";
            string maxString = "";
            foreach(var i in itemDetails)
            {
                if(i.Value < mini)
                {
                    mini = i.Value;
                    minString = i.Key;
                }
            }
            foreach(var i in itemDetails)
            {
                if(i.Value > maxi)
                {
                    maxi = i.Value;
                    maxString = i.Key;
                }
            }

            ans.Add(minString);
            ans.Add(maxString);

            return ans;
            
        }

        public Dictionary<string, long> SortByCount()
        {
            // Dictionary<string,long > dict = new Dictionary<string,long>();
            return itemDetails
                .OrderBy(x => x.Value)
                .ToDictionary(x=>x.Key, x=>x.Value);
            



        }
    }
}