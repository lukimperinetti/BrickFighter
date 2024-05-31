using System;
using System.Collections.Generic;

namespace BrickFighter.Services
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> Services = new Dictionary<Type, object>();

        public static void Register<T>(T service)
        {
            var type = typeof(T);
            if (!Services.ContainsKey(type))
            {
                Services.Add(type, service);
            }
        }

        public static T Get<T>()
        {
            var type = typeof(T);
            if (Services.ContainsKey(type))
            {
                return (T)Services[type];
            }
            throw new Exception($"Service of type {type} not registered.");
        }

        public static void Unregister<T>()
        {
            var type = typeof(T);
            if (Services.ContainsKey(type))
            {
                Services.Remove(type);
            }
        }
    }
}
