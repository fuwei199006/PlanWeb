using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Job;

namespace Plain.Job
{
    public class TestJob:JobBase
    {
        public TestJob(string jobName, Action<string> action) : base(jobName, action)
        {
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
