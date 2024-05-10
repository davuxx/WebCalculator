using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Infrastructure.Loggers
{
    public class FileLogger : ILogger
    {
        public void Log(Exception exception)
        {

            using (StreamWriter sw = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now} - {exception.Message}\n\n");
            }
            throw new NotImplementedException();
        }
    }
}
