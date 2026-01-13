namespace LearningCsharp
{

    //datatype PrintMessage can be used for defining properties
    public delegate string PrintMessage(string message);
    public class PrintingCompany
    {
        public PrintMessage CustomerChoicePrintMessage{get; set;}
        public void Print(string message)
        {
            string messageTOPrint = CustomerChoicePrintMessage(message);
            Console.WriteLine(messageTOPrint);
        }
    }
    
}