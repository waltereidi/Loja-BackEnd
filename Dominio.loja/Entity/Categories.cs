﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class Categories : MasterEntity
    {
        [StringLength(120)]
        public string Name { get; set; }
        [StringLength(2048)]
        public string? Description { get; set; }

    }


}
