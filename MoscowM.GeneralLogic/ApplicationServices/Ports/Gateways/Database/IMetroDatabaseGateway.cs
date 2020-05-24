using MoscowM.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoscowM.ApplicationServices.Ports.Gateways.Database
{
    public interface IMetroDatabaseGateway
    {
        Task AddInOutMetro(InOutMetro inoutmetro);

        Task RemoveInOutMetro(InOutMetro inoutmetro);

        Task UpdateInOutMetro(InOutMetro inoutmetro);

        Task<InOutMetro> GetInOutMetro(long id);

        Task<IEnumerable<InOutMetro>> GetAllInOutMetros();

        Task<IEnumerable<InOutMetro>> QueryInOutMetros(Expression<Func<InOutMetro, bool>> filter);

    }
}
