using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatrolSim
{
    public struct TimeModeStruct
    {
        public const double X05 = 2.0;
        public const double X10 = 1.0;
        public const double X50 = 0.2;
        public const double X100 = 0.1;
        public const double BestEffort = 0;
    }

    enum ThreadState
    {
        Run, Pause, Stop,
    }

    class SimulationManager
    {
        private double time_mode;
        public double TimeMode { set => time_mode = value; }

        private System.Diagnostics.Stopwatch _sw;
        private List<Agent> _agentlist = null;
        private ThreadState _threadState;
        private Thread _worker;

        public ThreadState CurrentState
        {
            get { return _threadState; }
            set => _threadState = value;
        }

        public SimulationManager()
        {
            time_mode = 1;
            _threadState = ThreadState.Stop;
        }

        public void Run(List<Agent> agentlist)
        {
            _agentlist = agentlist;
            _threadState = ThreadState.Run;

            _worker = new Thread(Run);
            _worker.Start();
        }

        private void Run()
        {
            while (_threadState == ThreadState.Run || _threadState == ThreadState.Pause)
            {
                if(_threadState == ThreadState.Pause)
                    Thread.Sleep(100);
                else
                    Execute();
            }
        }

        public void Terminate()
        {
            _threadState = ThreadState.Stop;
           if(_worker.IsAlive)
                _worker.Abort();
        }

        public void Pause()
        {
            _threadState = ThreadState.Pause;
        }

        public void Resume()
        {
            _threadState = ThreadState.Run;
        }

        private double Execute()
        {
            _sw = Stopwatch.StartNew();;
            long currentMilliseconds = _sw.ElapsedMilliseconds;
            foreach (Agent agent in _agentlist)
            {
                agent.Move(1);
            }
            long elapsedMilliseconds = _sw.ElapsedMilliseconds;
            // 1 sec - (ElapsedMilliseconds - CurrentMilliseconds) > 0, sleep
            // 1 sec - (ElapsedMilliseconds - CurrentMilliseconds) < 0, pass
            int compensateTime = (int)(1000*time_mode - (elapsedMilliseconds - currentMilliseconds));
            if (compensateTime > 0)
                System.Threading.Thread.Sleep((int)compensateTime);
            _sw.Stop();
            return 0;
        }
    }
}
