

namespace reporting
{

    //interface report which will be implemented in other classes which inherits it
    public interface IReport
    {
        void GenerateReport(string data);
    } 

    //inheriting interface
    public class PdfReport : IReport
    {
        public void GenerateReport(string data)
        {
            Console.WriteLine("Gnerating PDF Report...");
            Console.WriteLine(data);
        }
    }

    //inheriting interface
    public class ExcelReport : IReport
    {
        public void GenerateReport(string data)
        {
            Console.WriteLine("Generating Excel Report...");
            Console.WriteLine(data);
        }
    }
    //inheriting interface
    public class CsvReport : IReport
    {
        public void GenerateReport(string data)
        {
            Console.WriteLine("Generating csv Report...");
            Console.WriteLine(data);
        }
    }
}
    