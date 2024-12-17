namespace Goal.IRepository
{
    public interface IAdminRepository
    {
        public AdminDashboardViewModel GetValues();
        public List<CustomerViewModel> GetCustomer();
        public List<Contact> contacts();
        public void DelContact(int id);
    }
}
