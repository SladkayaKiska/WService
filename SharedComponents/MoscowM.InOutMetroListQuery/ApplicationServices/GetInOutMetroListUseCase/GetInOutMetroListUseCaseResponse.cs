using MoscowM.DomainObjects;
using MoscowM.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowM.ApplicationServices.GetInOutMetroListUseCase
{
    public class GetInOutMetroListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<InOutMetro> InOutMetros { get; }

        public GetInOutMetroListUseCaseResponse(IEnumerable<InOutMetro> inoutmetros) => InOutMetros = inoutmetros;
    }
}
