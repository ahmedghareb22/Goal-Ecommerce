namespace Goal.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDpContext _context;

        public AdminRepository(AppDpContext context)
        {
            _context = context;
        }
        public AdminDashboardViewModel GetValues()
        {
            var orders = _context.Orders
                .Include(c=>c.Customer)
                .Select(p=>new Order{
                    Total =  p.Total,
                    CreateAt = p.CreateAt,
                    Customer =p.Customer,
                    IsCash = p.IsCash
            }).ToList();
            
            DateTime date = DateTime.Now;

            // Define date ranges
            DateTime firstDayOfThisMonth = new DateTime(date.Year, date.Month, 1);
            DateTime firstDayOfLastMonth = firstDayOfThisMonth.AddMonths(-1);
            DateTime lastDayOfLastMonth = firstDayOfThisMonth.AddDays(-1);
  
            DateTime lastDay = date.AddDays(-1);

            // Initialize the ViewModel
            AdminDashboardViewModel adminDashboardViewModel = new AdminDashboardViewModel
            {
                Total = (int)orders.Sum(t => t.Total),
                ThisMonth = (int)orders
                    .Where(m => m.CreateAt >= firstDayOfThisMonth)
                    .Sum(t => t.Total),
                Today = (int)orders
                    .Where(m => m.CreateAt >= lastDay)
                    .Sum(t => t.Total),
                NumOrder = orders.Count(),
                order = orders

            };
            var lastmonth = (int)orders
                    .Where(m => m.CreateAt >= lastDayOfLastMonth && m.CreateAt <= firstDayOfLastMonth)
                    .Sum(t => t.Total);

            if(lastmonth != 0)
                adminDashboardViewModel.LastMonth =
                    (decimal)((adminDashboardViewModel.ThisMonth - lastmonth) / lastmonth) * 100;
            else
                adminDashboardViewModel.LastMonth = adminDashboardViewModel.ThisMonth * 100;

            var lastday = (int)orders
                    .Where(m => m.CreateAt >= lastDay.AddDays(-1) && m.CreateAt <=lastDay)
                    .Sum(t => t.Total);

            if (lastday != 0)
                adminDashboardViewModel.LastDay = 
                    (decimal)((adminDashboardViewModel.Today - lastday) / lastday) * 100;
            else
                adminDashboardViewModel.LastDay = adminDashboardViewModel.Today * 100;

            var orderMonth = orders
                .Where(m => m.CreateAt >= firstDayOfThisMonth)
                .Count();
            var orderLastmonth = orders
                .Where(m => m.CreateAt >= lastDayOfLastMonth && m.CreateAt <= firstDayOfLastMonth)
                .Count();

            if (orderLastmonth != 0)
                adminDashboardViewModel.NumOrderLastMonth = (decimal)((orderMonth - orderLastmonth) / orderLastmonth) * 100;
            else
                adminDashboardViewModel.NumOrderLastMonth = orderMonth * 100;

            adminDashboardViewModel.TotalUser = _context.Users.Count();
            var userThisMonth = _context.Users.Where(m => m.CreateAt >= firstDayOfThisMonth).Count();
            var userLastMonth = _context.Users.Where(m => m.CreateAt >= firstDayOfThisMonth).Count();

            if (userLastMonth != 0)
                adminDashboardViewModel.NewUserLastMonth = (decimal)((userThisMonth - userLastMonth) / userLastMonth) * 100;
            else
                adminDashboardViewModel.NewUserLastMonth = userThisMonth * 100;


            return adminDashboardViewModel;
        }
        public List<CustomerViewModel> GetCustomer()
        {
            var c = _context.Users.ToList();
            List<CustomerViewModel> customer = new List<CustomerViewModel>();
            foreach(var item in c )
            {
                CustomerViewModel p = new CustomerViewModel();
                p.Name = item.FullName;
                p.Date = DateOnly.FromDateTime(item.CreateAt.Value);
                p.IsActive = true;
                customer.Add(p);
            }


            return customer;
        }


        public List<Contact> contacts()
        {
            var i = _context.Contacts.ToList();
            return i;
        }
        public void DelContact(int id)
        {
            var c = _context.Contacts.Find(id);
            _context.Contacts.Remove(c);
            _context.SaveChanges();
        }


    }
}
