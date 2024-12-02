using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_pattern
{
    public class Proxy : Subject
    {
        private RealSubject _realSubject;
        private Dictionary<string, (string response, DateTime timestamp)> _cache;
        private TimeSpan _cacheDuration;

        public Proxy(TimeSpan cacheDuration)
        {
            _realSubject = new RealSubject();
            _cache = new Dictionary<string, (string response, DateTime timestamp)>();
            _cacheDuration = cacheDuration;
        }

        public string Request(string request)
        {
            
            if (!HasAccess())
            {
                return "Доступ запрещен.";
            }

            
            if (_cache.ContainsKey(request) &&
                (DateTime.Now - _cache[request].timestamp) < _cacheDuration)
            {
                Console.WriteLine("Proxy: Возврат ответа из кэша...");
                return _cache[request].response;
            }

            // Если нет в кэше, делаем запрос к RealSubject
            var response = _realSubject.Request(request);

            // Сохраняем в кэш
            _cache[request] = (response, DateTime.Now);

            return response;
        }

        private bool HasAccess()
        {
            return true; 
        }
    }
}
