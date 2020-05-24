using MoscowM.ApplicationServices.Ports.Cache;
using MoscowM.DomainObjects;
using MoscowM.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoscowM.InfrastructureServices.Repositories
{
    public class NetworkInOutMetroRepository : NetworkRepositoryBase, IReadOnlyInOutMetroRepository
    {
        private readonly IDomainObjectsCache<InOutMetro> _inoutmetroCache;

        public NetworkInOutMetroRepository(string host, ushort port, bool useTls, IDomainObjectsCache<InOutMetro> inoutmetroCache)
            : base(host, port, useTls)
            => _inoutmetroCache = inoutmetroCache;

        public async Task<InOutMetro> GetInOutMetro(long id)
            => CacheAndReturn(await ExecuteHttpRequest<InOutMetro>($"inoutmetros/{id}"));

        public async Task<IEnumerable<InOutMetro>> GetAllInOutMetros()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<InOutMetro>>($"inoutmetros"), allObjects: true);

        public async Task<IEnumerable<InOutMetro>> QueryInOutMetros(ICriteria<InOutMetro> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<InOutMetro>>($"inoutmetros"), allObjects: true)
               .Where(criteria.Filter.Compile());


        private IEnumerable<InOutMetro> CacheAndReturn(IEnumerable<InOutMetro> inoutmetros, bool allObjects = false)
        {
            if (allObjects)
            {
                _inoutmetroCache.ClearCache();
            }
            _inoutmetroCache.UpdateObjects(inoutmetros, DateTime.Now.AddDays(1), allObjects);
            return inoutmetros;
        }

        private InOutMetro CacheAndReturn(InOutMetro inoutmetro)
        {
            _inoutmetroCache.UpdateObject(inoutmetro, DateTime.Now.AddDays(1));
            return inoutmetro;
        }
    }
}
