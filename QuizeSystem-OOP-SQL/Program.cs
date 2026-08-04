namespace QuizeSystem_OOP_SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "Quiz System";
                OperatingClass.OperateSystem();
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
