using CustomDIFramework.Attributes;
using CustomDIFramework.Modules;
using System;
using System.Linq;
using System.Reflection;

namespace CustomDIFramework.Injectors
{
    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            var hasCtorAttribute = CheckForConstructorInjection<TClass>();
            var hasFieldAttribute = CheckForFieldInjection<TClass>();

            if (hasCtorAttribute && hasFieldAttribute)
            {
                throw new ArgumentException("There must be only field or constructor annotated with Inject attribute");
            }

            if (hasCtorAttribute)
            {
                return CreateConstructorInjection<TClass>();
            }
            else if (hasFieldAttribute)
            {
                return CreateFieldInjection<TClass>();
            }

            return default(TClass);
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            var currentClass = typeof(TClass);

            if (currentClass == null)
            {
                return default(TClass);
            }

            var constructors = currentClass.GetConstructors();
            foreach (var ctor in constructors)
            {
                if (!CheckForConstructorInjection<TClass>())
                {
                    continue;
                }

                var inject = (Inject)ctor
                    .GetCustomAttributes(typeof(Inject), true)
                    .FirstOrDefault();
                var parameterTypes = ctor.GetParameters();
                var ctorParams = new object[parameterTypes.Length];
                int i = 0;

                foreach (var parameterType in parameterTypes)
                {
                    var named = parameterType.GetCustomAttributes(typeof(Named));
                    Type dependency = null;

                    if (named == null)
                    {
                        dependency = module.GetMapping(parameterType.ParameterType, inject);
                    }
                    else
                    {
                        dependency = module.GetMapping(parameterType.ParameterType, named);
                    }

                    this.GetType().GetMethod(nameof(Inject)).MakeGenericMethod(dependency).Invoke(this, null);

                    if (parameterType.ParameterType.IsAssignableFrom(dependency))
                    {
                        var instance = module.GetInstance(dependency);

                        if (instance != null)
                        {
                            ctorParams[i++] = instance;
                        }
                        else
                        {
                            instance = Activator.CreateInstance(dependency);
                            ctorParams[i++] = instance;
                            module.SetInstance(parameterType.ParameterType, instance);
                        }
                    }

                }

                return (TClass)Activator.CreateInstance(currentClass, ctorParams);
            }

            return default(TClass);
        }

        private TClass CreateFieldInjection<TClass>()
        {
            var currentClass = typeof(TClass);
            var currentClassInstance = module.GetInstance(currentClass);

            if (currentClassInstance == null)
            {
                currentClassInstance = Activator.CreateInstance(currentClass);
                module.SetInstance(currentClass, currentClassInstance);
            }

            var fields = currentClass.GetFields((BindingFlags)62);
            foreach (var field in fields)
            {
                if (field.GetCustomAttributes(typeof(Inject), true).Any())
                {
                    var injection = (Inject)field
                        .GetCustomAttributes(typeof(Inject), true)
                        .FirstOrDefault();
                    Type dependency = null;

                    var named = field.GetCustomAttributes(typeof(Named), true);
                    var type = field.FieldType;

                    if (named == null)
                    {
                        dependency = module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependency = module.GetMapping(type, named);
                    }

                    if (type.IsAssignableFrom(dependency))
                    {
                        var instance = module.GetInstance(dependency);

                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            module.SetInstance(type, instance);
                        }

                        field.SetValue(currentClassInstance, instance);
                    }
                }
            }

            return (TClass)currentClassInstance;
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(ctor => ctor.GetCustomAttributes(typeof(Inject), true).Any());
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags)62)
                .Any(field => field.GetCustomAttributes(typeof(Inject), true).Any());
        }
    }
}
