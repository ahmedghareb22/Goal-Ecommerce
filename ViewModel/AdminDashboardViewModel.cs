namespace Goal.ViewModel
{
    [Keyless]
    public class AdminDashboardViewModel
    {
        public int ThisMonth { get; set; }
        public decimal LastMonth { get; set; }
        public int Today { get; set; }
        public decimal LastDay {  get; set; }
        public  int Total { get; set; }
        public int TotalUser { get; set; }
        public decimal NewUserLastMonth { get; set;}
        public int NumOrder { get; set; }
        public decimal NumOrderLastMonth { get; set; }
        public List<Order> order { get; set; }


    }
}
