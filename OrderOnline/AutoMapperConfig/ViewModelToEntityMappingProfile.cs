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
    public class ViewModelToEntityMappingProfile: Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<SectionBarDto, SectionBar>();

            CreateMap<SalesOrderDto, SalesOrder>();
            CreateMap<SalesOrderDetailDto, SalesOrderDetail>();

        }
    }
}
