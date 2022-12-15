using Castle.DynamicProxy;

namespace TaskSehirTeknolojileri_Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
