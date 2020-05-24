using MoscowM.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using MoscowM.ApplicationServices.Ports.Gateways.Database;

namespace MoscowM.InfrastructureServices.Gateways.Database
{
    public class MetroEFSqliteGateway : IMetroDatabaseGateway
    {
        private readonly MetroContext _metroContext;

        public MetroEFSqliteGateway(MetroContext MetroContext)
            => _metroContext = MetroContext;

        public async Task<InOutMetro> GetInOutMetro(long id)
           => await _metroContext.InOutMetros.Where(iom => iom.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<InOutMetro>> GetAllInOutMetros()
            => await _metroContext.InOutMetros.ToListAsync();
          
        public async Task<IEnumerable<InOutMetro>> QueryInOutMetros(Expression<Func<InOutMetro, bool>> filter)
            => await _metroContext.InOutMetros.Where(filter).ToListAsync();

        public async Task AddInOutMetro(InOutMetro inoutmetro)
        {
            _metroContext.InOutMetros.Add(inoutmetro);
            await _metroContext.SaveChangesAsync();
        }

        public async Task UpdateInOutMetro(InOutMetro inoutmetro)
        {
            _metroContext.Entry(inoutmetro).State = EntityState.Modified;
            await _metroContext.SaveChangesAsync();
        }

        public async Task RemoveInOutMetro(InOutMetro inoutmetro)
        {
            _metroContext.InOutMetros.Remove(inoutmetro);
            await _metroContext.SaveChangesAsync();
        }

    }
}
