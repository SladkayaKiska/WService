using MoscowM.ApplicationServices.Ports.Cache;
using MoscowM.DomainObjects;
using MoscowM.DomainObjects.Ports;
using MoscowM.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoscowM.InfrastructureServices.Repositories
{
    public class CachedReadOnlyInOutMetroRepository : ReadOnlyInOutMetroRepositoryDecorator
    {
        private readonly IDomainObjectsCache<InOutMetro> _inoutmetrosCache;

        public CachedReadOnlyInOutMetroRepository(IReadOnlyInOutMetroRepository inoutmetroRepository, 
                                             IDomainObjectsCache<InOutMetro> inoutmetrosCache)
            : base(inoutmetroRepository)
            => _inoutmetrosCache = inoutmetrosCache;

        public async override Task<InOutMetro> GetInOutMetro(long id)
            => _inoutmetrosCache.GetObject(id) ?? await base.GetInOutMetro(id);

        public async override Task<IEnumerable<InOutMetro>> GetAllInOutMetros()
            => _inoutmetrosCache.GetObjects() ?? await base.GetAllInOutMetros();

        public async override Task<IEnumerable<InOutMetro>> QueryInOutMetros(ICriteria<InOutMetro> criteria)
            => _inoutmetrosCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryInOutMetros(criteria);

    }
}
