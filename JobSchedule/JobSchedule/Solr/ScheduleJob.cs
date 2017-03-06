using System;
using System.Linq;
using System.Net;
using DataAccess;
using Job_FrameWork;
using JobSchedule.Model;
using Job_FrameWork.Common;
using System.Collections.Generic;
using System.Configuration;


namespace JobSchedule.Solr
{
    public class ScheduleJob : BaseJob
    {
        public override void Excute(string[] args)
        {
            string url = ConfigurationManager.AppSettings["ScheduleSorlUrl"].ToString() + "?boost=1.0&commitWithin=1000&overwrite=true&wt=json";

            var command = DbManager.GetDataCommand("GetMySqlSechedulerInfo");
            command.SetParameterValue("@PageIndex", 0);
            command.SetParameterValue("@PageSize", 100);
            var scheduleData = command.QueryList<ScheduleDetailModel>();
            if (scheduleData.Count == 0)
                return;

            new HttpRestClient(
                    new WebHeaderCollection(){
                        {"Accept", ContentFormat.Json},
                        {"Content-Type", ContentFormat.Json},
                    }
                ).PostByStrService<string>(url, "POST", scheduleData.Select(item => 
                    new {
                        Id = item.Id,
                        StartTime = item.StartTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        EndTime = item.EndTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        ExitCode =  item.ExitCode,
                        Pid = item.Pid
                    }));
        }
    }
}
