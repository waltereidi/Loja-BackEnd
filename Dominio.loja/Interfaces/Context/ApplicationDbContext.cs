﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Interfaces.Context
{
    internal interface ApplicationDbContext<T> where T : class
    {
        IQueryable<T> Retorna();
    }
}