using TfL_Walking_Distance_Version2.View;

namespace TfL_Walking_Distance_Version2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TfL_App londonMap = new TfL_App();

            string[] londonFilePath = londonMap.GetFiles();

            londonMap.StoreRecords(londonFilePath);
            Console.WriteLine("1. Start App");
            Console.WriteLine();
            londonMap.Start();
        }
    }
}