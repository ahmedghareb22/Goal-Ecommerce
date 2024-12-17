using Microsoft.AspNetCore.Authorization;

namespace Goal.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository contactRepository;

        public ContactController(IContactRepository contactRepository) {
            this.contactRepository = contactRepository;
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult SaveContact(Contact contact)
        {
            contact.CustomerId = int.Parse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            contactRepository.Add(contact);
            return RedirectToAction("Contact");
        }
    } 
}
