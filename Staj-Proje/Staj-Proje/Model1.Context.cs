﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Staj_Proje
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MassTransitGuide_EfeEntities : DbContext
    {
        public MassTransitGuide_EfeEntities()
            : base("name=MassTransitGuide_EfeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<BusStops> BusStops { get; set; }
        public virtual DbSet<Busses> Busses { get; set; }
        public virtual DbSet<BusNumbers> BusNumbers { get; set; }
        public virtual DbSet<Guzergah> Guzergah { get; set; }
        public virtual DbSet<GuzergahDurak> GuzergahDurak { get; set; }
    }
}