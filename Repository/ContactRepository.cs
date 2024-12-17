using Goal.IRepository;
using Goal.Models;

namespace Goal.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDpContext _context;
        public ContactRepository(AppDpContext context)
        {
            _context = context;
        }
        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var contact = _context.Contacts.Where(e => e.Id == id).FirstOrDefault();
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public List<Contact> GetAll()
        {
            var contacts= _context.Contacts.ToList();
            return contacts;
        }
    }
}
