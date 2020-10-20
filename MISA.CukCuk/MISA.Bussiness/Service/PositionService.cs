using MISA.Bussiness.Interfaces;
using MISA.Common.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class PositionService : BaseService<Position>, IPositionService
    {
        public PositionService(IPositionRepository positionRepository) : base(positionRepository)
        {
        }
    }
}
