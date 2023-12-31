﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("products")]
    public class Products : Entity
    {
        [Key]
        public int ProductsId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(2048)]
        public string? Description { get; set; }

        public long? Ean { get; set; }
        [StringLength(64)]
        public string? Sku { get; set; }
        public virtual ProductsCategories? ProductsCategories { get; set; }
        public virtual IEnumerable<ProductsPrices> ProductsPrices { get; set; }
        public virtual IEnumerable<ProductsStorage> ProductsStorage { get; set; }

    }
}
