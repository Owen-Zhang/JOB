using Job_FrameWork;
using System;

namespace JobSchedule.Solr
{
    public class ScheduleJob : BaseJob
    {
        public override void Excute(string[] args)
        {
            foreach (var item in args)
            {
                Console.WriteLine(item);                
            }
        }
    }
}
