using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int sum(int num1, int num2)
        {
            return num1 + num2;
        }
        [WebMethod]
        public int simple_interest(int p, int r, int n)
        {
            int si = (p * r * n) / 100;
            return si;
        }
        [WebMethod]
        public string fullname(string fname, string lname)
        {
            return "Welcome" + "\n" + fname + lname;
        }
    }
}
