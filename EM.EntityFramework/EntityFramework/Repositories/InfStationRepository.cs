using Abp.EntityFramework;
using EM.Entities;
using EM.EntityFramework.Repositories;
using EM.IRepositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.EntityFramework.Repositories
{
    public class InfStationRepository: EMRepositoryBase<InfStation>, IInfStationRepository
    {
        public InfStationRepository(IDbContextProvider<EMDbContext> dbContextProvider):base(dbContextProvider)
        {

        }

        public List<InfStationView> GetPagedInfStations(string Filter, string Sorting, int skipCount, int pageSize)
        {
            string whereClause = string.Empty;
      
            string sql = string.Format(@"select b.TypeName,c.ZoneName from inf_station a,inf_stationtype b,inf_zone c where a.ZoneId = c.id and a.TypeId=b.id ", whereClause);
            var list = Context.Database.SqlQuery<InfStationView>(sql,new MySqlParameter()).ToList();
            return list;
            //throw new NotImplementedException();
        }
    }
}
