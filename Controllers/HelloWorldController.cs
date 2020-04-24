using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace slgMultifunctional.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/
        // Every public method in a Controller derived class is callable from an HTTP endpoint
        //The first comment states this is an HTTP GET method that's invoked by appending /HelloWorld/ to the base URL. The
        //second comment specifies an HTTP GET method that's invoked by appending /HelloWorld/Welcome/ to the URL. Later
        //on in the tutorial the scaffolding engine is used to generate HTTP POST methods which update data


        //public string Index()
        //{
        //    return "This is my default action...";
        //}

        //This code calls the controller's View method. It uses a view template to generate an HTML 
        //response. Controller methods (also known as action methods), such as the Index method above,generally return 
        //an IActionResult (or a class derived from ActionResult), not a type like string
        public IActionResult Index()
        {
            return View();
        }
        /*
         * For above, Navigate to https://localhost:{PORT}/HelloWorld. The Index method in the HelloWorldController didn't do much; 
         * it ran the statement return View();, which specified that the method should use a view template file to render 
         * a response to the browser. Because a view template file name wasn't specified, MVC defaulted to using the default view file. 
         * The default view file has the same name as the method (Index), so in 
         * the /Views/HelloWorld/Index.cshtml is used. The folder name "HellowWorld" must match the Controller, hence it can find the index.cshtml.
         * The image below shows the string "Hello from our View Template!" 
         * hard-coded in the view
         */

        // 
        // GET: /HelloWorld/Welcome/
        // Notice the REST call uses HellowWorld, not HellowWorldContorller. All controllers must have the Contorller suffix, but not used in the call

        //public string Welcome()
        //public string Welcome(string name, int numTimes = 1)
        //public string Welcome(string name, int ID = 1)
        //{
            //return "This is the Welcome action method...";

            //Uses HtmlEncoder.Default.Encode to protect the app from malicious input(namely JavaScript).
            //return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        //    return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        //}


        // Now we use the dynamic object and predefoined object, ViewData that will contain data the view can use. 
        // this is proper seperation of MVC duties
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
