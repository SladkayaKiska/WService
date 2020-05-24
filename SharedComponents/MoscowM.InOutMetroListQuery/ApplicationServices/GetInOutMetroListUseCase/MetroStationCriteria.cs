using MoscowM.DomainObjects;
using MoscowM.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MoscowM.ApplicationServices.GetInOutMetroListUseCase
{
    public class MetroStationCriteria : ICriteria<InOutMetro>
    {
        public string MetroStation { get; }

        public MetroStationCriteria(string metrostation)
            => MetroStation = metrostation;

        public Expression<Func<InOutMetro, bool>> Filter
            => (iom => iom.MetroStation == MetroStation);
    }
}
