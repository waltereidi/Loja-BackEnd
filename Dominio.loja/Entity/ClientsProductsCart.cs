﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("clientsProducts_cart")]
    public class ClientsProductsCart : MasterEntity
    {
        [Key]
        public int ID_ClientsProducts_Cart {get;set;}
        public int Quantity { get;set;}

        public bool IsActive { get;set;}

        [ForeignKey(nameof(ID_Products))]
        public int ID_Products { get; set; }
        [ForeignKey(nameof(ID_Clients))]
        public int ID_Clients { get; set; }

        public Products Product { get; set; }
        public Clients Client { get; set; }
    }
}
