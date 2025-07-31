using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Domain.RepositoryContracts.Base
{
    public interface IUnitOfWork
    {
        public IFleetRepository FleetRepository { get; }
        public ITripRepository TripRepository { get; }
        public IBidRepository BidRepository { get; }
        public ILoadRepository LoadRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
