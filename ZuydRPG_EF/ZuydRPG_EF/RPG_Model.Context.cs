﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZuydRPG_EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RPG_ModelContainer : DbContext
    {
        public RPG_ModelContainer()
            : base("name=RPG_ModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Character> CharacterSet { get; set; }
        public virtual DbSet<Monster> MonsterSet { get; set; }
        public virtual DbSet<Gear> GearSet { get; set; }
        public virtual DbSet<Location> LocationSet { get; set; }
    }
}
