using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ComboModelViews;
using HairSalon.ModelViews.ServiceModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Combo
{
    public class DetailModel : PageModel
    {
        private readonly IComboService _comboService;
        private readonly IServiceService _serviceService;

        public DetailModel(IComboService comboService, IServiceService serviceService)
        {
            _comboService = comboService;
            _serviceService = serviceService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public ComboModelView ComboDetail { get; set; }
        public IEnumerable<ServiceModelView> SelectedServices { get; set; } 

        public async Task<IActionResult> OnGetAsync()
        {
            ComboDetail = await _comboService.GetComboByIdAsync(Id);
            if (ComboDetail == null)
            {
                TempData["ErrorMessage"] = "Combo not found.";
                return RedirectToPage("/Combos");
            }

            if (ComboDetail.ServiceIds != null && ComboDetail.ServiceIds.Any())
            {
                SelectedServices = await _serviceService.GetByIdsAsync(ComboDetail.ServiceIds);
            }
            else
            {
                SelectedServices = Enumerable.Empty<ServiceModelView>();
            }

            return Page();
        }
    }
}
