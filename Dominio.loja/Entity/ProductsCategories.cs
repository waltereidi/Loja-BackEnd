﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("productsCategories")]
    public class ProductsCategories : MasterEntity
    {
        [Key]
        public int ID_ProductsCategories { set; get; }
        [ForeignKey(nameof(ID_Products))]
        public int ID_Products { get; set; }
        [ForeignKey(nameof(ID_Cateogories))]
        public int ID_Cateogories { get; set; }
        public Products Product { get; set; }
        public Categories Category { get; set; }    
    }
}
