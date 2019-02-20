using Order.DataEntity;
using Order.IService.BASE;
using Order.ViewEntity;

namespace Order.IService
{
    public interface ISectionBarService : IBaseService<SectionBar>,IBillService<SectionBar, SectionBarDto>
    {
    }
}
