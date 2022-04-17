using System.Collections.Generic;
using Transaction.Entities;
using Transaction.Entities.DTOs;

namespace Transaction.Infrastructure.Repositories.Interfaces
{
    public interface IShiftMasterRepository: IRepositoryBase<ShiftMaster>
    {
        IEnumerable<ShiftMasterDTO> GetShiftMaster(string ShiftGUID);
    }
}
