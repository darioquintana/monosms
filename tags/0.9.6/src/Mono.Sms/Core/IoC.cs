using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Castle.Core.Resource;
using Castle.MicroKernel;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Mono.Sms.Core.Provider;

namespace Mono.Sms.Core
{
    public class IoC
    {
        private static IoC ioC = null;

        private IWindsorContainer container =
            new WindsorContainer(new XmlInterpreter(new ConfigResource("castle")));

        private IoC()
        {
        }

        public static IoC Instance
        {
            get
            {
                if (ioC == null)
                {
                    ioC = new IoC();
                }
                return ioC;
            }
        }

        public IWindsorContainer Container
        {
            get { return container; }
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public T Resolve<T>(string name)
        {
            return Resolve<T>(name);
        }

        public T Resolve<T>(string message, CelNumber number) where T : IProvider
        {
            IDictionary args = new ListDictionary();

            args.Add("message", message);
            args.Add("number", number);

            return (T) container.Kernel.Resolve(typeof (T), args);
        }

        public IList<IProvider> GetAllProviders()
        {
            IHandler[] handles = container.Kernel.GetHandlers(typeof (IProvider));
            IList<IProvider> providersImpl = new List<IProvider>();

            foreach (IHandler hdlr in handles)
            {
                providersImpl.Add((IProvider) hdlr.Resolve(CreationContext.Empty));
            }

            return providersImpl;
        }
    }
}