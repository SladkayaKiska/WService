using MoscowM.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using MoscowM.ApplicationServices.GetInOutMetroListUseCase;
using System.Linq.Expressions;
using MoscowM.ApplicationServices.Ports;
using MoscowM.DomainObjects.Ports;
using MoscowM.ApplicationServices.Repositories;

namespace MoscowM.WebService.Core.Tests
{
    public class GetInOutMetroListUseCaseTest
    {
        private InMemoryInOutMetroRepository CreateInOutMetrotRepository()
        {
            var repo = new InMemoryInOutMetroRepository(new List<InOutMetro> {
                new InOutMetro { Id = 1,
                       Name="Китай-город, вход-выход 9 в северный вестибюль", MetroStation="Китай-город  ", MetroLine="Калужско-Рижская линия  ",

       Schedule1 ="Режим работы по нечётным дням: открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:43:05, по 2 пути в 05:49:50; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:24  ",

Schedule2 ="Режим работы по чётным дням: открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:44:00, по 2 пути в 05:49:05; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:24  " },
                new InOutMetro { Id = 2,  Name="Китай-город, вход-выход 5 в северный вестибюль",
       MetroStation="Китай-город ", MetroLine="Калужско-Рижская линия ",

       Schedule1 ="Режим работы по нечётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:43:05, по 2 пути в 05:49:50; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:16",

Schedule2 ="Режим работы по чётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:44:00, по 2 пути в 05:49:05; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:16 "},
                new InOutMetro { Id = 3,Name="Братиславская, вход-выход 5 в северный вестибюль",
       MetroStation="Братиславская  ", MetroLine="Люблинско-Дмитровская линия",

       Schedule1 ="Режим работы по нечётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:56:00, по 2 пути в 05:42:00; последний поезд по 1 пути в 01:52:00, по 2 пути в 01:12:00  ",

Schedule2 ="Режим работы по чётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 06:00:00, по 2 пути в 05:49:00; последний поезд по 1 пути в 01:52:00, по 2 пути в 01:12:00 "}
                
            });
            return repo;
        }
        [Fact]
        public void TestGetAllInOutMetros()
        {
            var useCase = new GetInOutMetroListUseCase(CreateInOutMetrotRepository());
            var outputPort = new OutputPort();
                        
            Assert.True(useCase.Handle(GetInOutMetroListUseCaseRequest.CreateAllInOutMetrosRequest(), outputPort).Result);
            Assert.Equal<int>(3, outputPort.InOutMetros.Count());
            Assert.Equal(new long[] { 1, 2, 3}, outputPort.InOutMetros.Select(iom => iom.Id));
        }

        [Fact]
        public void TestGetAllInOutMetrosFromEmptyRepository()
        {
            var useCase = new GetInOutMetroListUseCase(new InMemoryInOutMetroRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetInOutMetroListUseCaseRequest.CreateAllInOutMetrosRequest(), outputPort).Result);
            Assert.Empty(outputPort.InOutMetros);
        }

        [Fact]
        public void TestGetInOutMetro()
        {
            var useCase = new GetInOutMetroListUseCase(CreateInOutMetrotRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetInOutMetroListUseCaseRequest.CreateInOutMetroRequest(2), outputPort).Result);
            Assert.Single(outputPort.InOutMetros, iom => 2 == iom.Id);
        }

        [Fact]
        public void TestTryGetNotExistingInOutMetro()
        {
            var useCase = new GetInOutMetroListUseCase(CreateInOutMetrotRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetInOutMetroListUseCaseRequest.CreateInOutMetroRequest(999), outputPort).Result);
            Assert.Empty(outputPort.InOutMetros);
        }
      
    }

    class OutputPort : IOutputPort<GetInOutMetroListUseCaseResponse>
    {
        public IEnumerable<InOutMetro> InOutMetros { get; private set; }

        public void Handle(GetInOutMetroListUseCaseResponse response)
        {
            InOutMetros = response.InOutMetros;
        }
    }
}
