using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy.Internal;

namespace InJect.Impl
{
    public class AutoMap
    {
        private static Assembly _assembly;
        
        private AutoMap(){}
        
        public static AutoMap ForAssembly(Action<AssemblyConfig> configure)
        {
            var config = new AssemblyConfig();
            configure?.Invoke(config);
            _assembly = config.Assembly;
            return new AutoMap();
        }

        public Injectable[] AllToBaseTypes()
        {
            var types = _assembly.GetTypes().Where(t => !t.IsAbstract || !t.IsInterface).ToArray();
            var injectables = new Injectable[types.Length];
            for (var i = 0; i < types.Length; i++)
            {

                var interfaces = types[i].GetAllInterfaces();
                var baseType = interfaces.Length != 0 ? interfaces[0] : types[i];
                injectables[i] = Injectable.Implements(types[i]).For(baseType);
            }

            return injectables;
        }
    }

    public class AssemblyConfig
    {
        public Assembly Assembly { get; private set; }
        
        public void WithName(string assemblyName)
        {
             Assembly = AppDomain.CurrentDomain.GetAssemblies()
                .SingleOrDefault(a => a.GetName().Name == assemblyName);
        }

        public void ForType(Type type)
        {
            Assembly = type.Assembly;
        }
    }
}