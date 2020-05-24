using MoscowM.ApplicationServices.GetInOutMetroListUseCase;
using System.Net;
using Newtonsoft.Json;
using MoscowM.ApplicationServices.Ports;

namespace MoscowM.InfrastructureServices.Presenters
{
    public class InOutMetroListPresenter : IOutputPort<GetInOutMetroListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public InOutMetroListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetInOutMetroListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.InOutMetros) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
