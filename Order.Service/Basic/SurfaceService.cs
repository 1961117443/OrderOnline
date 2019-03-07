using Order.DataEntity;
using Order.IRepository;
using Order.IService;
using Order.Service.BASE;

namespace Order.Service
{
    public class SurfaceService : BaseService<Surface>, ISurfaceService
    {
        private readonly ISurfaceRepository surfaceRepository;

        public SurfaceService(ISurfaceRepository surfaceRepository)
        {
            this.surfaceRepository = surfaceRepository;
        }
    }
}
