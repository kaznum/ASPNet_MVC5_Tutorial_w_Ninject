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

        protected T GetObject<T>()
        {
            return (T)DependencyResolver.Current.GetService(typeof(T));

        }
    }
}