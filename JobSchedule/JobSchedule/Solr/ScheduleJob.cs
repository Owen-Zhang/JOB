using Job_FrameWork;
using Job_FrameWork.Common;
using JobSchedule.Model;
using System;
using System.Collections.Generic;
using System.Net;

namespace JobSchedule.Solr
{
    public class ScheduleJob : BaseJob
    {
        public override void Excute(string[] args)
        {
            string url = "http://localhost:8080/solr/JobScheduler/update?boost=1.0&commitWithin=1000&overwrite=true&wt=json";

            new HttpRestClient(
                    new WebHeaderCollection(){
                        {"Accept", ContentFormat.Json},
                        {"Content-Type", ContentFormat.Json},
                    }
                ).PostByStrService<string>(url, "POST", new List<ScheduleDetailModel> { 
                    new ScheduleDetailModel{
                        Id = 6,
                        StartTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        EndTime = DateTime.Now.AddDays(2).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        ExitCode = 0,
                        Pid = 1
                    },
                    new ScheduleDetailModel{
                        Id = 7,
                        StartTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        EndTime = DateTime.Now.AddDays(6).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        ExitCode = 0,
                        Pid = 1
                    }
                });
        }
    }
}
