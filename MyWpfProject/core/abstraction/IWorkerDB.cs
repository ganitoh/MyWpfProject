﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfProject.core.abstraction
{
    public interface IWorkerDB<T> where T : class
    {
        T SelectRequest();
        bool UpdateRequest();
            /// <summary>
            /// возвращает true если запрос прошел успешно, иначе false
            /// </summary>
            /// <returns></returns>
        bool InsertRequest();
        bool DeleteRequest();
    }
}
