using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowM.DomainObjects
{
  public class InOutMetro : DomainObject
    {
    
        public string Name { get; set; }

        public string MetroStation { get; set; }

        public string MetroLine { get; set; }

        public string Schedule1 { get; set; }

        public string Schedule2 { get; set; }
    }
}
