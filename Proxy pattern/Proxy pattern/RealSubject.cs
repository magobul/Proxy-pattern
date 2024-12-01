using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_pattern
{
    public class RealSubject : Subject
    {
        public string Request(string request)
        {
            Console.WriteLine("RealSubject: Обработка запроса...");
            return $"Ответ на запрос: {request}";
        }
    }
}
