using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Countries.Helpers
{
    public static class CacheHelper
    {
        public static string GetCacheKey(string action, string key = null)
        {
            if(key != null)
            {
                return $"{action}:{key}";
            }

            return $"{action}";
        }

    }
}
