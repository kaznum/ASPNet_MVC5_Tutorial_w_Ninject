using AddressBookManagerDomain.Contexts;
using AddressBookManagerDomain.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public abstract class AbstractController : Controller
    {
        protected IContextRepositories R;
        protected IKernel Kernel;


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                R.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}