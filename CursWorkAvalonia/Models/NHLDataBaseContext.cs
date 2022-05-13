using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CursWorkAvalonia
{
    public partial class NHLDataBaseContext : DbContext
    {
        public NHLDataBaseContext()
        {
        }

        public NHLDataBaseContext(DbContextOptions<NHLDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Nhlscore> Nhlscores { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<PlayersStatistic> PlayersStatistics { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<TeamsStatistic> TeamsStatistics { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\molko\\source\\repos\\CursWorkAvalonia\\CursWorkAvalonia\\Models\\NHLDataBase.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nhlscore>(entity =>
            {
                entity.HasKey(e => e.NhlscoresId);

                entity.ToTable("NHLscores");

                entity.Property(e => e.NhlscoresId).HasColumnName("NHLscores_id");

                entity.Property(e => e.GoalAg).HasColumnName("Goal_ag");

                entity.Property(e => e.GoalFor).HasColumnName("Goal_for");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Nhlscores)
                    .HasForeignKey(d => d.TeamId);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId);
            });

            modelBuilder.Entity<PlayersStatistic>(entity =>
            {
                entity.HasKey(e => e.StatisticId);

                entity.ToTable("Players_Statistic");

                entity.Property(e => e.StatisticId).HasColumnName("statistic_id");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayersStatistics)
                    .HasForeignKey(d => d.PlayerId);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.TeamId).HasColumnName("team_id");
            });

            modelBuilder.Entity<TeamsStatistic>(entity =>
            {
                entity.HasKey(e => e.StatisticId);

                entity.ToTable("Teams_Statistic");

                entity.Property(e => e.StatisticId).HasColumnName("statistic_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamsStatistics)
                    .HasForeignKey(d => d.TeamId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
