using Goal.Models;

namespace Goal.IRepository
{
    public interface IPaymentRepository
    {
        public void Add(Payment payment);
        public void Update(Payment payment);
        public void Delete(int id);
        public List<Payment> Get(int Customerid);
        public void save();
    }
}
