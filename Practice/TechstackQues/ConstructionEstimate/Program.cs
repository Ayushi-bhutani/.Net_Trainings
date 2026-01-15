namespace construction {
    public class Program {

        public EstimateDetails ValidateConstructionEstimate(float constuctionArea, float siteArea){
            EstimateDetails estimate = new EstimateDetails();
            
            

            
            if(constuctionArea <= siteArea){
                estimate.ConstructionArea = constuctionArea;
                estimate.siteArea = siteArea;
            }else{
                throw new ConstructionEstimateException("Sorry your Construction Estimate is not approved");
            }

            return estimate;
        }
        public static void Main(String[] args){
            Program p = new Program();
            Console.WriteLine("Enter constructionArea");
            float constructionArea = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter siteArea");
            float siteArea = float.Parse(Console.ReadLine());
            try{
                EstimateDetails estimate = p.ValidateConstructionEstimate(constructionArea, siteArea);
                Console.WriteLine("Construction area is less than site area");
                

            }catch(ConstructionEstimateException ex){
                Console.WriteLine(ex.Message);
            }
            



        }
    }
}