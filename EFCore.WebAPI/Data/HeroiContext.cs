using EFCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Data
{
    //O DbContext vai encapsular todas as nosas entidades
    //Estamos usando a abordagem code first aqui
    //Primeiro o código depois a geração das tabelas
    public class HeroiContext : DbContext
    {
        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }
        public DbSet<IdentidadeSecreta> IdentidadeSecretas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Pegando minha string de conexão para gerar minha migrations
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HeroApp;Data Source=DESKTOP-LDLP50C\\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aqui eu vou explicar para o Entity que ele tem que considerar que essas duas chaves
            //a batalha e o heroi dentro de batalha é a minha chave composta
            modelBuilder.Entity<HeroiBatalha>(entity => 
            {
                //Tem chave? se tem eu falo que tem usando uma expressão lambda
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });
            });
        }
    }
}
