using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocExample
{

    class MyKernel
    {
        private Dictionary<Type, Type> typeToType;
        private Dictionary<Type, Func<object>> typeToConstructor;

        public MyKernel()
        {
            typeToType = new Dictionary<Type, Type>();
            typeToConstructor = new Dictionary<Type, Func<object>>();

    }

        //public Func<object> Inject(Type t)
        //{
        //    return () => Get(t);
        //}
        public void Bind<T1,T2>()
        {

            typeToType.Add(typeof(T1), typeof(T2));

        }
        public void BindToConstructor<T>(Func<object> constructor)
        {
           typeToConstructor.Add(typeof(T), constructor);

        }

        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }

        private object Get(Type type)
        {
            try
            {

                var currentType = type;
                if (!typeToConstructor.ContainsKey(currentType))
                {
                    if (typeToType.ContainsKey(type))
                    {
                        currentType = typeToType[type];
                        if (!typeToConstructor.ContainsKey(currentType))
                        {
                            var constructor = Utils.GetSingleConstructor(currentType);
                            var parameters = constructor.GetParameters();
                            List<Object> definedParameters = new List<object>();

                            foreach (var parameter in parameters)
                            {
                                definedParameters.Add(Get(parameter.ParameterType));
                            }
                            typeToConstructor.Add(currentType, () => Utils.CreateInstance(currentType, definedParameters));

                        }
                        return typeToConstructor[currentType]();
                    }
                    else throw new KeyNotFoundException($"{type.ToString()} не найден");
                }
                else return typeToConstructor[currentType]();



            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
           
        }
    }
}
