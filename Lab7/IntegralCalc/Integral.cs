using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralCalc
{
    public class Integral
    {
        public delegate void ExecTime(TimeSpan timeSpan);
        public event ExecTime? ExecutionTime;

        public delegate void ProgressFactor(int res);
        public event ProgressFactor? Progress;

        private Semaphore semaphore = new Semaphore(2, 2);

        public Integral() { }

        public void ComputeIntegralSin(double step, double from, double to)
        {
            double result = 0;
            int lastProgress = 0;
            semaphore.WaitOne();
            Stopwatch sw = Stopwatch.StartNew();
            for (double i = from; i <= to; i += step)
            {
                result += step * Math.Sin(i);
                // вычисления для увеличения времени выполнения
                /*for (int j = 0; j < 100000; j++)  
                {
                    int a = j + j;
                }*/
                int progress = Convert.ToInt32((i - from) / (to - from) * 100.0) / 10 * 10;
                if (progress != lastProgress)
                {
                    Progress?.Invoke(progress);
                    lastProgress = progress;
                }
            }
            ExecutionTime?.Invoke(sw.Elapsed);
            semaphore.Release();
        }
    }
}
