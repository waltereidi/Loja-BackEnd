﻿using Dominio.loja.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Interfaces
{
    public interface IStoreProductRepository 
    {
        List<Category>GetCategory();

        Task<object>GetProductCategory();



    }
}
