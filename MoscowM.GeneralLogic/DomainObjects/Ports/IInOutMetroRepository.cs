using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MoscowM.DomainObjects.Ports
{
    public interface IReadOnlyInOutMetroRepository
    {
        Task<InOutMetro> GetInOutMetro(long id);

        Task<IEnumerable<InOutMetro>> GetAllInOutMetros();

        Task<IEnumerable<InOutMetro>> QueryInOutMetros(ICriteria<InOutMetro> criteria);

    }

    public interface IInOutMetroRepository
    {
        Task AddInOutMetro(InOutMetro inoutmetro);

        Task RemoveInOutMetro(InOutMetro inoutmetro);

        Task UpdateInOutMetro(InOutMetro inoutmetro);
    }
}
