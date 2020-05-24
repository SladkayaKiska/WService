using MoscowM.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowM.ApplicationServices.GetInOutMetroListUseCase
{
    public class GetInOutMetroListUseCaseRequest : IUseCaseRequest<GetInOutMetroListUseCaseResponse>
    {
        public string MetroStation { get; private set; }
        public long? InOutMetroId { get; private set; }

        private GetInOutMetroListUseCaseRequest()
        { }

        public static GetInOutMetroListUseCaseRequest CreateAllInOutMetrosRequest()
        {
            return new GetInOutMetroListUseCaseRequest();
        }

        public static GetInOutMetroListUseCaseRequest CreateInOutMetroRequest(long inoutmetroId)
        {
            return new GetInOutMetroListUseCaseRequest() { InOutMetroId = inoutmetroId };
        }
        public static GetInOutMetroListUseCaseRequest CreateOrganizationInOutMetrosRequest(string metrostation)
        {
            return new GetInOutMetroListUseCaseRequest() { MetroStation = metrostation };
        }
    }
}
