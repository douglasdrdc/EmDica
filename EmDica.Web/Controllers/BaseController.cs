using EmDica.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace EmDica.Web.Controllers
{
    public class BaseController : Controller
    {
        public static readonly log4net.ILog loggerAplicacao = log4net.LogManager.GetLogger("LogAplicacao");
    }
}