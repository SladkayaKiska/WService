using MoscowM.DomainObjects;
using MoscowM.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoscowM.ApplicationServices.Repositories
{
    public class InMemoryInOutMetroRepository : IReadOnlyInOutMetroRepository,
                                           IInOutMetroRepository 
    {
        private readonly List<InOutMetro> _inoutmetros = new List<InOutMetro>();

        public InMemoryInOutMetroRepository(IEnumerable<InOutMetro> inoutmetros = null)
        {
            if (inoutmetros != null)
            {
                _inoutmetros.AddRange(inoutmetros);
            }
        }

        public Task AddInOutMetro(InOutMetro inoutmetro)
        {
            _inoutmetros.Add(inoutmetro);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<InOutMetro>> GetAllInOutMetros()
        {
            return Task.FromResult(_inoutmetros.AsEnumerable());
        }

        public Task<InOutMetro> GetInOutMetro(long id)
        {
            return Task.FromResult(_inoutmetros.Where(iom => iom.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<InOutMetro>> QueryInOutMetros(ICriteria<InOutMetro> criteria)
        {
            return Task.FromResult(_inoutmetros.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveInOutMetro(InOutMetro inoutmetro)
        {
            _inoutmetros.Remove(inoutmetro);
            return Task.CompletedTask;
        }

        public Task UpdateInOutMetro(InOutMetro inoutmetro)
        {
            var foundInOutMetro = GetInOutMetro(inoutmetro.Id).Result;
            if (foundInOutMetro == null)
            {
                AddInOutMetro(inoutmetro);
            }
            else
            {
                if (foundInOutMetro != inoutmetro)
                {
                    _inoutmetros.Remove(foundInOutMetro);
                    _inoutmetros.Add(inoutmetro);
                }
            }
            return Task.CompletedTask;
        }
    }
}
