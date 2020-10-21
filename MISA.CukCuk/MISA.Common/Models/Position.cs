using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Position
    {
        /// <summary>
        /// Id Vị trí
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// Tên Vị trí
        /// </summary>
        public string PositionName { get; set; }
    }
}
