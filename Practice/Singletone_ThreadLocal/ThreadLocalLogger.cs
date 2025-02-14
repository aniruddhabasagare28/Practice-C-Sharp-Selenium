using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Practice.Polymorphism;

namespace Practice.Singletone_ThreadLocal
{
    public class ThreadLocalLogger
    {
        private static ThreadLocal<ThreadLocalLogger> instance = new ThreadLocal<ThreadLocalLogger>();

        private ThreadLocalLogger() { } 

        public static ThreadLocalLogger GetInstance()
        {
            return instance.Value;
        }
    }
}


//Does ThreadLocal<Logger> Need Locking or Double-Checked Locking?
//No, ThreadLocal<T> inherently ensures thread safety, so we do not need explicit locking or double-checked locking.Here's why:

//1️⃣ How ThreadLocal<T> Works
//Every thread that accesses ThreadLocal<Logger> gets its own isolated instance.
//There is no shared instance between multiple threads.
//Each thread has a separate memory space for the logger.
//2️⃣ Why No Locking is Needed?
//In classic Singleton, we need a lock to prevent multiple threads from creating different instances at the same time.
//But with ThreadLocal<T>, each thread automatically gets its own instance, so locking is unnecessary.
//3️⃣ Does It Need Double-Checked Locking?
//No.Double-checked locking is used to ensure that only one instance is created in a multi-threaded environment.
//But in ThreadLocal<T>, each thread always gets its own instance, so there’s no race condition to protect against.