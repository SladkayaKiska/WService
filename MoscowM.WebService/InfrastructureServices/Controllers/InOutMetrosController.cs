using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoscowM.DomainObjects;
using MoscowM.ApplicationServices.GetInOutMetroListUseCase;
using MoscowM.InfrastructureServices.Presenters;

namespace MoscowM.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InOutMetrosController : ControllerBase
    {
        private readonly ILogger<InOutMetrosController> _logger;
        private readonly IGetInOutMetroListUseCase _getInOutMetroListUseCase;

        public InOutMetrosController(ILogger<InOutMetrosController> logger,
                                IGetInOutMetroListUseCase getInOutMetroListUseCase)
        {
            _logger = logger;
            _getInOutMetroListUseCase = getInOutMetroListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllInOutMetros()
        {
            var presenter = new InOutMetroListPresenter();
            await _getInOutMetroListUseCase.Handle(GetInOutMetroListUseCaseRequest.CreateAllInOutMetrosRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{inoutmetroId}")]
        public async Task<ActionResult> GetInOutMetro(long inoutmetroId)
        {
            var presenter = new InOutMetroListPresenter();
            await _getInOutMetroListUseCase.Handle(GetInOutMetroListUseCaseRequest.CreateInOutMetroRequest(inoutmetroId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("metrostation/{metrostation}")]
        public async Task<ActionResult> GetMetroStationInOutMetros(string metrostation)
        {
            var presenter = new InOutMetroListPresenter();
            await _getInOutMetroListUseCase.Handle(GetInOutMetroListUseCaseRequest.CreateMetroStationInOutMetrosRequest(metrostation), presenter);
            return presenter.ContentResult;
        }
    }
}
