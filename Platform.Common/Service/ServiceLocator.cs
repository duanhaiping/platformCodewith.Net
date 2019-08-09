using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Platform.Common.Service
{
    public static class ServiceLocator
    {
        private static readonly IUnityContainer container = new UnityContainer();
        private static readonly UnityConfigurationSection section = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;

        public static T GetService<T>(string name = "")
        {
            section.Configure(container, "Default");
            if (string.IsNullOrWhiteSpace(name))
            {
                if (container.IsRegistered<T>())
                {
                    return container.Resolve<T>();
                }
            }
            else
            {
                if (container.IsRegistered<T>(name))
                {
                    return container.Resolve<T>(name);
                }
            }

            return default(T);
        }
    }
}
