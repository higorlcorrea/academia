using Academia.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Academia.EntityFramework.Model
{

    public class AcademiaModelContext : DbContext
    {
        public AcademiaModelContext()
            : base("name=AcademiaModelContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
            base.Configuration.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }

        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<CategoriaTreino> CategoriasTreino { get; set; }
        public virtual DbSet<Exercicio> Exercicios { get; set; }
        public virtual DbSet<GrupoMuscular> GruposMusculares { get; set; }
        public virtual DbSet<Maquina> Maquinas { get; set; }
        public virtual DbSet<Periodo> Periodos { get; set; }
        public virtual DbSet<Treino> Treinos { get; set; }
        public virtual DbSet<TreinoAberto> TreinosAbertos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
