using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_FrameWork
{
    public abstract class BaseJob
    {
        public virtual void Run(string[] args)
        {
            Excute(args);
        }

        public abstract void Excute(string[] args);
    }
}
