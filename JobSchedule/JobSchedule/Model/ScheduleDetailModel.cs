using System;

namespace JobSchedule.Model
{
    public class ScheduleDetailModel
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int ExitCode { get; set; }

        public int Pid { get; set; }
    }
}
