using System.Threading.Tasks;
using System.Collections.Generic;
using MoscowM.DomainObjects;
using MoscowM.DomainObjects.Ports;
using MoscowM.ApplicationServices.Ports;

namespace MoscowM.ApplicationServices.GetInOutMetroListUseCase
{
    public class GetInOutMetroListUseCase : IGetInOutMetroListUseCase
    {
        private readonly IReadOnlyInOutMetroRepository _readOnlyInOutMetroRepository;

        public GetInOutMetroListUseCase(IReadOnlyInOutMetroRepository readOnlyInOutMetroRepository) 
            => _readOnlyInOutMetroRepository = readOnlyInOutMetroRepository;

        public async Task<bool> Handle(GetInOutMetroListUseCaseRequest request, IOutputPort<GetInOutMetroListUseCaseResponse> outputPort)
        {
            IEnumerable<InOutMetro> inoutmetros = null;
            if (request.InOutMetroId != null)
            {
                var inoutmetro = await _readOnlyInOutMetroRepository.GetInOutMetro(request.InOutMetroId.Value);
                inoutmetros = (inoutmetro != null) ? new List<InOutMetro>() { inoutmetro } : new List<InOutMetro>();
                
            }
            else if (request.MetroStation != null)
            {
                inoutmetros = await _readOnlyInOutMetroRepository.QueryInOutMetros(new MetroStationCriteria(request.MetroStation));
            }
            else
            {
                inoutmetros = await _readOnlyInOutMetroRepository.GetAllInOutMetros();
            }
            outputPort.Handle(new GetInOutMetroListUseCaseResponse(inoutmetros));
            return true;
        }
    }
}
