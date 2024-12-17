using Goal.Models;

namespace Goal.IRepository
{
    public interface IContactRepository
    {
        public void Add(Contact contact);
        public List<Contact> GetAll();
        public void Delete(int id);
    }
}
