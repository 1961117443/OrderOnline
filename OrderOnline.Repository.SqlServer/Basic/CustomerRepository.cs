using Order.DataEntity;
using Order.IRepository;
using Order.Repository.SqlSugar.BASE;

namespace Order.Repository.SqlSugar
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
    }
}
