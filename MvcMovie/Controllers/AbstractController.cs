using AddressBookManagerDomain.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public abstract class AbstractController : Controller
    {
        protected IAddressBookManagerEntities db;
	}
}