using System;


namespace Simple.TaskManagement.Coordinator
{
    class Program
    {
        static void Main(string[] args)
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

            Console.WriteLine($@"
                    {typeof(Program).Namespace} stopped.
                    Press any key to quit!
                    "
                    );

            Console.ReadLine();
        }
    }
}
