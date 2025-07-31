using CargoService.Domain.Entities;
using CargoService.Domain.RepositoryContracts;
using CargoService.Infrastructure.DBContext;
using CargoService.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Infrastructure.Repositories
{
    public  class BidRepository:GenericRepository<Bid>, IBidRepository
    {
        public BidRepository(AppDBContext appDBContext) : base(appDBContext)
        { }
    }
}
