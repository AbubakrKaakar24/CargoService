using CargoService.Domain.RepositoryContracts;
using CargoService.Domain.RepositoryContracts.Base;
using CargoService.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Infrastructure.Repositories.Base
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _Db;
        public UnitOfWork(AppDBContext appDB) {
          _Db=appDB;
        }
        public IFleetRepository _fleetRepository;
        public IBidRepository _bidRepository;
        public ITripRepository _tripRepository;
        public ILoadRepository _loadRepository;
        public IFleetRepository FleetRepository=> _fleetRepository??new FleetRepository(_Db);
        public ITripRepository TripRepository => _tripRepository ?? new TripRepository(_Db);
        public IBidRepository BidRepository => _bidRepository ?? new BidRepository(_Db);
        public ILoadRepository LoadRepository => _loadRepository ?? new LoadRepository(_Db);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
        {
            return await _Db.SaveChangesAsync(cancellationToken);
        }
        }
}
