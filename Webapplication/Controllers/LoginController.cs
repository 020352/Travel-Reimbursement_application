using Microsoft.AspNetCore.Mvc;
using Webapplication.Models;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Webapplication.Controllers
{[Log]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpAccount signupaccount)
        {
            if(Validation.validateDetails(signupaccount)==1)
            {
                if(ModelState.IsValid)
                 return RedirectToAction("Index","Home");
                return View();
            }
            else if(Validation.validateDetails(signupaccount)==2)
            {
                ViewBag.Message="Password doesnot match";
                return View("Signup");
            }
            else if(Validation.validateDetails(signupaccount)==3)
            {
                ViewBag.Message="Invalid Username or Password";
                return View("Signup");
            }

            else if(Validation.validateDetails(signupaccount)==4)
            {
                ViewBag.Message="Invalid ID";
                return View("Signup");
            }
            else if(Validation.validateDetails(signupaccount)==5)
            {
                ViewBag.Message="User already exists";
                return View("Signup");
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public IActionResult LoginPage()
        {
            HttpContext.Session.SetString("Session","");
            return View();
        }

        [HttpPost]
        public IActionResult LoginPage(Account account) 
        {
            if(account.EmployeeId==account.Password)
            {
                ModelState.AddModelError("id","The id and password should not be same");
            }
            if(Validation.validateLogin(account)==1)
            {
                if(ModelState.IsValid)
                {
                HttpContext.Session.SetString("Session",account.EmployeeId);
                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                Trace.AutoFlush=true;
                Trace.WriteLine("Logged in successfully");
                var cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("LastLoginTime",DateTime.Now.ToString(),cookieOptions);
                Console.WriteLine(Request.Cookies["LastLoginTime"]);
                TempData["Time"]="Last Login:"+Request.Cookies["LastLoginTime"];
                return RedirectPreserveMethod("~/Employee/Start");
                }
                return View();
            }
            else if(Validation.validateLogin(account)==2)
            {
                ViewBag.Message="Invalid Password";
                return View("LoginPage");
            }
            else if(Validation.validateLogin(account)==3)
            {
                ViewBag.Message="User doesnot exists";
                return View("LoginPage");
            }
            else if(Validation.validateLogin(account)==4)
            {
                HttpContext.Session.SetString("Session",account.EmployeeId);
                return RedirectToAction("Home","Admin");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPassword forgotPassword)
        {
            if(ModelState.IsValid)
            {
                if(Validation.changePassword(forgotPassword)==1)
                 return View("Thanks");
                else if(Validation.changePassword(forgotPassword)==2)
                {
                    ViewBag.Message="User doesot exists";
                    return View("Forgotpassword");
                } 
            }
            return View();
        }
    }
}