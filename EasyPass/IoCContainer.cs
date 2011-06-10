using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyPass
{
    public class IoCContainer
    {
        private static Dictionary<Type, object> dictionary = new Dictionary<Type, object>();

        public static void Register<T>(T instance)
        {
            dictionary.Add(typeof(T), instance);
        }

        public static T Resolve<T>()
        {
            return (T)dictionary[typeof (T)];
        }
    }
}
