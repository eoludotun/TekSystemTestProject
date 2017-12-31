using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekSystemTestProject.TestHelperFolder
{
    public class BaseClass_Utility
    {
        /// <summary>
        /// NLog logger handle
        /// </summary>
        private static Logger _logger;
        //   Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
        //Singleton Logger
        public static Logger Logger()
        {
            if (_logger == null)
                _logger = LogManager.GetCurrentClassLogger();
            return _logger;

        }

        public int GetMaxStates(int[] arr)
        {
            var max = arr[0];
            var idx = 0;
            for (int i = arr.Length / 2; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }

                if (arr[idx] > max)
                {
                    max = arr[idx];
                }
                idx++;
            }
            Console.Write("The max state find is : " + max + "\r\n");
            return max;
        }
    }

}
