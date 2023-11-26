﻿using Dominio.loja.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Interfaces.Context
{
    public interface IStoreContext
    {
        Clients? getClient(string email, string password);

        void GetPermissionsRelation(string email);

    }
}
