using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioGestion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioGestion" in both code and config file together.
    [ServiceContract]
    public interface IServicioGestion
    {
        [OperationContract]
        void DoWork();
    }
}
