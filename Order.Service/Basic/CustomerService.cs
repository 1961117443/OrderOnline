using System;
using System.Threading.Tasks;
using Order.DataEntity;
using Order.IRepository;
using Order.IService;
using Order.Service.BASE;

namespace Order.Service
{
    public class CustomerService : BaseService<Customer>,ICustomerService
    {
        protected readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public override Task<bool> Add(Customer model)
        {
            model.ID = Guid.NewGuid();
            model.RowNo = 1;
            return base.Add(model);
        }
    }
}
