﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
    public interface IBaseBussiness<T>
    {
        /// <summary>
        /// Lấy danh sách thông tin bản ghi
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Get();
        T GetById(Guid employeeId);
        int Insert(T employee);
        int Update(T employee);
        int Delete(Guid Id); 


    }
}
