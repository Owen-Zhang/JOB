using System;
using System.Reflection;

namespace Job_FrameWork
{
    public class JobManager
    {
        /// <summary>
        /// 执行TASK，支持自定义参数
        /// </summary>
        /// <param name="typeTask">Task 名称</param>
        /// <param name="extenParams">自定义参数，该参数需要在Task实现中自行处理，在Task的构造函数中接收该参数</param>
        public static void Run(Type typeJob, string[] args)
        {
            if (typeJob == null || !typeof(BaseJob).IsAssignableFrom(typeJob)) return;

            var method = typeJob.GetMethod("Run", new[]{ typeof(string[]) });
            var construct = Activator.CreateInstance(typeJob, null);
            if (construct == null)
            {
                Console.WriteLine("{0} need constructor", typeJob.FullName);
                return;
            }

            method.Invoke(construct, new object[] { args });
        }
    }
}
