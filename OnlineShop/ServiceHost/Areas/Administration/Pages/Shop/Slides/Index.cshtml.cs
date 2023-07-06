using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.PoductPicture;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.Slide;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string message { get; set; }
        private readonly ISlideApplication _slideApplication;

        public List<SlideViewModel> Slides;

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication=slideApplication;
        }


        public void OnGet()
        {
            Slides = _slideApplication.GetList();
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateSlide();
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateSlide command)
        {
            var result = _slideApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var slide = _slideApplication.GetDetails(id);
            return Partial("Edit", slide);
        }
        public JsonResult OnPostEdit(EditSlide command)
        {
            var result = _slideApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
           var result = _slideApplication.Remove(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            var result = _slideApplication.Restore(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
