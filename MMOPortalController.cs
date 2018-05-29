using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributedGameDatabase;
using System.ServiceModel;

namespace MMOPortal
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false, InstanceContextMode = InstanceContextMode.Single)]
    internal class MMOPortalController:IMMOPortalController
    {
        readonly DistributedGameDB distributedDB = new DistributedGameDB();

        public int InitDB()
        {
            return distributedDB.InitDB();
        }

        public int GetNumBosses()
        {
            try
            {
                return distributedDB.GetNumBosses();
            }
            catch (DllNotFoundException)
            {
                Console.WriteLine("DLL file missing");
                return -1;
            }
        }

        public bool UserChecking(string usernme, string pwd)
        {
            for (int i = 0; i < distributedDB.GetNumUsers(); i++)
            {
                distributedDB.GetUsernamePassword(i, out String username, out String passwd);
                if(username == usernme && passwd == pwd)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
