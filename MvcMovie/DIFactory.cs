using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie
{
    public class DIFactory
    {
        public static T Get<T>()
        {
            var me = new DIFactory();
            return me.GetObject<T>();
        }

        public static T Get<T>(params IParameter[] parameters)
        {
            var me = new DIFactory();
            return me.GetObject<T>(parameters);
        }

        protected T GetObject<T>()
        {
            return (T)DependencyResolver.Current.GetService(typeof(T));
        }

        protected T GetObject<T>(params IParameter[] parameters)
        {
            var kernel = (IKernel)DependencyResolver.Current.GetService(typeof(IKernel));
            return kernel.Get<T>(parameters);
        }
    }
}