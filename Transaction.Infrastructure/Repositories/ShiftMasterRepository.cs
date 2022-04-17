
using System.Linq;
using System.Collections.Generic;
using Transaction.Entities;
using Transaction.Infrastructure.Repositories.Interfaces;
using Transaction.Infrastructure.Persistance;
using Transaction.Entities.DTOs;

namespace Transaction.Infrastructure.Repositories
{
    public class ShiftMasterRepository : RepositoryBase<ShiftMaster>, IShiftMasterRepository
    {
        public ShiftMasterRepository(TransactionDBContext repositoryContext) : base(repositoryContext)
        {
            //this.RepositoryContext = repositoryContext;
        }

        public IEnumerable<ShiftMasterDTO> GetShiftMaster(string ShiftGUID)
        {
            var query =
                 from shift in RepositoryContext.ShiftMaster
                 where shift.Active == true && shift.ShiftGuid == ShiftGUID
                 select new ShiftMasterDTO
                 {
                     ShiftGuid = shift.ShiftGuid,

                     ShiftName = shift.ShiftName,
                     ShiftDay = shift.ShiftDay,
                     StartDate = shift.StartDate,

                     Active = shift.Active

                 };
            return query;

        }
    }
}
