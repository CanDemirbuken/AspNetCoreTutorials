using _09._Bank_App_Tutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace _09._Bank_App_Tutorial.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            //Response.StatusCode = 200;
            return Content("<h1>Welcome to the Best Bank</h1>", "text/html");
        }

        [Route("/account-details")]
        public IActionResult Details()
        {
            if (!Request.Path.Equals("/account-details"))
            {
                return BadRequest("Please provide a valid url for details");
            }

            AccountDetails accountDetails = new AccountDetails()
            {
                AccountNumber = 1001,
                AccountHolderName = "John Doe",
                CurrentBalance = 10000
            };

            return Json(accountDetails);
        }

        [Route("/account-statement")]
        public IActionResult Statement()
        {
            if (!Request.Path.Equals("/account-statement"))
            {
                return BadRequest("Please provide a valid url for statement");
            }

            return File("/test.pdf", "application/pdf");
        }

        [Route("/get-current-balance")]
        public IActionResult GetCurrentBalance()
        {
            AccountDetails accountDetails = new AccountDetails()
            {
                AccountNumber = 1001,
                AccountHolderName = "John Doe",
                CurrentBalance = 10000
            };

            if (!Request.Query.ContainsKey("accountNumber"))
            {
                return NotFound("Account Number should be supplied.");
            }

            int accountNumber = Convert.ToInt16(Request.Query["accountNumber"]);
            if (accountNumber != 1001)
            {
                return BadRequest("Account Number should be 1001");
            }

            return Content($"{accountDetails.CurrentBalance.ToString()}", "text/html");

        }
    }
}
