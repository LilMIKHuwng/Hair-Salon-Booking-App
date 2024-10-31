using HairSalon.Core;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace HairSalon.RazorPage.Pages.Role
{
    public class GetAllModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public GetAllModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<RoleModelView> Roles { get; set; } = new List<RoleModelView>(); // Initialize to avoid null reference
        public int TotalCount { get; set; }
        public int PageNumber { get; set; } = 1; // Default page number
        public int PageSize { get; set; } = 5; // Default page size

        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 5)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;

            // Retrieve the AuthToken from cookies
            var token = Request.Cookies["AuthToken"];

            // Set the Authorization header for the API request
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Call the API to get all roles with pagination
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7286/api/role/all?pageNumber={PageNumber}&pageSize={PageSize}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                // Use JObject to parse the response and extract the items
                var jsonObject = JObject.Parse(responseBody);
                var itemsArray = jsonObject["items"]["$values"];

                Roles = itemsArray.ToObject<List<RoleModelView>>() ?? new List<RoleModelView>();
                TotalCount = jsonObject["totalItems"].Value<int>(); // Get the total items count

            }
            else
            {
                // Handle errors (e.g., log the error, display a message)
                Roles = new List<RoleModelView>(); // Initialize roles list
                TotalCount = 0; // Set total count to 0
                                // You might want to log the error message or set an error message to display on the page
            }
        }

        public IActionResult OnPostPageChange(int pageNumber)
        {
            // Redirect to the same page with the new page number
            return RedirectToPage(new { pageNumber });
        }
    }
}
