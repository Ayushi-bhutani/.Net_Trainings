namespace construction {

    public class ConstructionEstimateException : Exception {
        public ConstructionEstimateException(string message): base (message){
            
        }
    }
    public class EstimateDetails{
        public float ConstructionArea{get; set;}
        public float siteArea{get; set;}



    }
    
}