//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace clima_tempo_simples.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ClimaTempoSimplesEntities1 : DbContext
    {
        public ClimaTempoSimplesEntities1()
            : base("name=ClimaTempoSimplesEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Estado> Estadoes { get; set; }
        public virtual DbSet<PrevisaoClima> PrevisaoClimas { get; set; }
    }
}
