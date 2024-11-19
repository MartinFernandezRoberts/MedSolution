using MedSolution.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MedSolution.Server.Data
{
    public class MedsolutionContext : DbContext
    {
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

        public MedsolutionContext(DbContextOptions<MedsolutionContext> options) : base(options) { }
    }
}
