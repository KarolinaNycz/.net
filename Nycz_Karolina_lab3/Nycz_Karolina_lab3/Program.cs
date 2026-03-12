namespace Kalkulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculatorService service = new CalculatorService();
            service.Run();
        }
    }
}