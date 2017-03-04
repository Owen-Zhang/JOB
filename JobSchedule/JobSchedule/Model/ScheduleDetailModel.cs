using System;

namespace JobSchedule.Model
{
    public class ScheduleDetailModel
    {
        public int Id { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int ExitCode { get; set; }

        public int Pid { get; set; }
    }
}
