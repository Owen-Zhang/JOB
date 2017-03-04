using Job_FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            //args = new string[]{"JobSchedule.Solr.ScheduleJob"};
            try
            {
                var taskName = args[0];
                if (string.IsNullOrWhiteSpace(taskName))
                    throw new Exception("please input TypeClass");

                JobManager.Run(Type.GetType(taskName), args);

                Console.WriteLine("Program is excuted end");
            }
            catch (Exception err)
            {
                Console.Error.WriteLine(err.Message);
                Console.Error.WriteLine(err.StackTrace);

                if (err.InnerException != null)
                {
                    Console.Error.WriteLine("Inner Exception:");
                    Console.Error.WriteLine(err.InnerException.Message);
                    Console.Error.WriteLine(err.InnerException.StackTrace);
                }
                Environment.Exit(-1);
            }
        }
    }
}
