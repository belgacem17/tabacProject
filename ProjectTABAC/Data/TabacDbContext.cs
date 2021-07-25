using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectTABAC.Models;

#nullable disable

namespace ProjectTABAC.Data
{
    public partial class TabacDbContext : DbContext
    {
        public TabacDbContext()
        {
        }

        public TabacDbContext(DbContextOptions<TabacDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Commantaire> Commantaires { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Reclamation> Reclamations { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Commantaire>(entity =>
            {
                entity.ToTable("Commantaire");

                entity.Property(e => e.CommantaireText).IsRequired();

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Commantaires)
                    .HasForeignKey(d => d.NewsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Commantaire_News");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Commantaires)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Commantaire_Users");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.NewsText).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_News_Users");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionText).IsRequired();
            });

            modelBuilder.Entity<Reclamation>(entity =>
            {
                entity.ToTable("Reclamation");

                entity.Property(e => e.ReclamationText).IsRequired();

                entity.HasOne(d => d.Commantaire)
                    .WithMany(p => p.Reclamations)
                    .HasForeignKey(d => d.CommantaireId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reclamations_Commantaire");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reclamations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reclamations_Users");
            });

            modelBuilder.Entity<Response>(entity =>
            {
                entity.ToTable("Response");

                entity.Property(e => e.ResponseText).IsRequired();

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Responses)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Question_Response");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Responses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Response_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Password).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
