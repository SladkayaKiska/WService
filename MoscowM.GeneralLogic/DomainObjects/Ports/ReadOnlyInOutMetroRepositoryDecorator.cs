using MoscowM.DomainObjects;
using MoscowM.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoscowM.DomainObjects.Repositories
{
    public abstract class ReadOnlyInOutMetroRepositoryDecorator : IReadOnlyInOutMetroRepository
    {
        private readonly IReadOnlyInOutMetroRepository _inoutmetroRepository;

        public ReadOnlyInOutMetroRepositoryDecorator(IReadOnlyInOutMetroRepository inoutmetroRepository)
        {
            _inoutmetroRepository = inoutmetroRepository;
        }

        public virtual async Task<IEnumerable<InOutMetro>> GetAllInOutMetros()
        {
            return await _inoutmetroRepository?.GetAllInOutMetros();
        }

        public virtual async Task<InOutMetro> GetInOutMetro(long id)
        {
            return await _inoutmetroRepository?.GetInOutMetro(id);
        }

        public virtual async Task<IEnumerable<InOutMetro>> QueryInOutMetros(ICriteria<InOutMetro> criteria)
        {
            return await _inoutmetroRepository?.QueryInOutMetros(criteria);
        }
    }
}
