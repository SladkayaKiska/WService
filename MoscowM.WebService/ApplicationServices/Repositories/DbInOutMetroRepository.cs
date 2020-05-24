using MoscowM.ApplicationServices.Ports.Gateways.Database;
using MoscowM.DomainObjects;
using MoscowM.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoscowM.ApplicationServices.Repositories
{
    public class DbInOutMetroRepository : IReadOnlyInOutMetroRepository,
                                     IInOutMetroRepository
    {
        private readonly IMetroDatabaseGateway _databaseGateway;

        public DbInOutMetroRepository(IMetroDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<InOutMetro> GetInOutMetro(long id)
            => await _databaseGateway.GetInOutMetro(id);

        public async Task<IEnumerable<InOutMetro>> GetAllInOutMetros()
            => await _databaseGateway.GetAllInOutMetros();

        public async Task<IEnumerable<InOutMetro>> QueryInOutMetros(ICriteria<InOutMetro> criteria)
            => await _databaseGateway.QueryInOutMetros(criteria.Filter);

        public async Task AddInOutMetro(InOutMetro inoutmetro)
            => await _databaseGateway.AddInOutMetro(inoutmetro);

        public async Task RemoveInOutMetro(InOutMetro inoutmetro)
            => await _databaseGateway.RemoveInOutMetro(inoutmetro);

        public async Task UpdateInOutMetro(InOutMetro inoutmetro)
            => await _databaseGateway.UpdateInOutMetro(inoutmetro);
    }
}
