﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.loja.Entity
{
    [Table("clientsProductsCart")]
    public class ClientsProductsCart : MasterEntity
    {
        [Key]
        public int ClientsProductsCartId {get;set;}
        public int Quantity { get;set;}

        public bool IsActive { get;set;}

        [ForeignKey("ProductsId")]
        public int ProductsId { get; set; }
        [ForeignKey("ClientsId")]
        public int ClientsId { get; set; }

        public virtual Products Products { get; set; }
        public virtual Clients Clients { get; set; }
    }
}
