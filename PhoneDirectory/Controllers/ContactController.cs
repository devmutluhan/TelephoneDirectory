using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace PhoneDirectory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ContactManager _contactManager;

        public ContactController(ContactManager contactManager)
        {
            this._contactManager = contactManager;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_contactManager.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_contactManager.Get(id));
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            _contactManager.Add(contact);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactManager.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Contact contact, int id)
        {
            _contactManager.Update(contact, id);
            return Ok();
        }
    }
}
