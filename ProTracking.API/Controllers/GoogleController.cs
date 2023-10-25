using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using ProTracking.Domain.Entities;
using ProTracking.API.Services.IServices;
using ProTracking.Domain.Enums;

namespace ProTracking.API.Controllers
{
    public class GoogleController : Controller
    {
        private readonly ICustomerService customerService;

        public GoogleController(ICustomerService _customerService)
        {
            this.customerService = _customerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("login")]
        [SwaggerOperation(Summary = "Initiate Google login")]
        public async Task Login()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }

        [HttpGet("response")]
        [SwaggerOperation(Summary = "Handle Google authentication response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!result.Succeeded)
            {
                // Handle authentication failure
                return BadRequest();
            }

            var claims = result.Principal.Claims;
            var emailClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            if (emailClaim == null)
            {
                // Email claim is missing; unable to create a customer without an email
                return BadRequest("Email claim is missing.");
            }

            var email = emailClaim.Value;

            // Check if a customer with this email already exists in the database
            var existingCustomer = await customerService.GetCustomerByEmailAsync(email);
            string birthdateClaimValue = claims.FirstOrDefault(c => c.Type == "birthdate")?.Value;
            DateTime? birthdate = null;

            if (!string.IsNullOrEmpty(birthdateClaimValue) && DateTime.TryParse(birthdateClaimValue, out var parsedDate))
            {
                birthdate = parsedDate;
            }
            if (existingCustomer == null)
            {
                // Customer doesn't exist, create a new customer
                var newCustomer = new Customer
                {
                    // Populate the new customer object with the information from claims
                    Username = claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value,
                    FirstName = claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value,
                    LastName = claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                    Email = email,
                    Password = null, // You may not have a password from Google authentication
                    Phone = email,
                    Birthday = birthdate ?? DateTime.MinValue,
                    Avatar = claims.FirstOrDefault(c => c.Type == "picture")?.Value,
                    RegisteredAt = DateTime.Now, // Set to current time
                    LastLoginAt = DateTime.Now, // Set to current time
                    Status = "Active", // Set the initial status, e.g., "Active"
                    Role = RoleEnum.Customer, // Set the role based on your application logic
                    GoogleId = claims.FirstOrDefault(c => c.Type == "sub")?.Value,
                    GoogleEmail = claims.FirstOrDefault(c => c.Type == "email")?.Value,
                    OAuthToken = null, // You may handle OAuth tokens differently
                    OAuthExpiry = DateTime.Now, // Set the OAuth expiry, e.g., current time
                    AccountTypeId = 1, // Set the appropriate account type ID
                    StartDate = DateTime.Now, // Set to current time
                    EndDate = DateTime.Now.AddYears(1) // Set an appropriate end date

                };

                // Redirect to the CustomerController to create the new customer
                return RedirectToAction("Post", "Customer", newCustomer);
            }

            // Customer already exists; continue with the rest of your logic

            return Ok();
        }


        [HttpGet("logout")]
        [SwaggerOperation(Summary = "Log the user out")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return NoContent(); // Return a response without redirection
        }
    }
}
