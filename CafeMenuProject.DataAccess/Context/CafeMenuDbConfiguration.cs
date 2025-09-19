using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace CafeMenuProject.DataAccess.Context
{
    public class CafeMenuDbConfiguration : DbConfiguration
    {
        public CafeMenuDbConfiguration()
        {
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        }
    }
}
