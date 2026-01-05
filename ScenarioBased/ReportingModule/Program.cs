namespace reporting{
    public class Program
        {

            //entry point 
            public static void Main(String[] args)
            {

                //creating object of interface and access different class methods
                IReport report;
                report = new PdfReport();
                report.GenerateReport("Sales Data");

                report = new ExcelReport();
                report.GenerateReport("Sales Data");

                report = new CsvReport();
                report.GenerateReport("Sales Data");
            
        }
    }
}