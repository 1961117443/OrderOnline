using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Order.DataEntity;
using Order.IRepository;
using Order.IService;
using Order.IService.BASE;
using Order.Service.BASE;
using Order.ViewEntity;

namespace Order.Service
{
    public class SectionBarService : BaseService<SectionBar>, ISectionBarService, IBillService<SectionBar, SectionBarDto>
    {
        protected ISectionBarRepository sectionBarRepository;
        public SectionBarService(ISectionBarRepository sectionBarRepository)
        {
            this.sectionBarRepository = sectionBarRepository;
        }
        public List<SectionBarDto> LoadData(Expression<Func<SectionBarDto, bool>> whereExpression)
        { 
            return new List<SectionBarDto>();
        }

        public Task<List<SectionBarDto>> LoadDataAsync(Expression<Func<SectionBarDto, bool>> whereExpression)
        {
            throw new NotImplementedException();
        }
    }
}
