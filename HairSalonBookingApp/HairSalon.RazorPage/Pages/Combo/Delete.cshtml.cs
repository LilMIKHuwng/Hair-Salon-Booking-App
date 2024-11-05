using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ComboModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Combo
{
    public class DeleteModel : PageModel
    {
        private readonly IComboService _comboService;

        public DeleteModel(IComboService comboService)
        {
            _comboService = comboService;
        }
        
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public ComboModelView Combo { get; set; }

        // Property to store error messages
        [TempData]
        public string ErrorMessage { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Combo = await _comboService.GetComboByIdAsync(Id);
            if (Combo == null)
            {
                ErrorMessage = "Combo Not Found";
                return Redirect("/Combos");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
			string response = await _comboService.DeleteComboAsync(Id);
            if (response == "Deleted combo successfully!")
            {
                ResponseMessage = response;
                return Redirect("/Combos");
            }
            // Set ErrorMessage if deletion fails
            ErrorMessage = response;
            return Page();
        }
    }
}
