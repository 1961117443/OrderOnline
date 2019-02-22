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
        public override Task<bool> Add(SectionBar model)
        {
            model.ID = Guid.NewGuid();
            return base.Add(model);
        }
        protected ISectionBarRepository sectionBarRepository;
        public SectionBarService(ISectionBarRepository sectionBarRepository)
        {
            this.sectionBarRepository = sectionBarRepository;
        }
        public List<SectionBar> LoadData(Expression<Func<SectionBar, bool>> whereExpression)
        { 
            return new List<SectionBar>();
        }
         

        //public async Task<List<SectionBar>> LoadDataAsync(Expression<Func<SectionBar, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        //{
        //    return await sectionBarRepository.LoadDataAsync(whereExpression, intPageIndex, intPageSize);
        //}
    }
}
