using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Exam70_483.SingletonPattern
{
    public class Singleton
    {
        private static readonly object _lock = new object();
        private static Singleton _instance;
        public static Singleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                    return _instance;
                }
            }
        }
        private Singleton()
        {

        }
    }
}
