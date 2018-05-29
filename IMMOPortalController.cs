using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MMOPortal
{
    [ServiceContract]
    public interface IMMOPortalController
    {
        [OperationContract]
        int InitDB();

        [OperationContract]
        int GetNumBosses();

        [OperationContract]
        bool UserChecking(string usernme, string pwd);
    }
}
