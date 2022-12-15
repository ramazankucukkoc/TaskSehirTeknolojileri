using Castle.DynamicProxy;
using System.Reflection;

namespace TaskSehirTeknolojileri_Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methods = type.GetMethods().Where(t => t.Name == method.Name).ToList();
            foreach (var item in methods)
            {
                var methodAtt = item.GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
                foreach (var att in methodAtt)
                {
                    classAttributes.Add(att);
                }
            }
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
