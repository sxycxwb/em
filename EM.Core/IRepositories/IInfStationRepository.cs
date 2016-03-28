using Abp.Domain.Repositories;
using EM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.IRepositories
{
    public interface IInfStationRepository : IRepository<InfStation, System.Guid>
    {
        //List<InfStation> GetPagedInfStations(GetInfStationInput input);
    }
}
