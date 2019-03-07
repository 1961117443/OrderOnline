using AutoMapper;
using Order.DataEntity;
using Order.ViewEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOnline.AutoMapperConfig
{
    /// <summary>
    /// 映射配置类，可以项目中的任何文件夹下，扩展代码中是通过反射找出程序集中的所有映射配置
    /// </summary>
    public class EntityToViewModelMappingProfile : Profile
    {
        public EntityToViewModelMappingProfile()
        {
            #region 基础资料
            CreateMap<SectionBar, SectionBarDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Surface, SurfaceDto>();
            #endregion

            #region 订单管理
            CreateMap<SalesOrder, SalesOrderDto>();

            CreateMap<SalesOrderDetail, SalesOrderDetailDto>()
                .ForMember(w => w.PackingName, opt => opt.MapFrom(w => w.Packing.Name));
            CreateMap<SalesOrderDetail, SalesOrderDetailDto>().ForMember(w => w.SurfaceName, opt => opt.MapFrom(w => w.Surface.Name)); 
            #endregion
        }
    }
}
