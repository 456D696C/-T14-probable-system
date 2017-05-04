using System;


namespace Simple.TaskManagement.Service.Point
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Bootstrapper.Start())
                {
                    Console.WriteLine($@"
                    {typeof(Program).Namespace} up and runnig.
                    Press any key to stop!
                    "
                        );

                    Console.ReadLine();

                    Console.WriteLine($@"
                    {typeof(Program).Namespace} stopping...
                    "
                       );
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"ERROR:{new { exception.Message}}\n{exception}\n");
            }

            Console.WriteLine($@"
                    {typeof(Program).Namespace} stopped.
                    Press any key to quit!
                    "
                    );

            Console.ReadLine();
        }
    }
}
