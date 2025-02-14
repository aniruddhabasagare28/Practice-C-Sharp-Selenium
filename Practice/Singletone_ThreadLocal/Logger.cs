using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Singletone_ThreadLocal
{
    public class Logger
    { 
        private static Logger instance;
        private static readonly Object lockObj = new Object();
        private string logFile = "logtext.log";

        private Logger()
        {

        }

        public static Logger GetInstance()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {

                        instance = new Logger();
                    }
                }
            }
            return instance;
        }
        public void Log(string message)
        {
            lock (lockObj)
            {
                File.AppendAllText(logFile, message);
            }
        }
    }
}
