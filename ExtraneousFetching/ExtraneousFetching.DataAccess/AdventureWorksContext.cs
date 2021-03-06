﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using ExtraneousFetching.DataAccess.Mapping;

namespace ExtraneousFetching.DataAccess
{
    public class AdventureWorksContext : DbContext
    {
        static AdventureWorksContext()
        {
            Database.SetInitializer<AdventureWorksContext>(null);
            DbInterception.Add(new ConnectionInterceptor());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new SalesOrderHeaderConfiguration());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}