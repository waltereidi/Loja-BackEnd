﻿using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infra.loja.Data
{
    public class StoreClientsContext : DbContext, IStoreClientsContext
    {
        private readonly string _connectionString;
        public StoreClientsContext(DbContextOptions<StoreClientsContext> options) : base(options)
        {

        }
        public StoreClientsContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        public DbSet<Products> products { get; set; } = null;
        public DbSet<ProductsCategories> productsCategories { get; set; } = null;
        public DbSet<ProductsPrices> productsPrices { get; set; } = null;
        public DbSet<ProductsStorage> productsStorage { get; set; } = null;
        public DbSet<Categories> categories { get; set; } = null;
        public DbSet<Prices> prices { get; set; } = null;
        public DbSet<Clients> clients { get; set; } = null;
        public DbSet<ClientsProductsCart> clientsProducts_cart { get; set; } = null;
        public DbSet<RequestOrders> requestOrders { get; set; } = null;
        public DbSet<RequestOrdersClientsProductsCart> requestOrdersClientsProductsCart { get; set; } = null;
     
        public IQueryable<ClientsProductsCart>? GetCartProducts()
        {
            return from cli in clients
                        join cap in clientsProducts_cart on cli.ID_Clients equals cap.ID_Clients
                        join prd in products on cap.ID_Products equals prd.ID_Products
                        join rcpc in requestOrdersClientsProductsCart on cap.ID_ClientsProducts_Cart equals rcpc.ID_ClientsProducts_Cart into leftClientsProductsCart
                        from lrcpc in leftClientsProductsCart.DefaultIfEmpty()
                        join req in requestOrders on lrcpc.ID_RequestOrders equals req.ID_RequestOrders into leftRequestOrders
                        from lreq in leftRequestOrders.DefaultIfEmpty()
                        where cap.IsActive == true && lreq  == null && lrcpc == null
                        select new ClientsProductsCart()
                        {
                            Created_at = cap.Created_at,
                            Updated_at = cap.Updated_at,
                            Client = cli,
                            Product = prd,
                            IsActive = cap.IsActive,
                            Quantity = cap.Quantity
                        };

        }
        public IQueryable<RequestOrdersClientsProductsCart> GetOrdersRequest()
        {
            var query = from cli in clients
                        join cap in clientsProducts_cart on cli.ID_Clients equals cap.ID_Clients
                        join rcpc in requestOrdersClientsProductsCart on cap.ID_ClientsProducts_Cart equals rcpc.ID_ClientsProducts_Cart
                        join req in requestOrders on rcpc.ID_RequestOrders equals req.ID_RequestOrders
                        select new RequestOrdersClientsProductsCart()
                        {
                            ID_RequestOrders_clientsProducts_Cart = rcpc.ID_RequestOrders_clientsProducts_Cart,
                            Created_at = rcpc.Created_at,
                            Updated_at = rcpc.Updated_at,
                            RequestOrders = req,
                            ClientsProductCart = cap,
                           
                        };
            return query;

        }

            
    }
}
