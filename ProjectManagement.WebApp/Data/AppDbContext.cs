using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProjectManagement.Domain;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Domain.Entities.AspIdentity;
using ProjectManagement.WebApp.Helpers.Identity;

namespace ProjectManagement.WebApp.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        #region Tables
        public DbSet<Project> Projects { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Dependency> Dependencies { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<ProjectUserAssociation> ProjectUserAssociations { get; set; }
        public DbSet<BoardUserAssociation> BoardUserAssociations { get; set; }
        public DbSet<JobUserAssociation> JobUserAssociations { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SubJob> SubJobs { get; set; }

        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Relationships

            builder.Entity<JobUserAssociation>().HasKey(ju => new { ju.UserId, ju.JobId });
            builder.Entity<JobUserAssociation>()
                .HasOne<AppUser>(ju => ju.User)
                .WithMany(u => u.Jobs)
                .HasForeignKey(ju => ju.UserId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<JobUserAssociation>()
                .HasOne<Job>(ju => ju.Job)
                .WithMany(j => j.Users)
                .HasForeignKey(ju => ju.JobId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BoardUserAssociation>().HasKey(bu => new { bu.BoardId, bu.AppUserId });
            builder.Entity<BoardUserAssociation>()
                .HasOne<Board>(bu => bu.Board)
                .WithMany(b => b.Users)
                .HasForeignKey(bu => bu.BoardId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<BoardUserAssociation>()
                .HasOne<AppUser>(bu => bu.AppUser)
                .WithMany(u => u.Boards)
                .HasForeignKey(bu => bu.AppUserId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProjectUserAssociation>().HasKey(pu => new { pu.ProjectId, pu.UserId });
            builder.Entity<ProjectUserAssociation>()
                .HasOne<AppUser>(pu => pu.User)
                .WithMany(p => p.Projects)
                .HasForeignKey(pu => pu.UserId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProjectUserAssociation>()
                .HasOne<Project>(pu => pu.Project)
                .WithMany(p => p.Users)
                .HasForeignKey(pu => pu.ProjectId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Project>()
              .HasMany(p => p.boards)
              .WithOne(b => b.Project)
              .HasForeignKey(b => b.ProjectId)
              .IsRequired(required: true)
              .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Project>()
                .HasMany(p => p.Costs)
                .WithOne(c => c.Project)
                .IsRequired(required: true)
                .HasForeignKey(c => c.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Stage>()
                .HasMany(s => s.Jobs)
                .WithOne(j => j.Stage)
                .HasForeignKey(j => j.StageId)
                .IsRequired(required: false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Stage>()
                .HasOne(s => s.Board)
                .WithMany(b => b.Stages)
                .HasForeignKey(s => s.BoardId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Job>()
                .HasMany(j => j.Dependencies)
                .WithOne(d => d.Job)
                .HasForeignKey(d => d.JobId)
                .IsRequired(required: true)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>()
                .HasOne(c => c.Sender)
                .WithMany(s => s.Comments)
                .HasForeignKey(c => c.SenderId)
                .IsRequired(required: false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>()
                .HasOne(c => c.Job)
                .WithMany(j => j.Comments)
                .HasForeignKey(c => c.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SubJob>()
                .HasOne(s => s.Job)
                .WithMany(j => j.SubJobs)
                .HasForeignKey(s => s.JobId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            GenerateSeedData(builder);
        }

        private void GenerateSeedData(ModelBuilder builder)
        {
            Dictionary<string, Guid> userIds;

            // User Identity Data Seeding
            SeedUserRoles(builder, out userIds);

            // These will use for data seeding in entity related

            // for projects
            Guid blogSiteProjectGuid = Guid.NewGuid();
            Guid stockTrackingProjectGuid = Guid.NewGuid();
            Guid yazilimProjesiProjectGuid = Guid.NewGuid();
            Guid pazarlamaKampanyasıProjectGuid = Guid.NewGuid();
            Guid yeniUrunTasarimiProjectGuid = Guid.NewGuid();

            // for boards
            Guid frontendBoarGuid = Guid.NewGuid();
            Guid backendBoarGuid = Guid.NewGuid();
            Guid analizBoardGuid = Guid.NewGuid();
            Guid gelistirmeBoardGuid = Guid.NewGuid();

            // for stages
            Guid homePageStageGuid = Guid.NewGuid();
            Guid analizStageGuid = Guid.NewGuid();
            Guid tasarimStageGuid = Guid.NewGuid();
            Guid kodlamaStageGuid = Guid.NewGuid();
            Guid testStageGuid = Guid.NewGuid();

            // for jobs
            Guid dependJobGuid = Guid.NewGuid();
            Guid requirenmentAnalysisJobGuid = Guid.NewGuid();
            Guid designUIJobGuid = Guid.NewGuid();


            Guid testStageJob1Guid = Guid.NewGuid();
            Guid testStageJob2Guid = Guid.NewGuid();
            Guid kodlamaStageJob1Guid = Guid.NewGuid();
            Guid kodlamaStageJob2Guid = Guid.NewGuid();
            Guid tasarimStageJob1Guid = Guid.NewGuid();
            Guid tasarimStageJob2Guid = Guid.NewGuid();
            Guid tasarimStageJob3Guid = Guid.NewGuid();
            Guid tasarimStageJob4Guid = Guid.NewGuid();
            Guid tasarimStageJob5Guid = Guid.NewGuid();
            Guid tasarimStageJob6Guid = Guid.NewGuid();
            Guid tasarimStageJob7Guid = Guid.NewGuid();
            Guid analizStageJob1Guid = Guid.NewGuid();
            Guid analizStageJob2Guid = Guid.NewGuid();
            Guid analizStageJob3Guid = Guid.NewGuid();
            Guid analizStageJob4Guid = Guid.NewGuid();
            Guid analizStageJob5Guid = Guid.NewGuid();


            Guid supplierPageGuid = Guid.NewGuid();
            Guid dependencyGuid = Guid.NewGuid();
            Guid developerConstGuid = Guid.NewGuid();
            Guid serverConstGuid = Guid.NewGuid();

            builder.Entity<JobUserAssociation>().HasData(
                new JobUserAssociation{ JobId = testStageJob1Guid, UserId = userIds["project-user-3"]},
                new JobUserAssociation{ JobId = testStageJob1Guid, UserId = userIds["project-user-4"]},
                new JobUserAssociation{ JobId = testStageJob2Guid, UserId = userIds["project-user-4"]},
                new JobUserAssociation{ JobId = kodlamaStageJob1Guid, UserId = userIds["project-user"]},
                new JobUserAssociation{ JobId = kodlamaStageJob1Guid, UserId = userIds["project-user-2"]},
                new JobUserAssociation{ JobId = kodlamaStageJob1Guid, UserId = userIds["project-user-5"]},
                new JobUserAssociation{ JobId = kodlamaStageJob2Guid, UserId = userIds["project-user-5"]},
                new JobUserAssociation{ JobId = kodlamaStageJob2Guid, UserId = userIds["project-user-3"]},
                new JobUserAssociation{ JobId = kodlamaStageJob2Guid, UserId = userIds["project-user-6"]},
                new JobUserAssociation{ JobId = tasarimStageJob1Guid, UserId = userIds["project-user-7"]},
                new JobUserAssociation{ JobId = tasarimStageJob1Guid, UserId = userIds["project-user-8"]},
                new JobUserAssociation{ JobId = tasarimStageJob1Guid, UserId = userIds["project-user-9"]},
                new JobUserAssociation{ JobId = tasarimStageJob2Guid, UserId = userIds["project-user-9"]},
                new JobUserAssociation{ JobId = tasarimStageJob2Guid, UserId = userIds["project-user"]},
                new JobUserAssociation{ JobId = tasarimStageJob3Guid, UserId = userIds["project-user-2"]},
                new JobUserAssociation{ JobId = tasarimStageJob3Guid, UserId = userIds["project-user-4"]},
                new JobUserAssociation{ JobId = tasarimStageJob3Guid, UserId = userIds["project-user-5"]},
                new JobUserAssociation{ JobId = tasarimStageJob4Guid, UserId = userIds["project-user-5"]},
                new JobUserAssociation{ JobId = tasarimStageJob4Guid, UserId = userIds["project-user"]},
                new JobUserAssociation{ JobId = tasarimStageJob5Guid, UserId = userIds["project-user-8"]},
                new JobUserAssociation{ JobId = tasarimStageJob6Guid, UserId = userIds["project-user-8"]},
                new JobUserAssociation{ JobId = tasarimStageJob7Guid, UserId = userIds["project-user-8"]},
                new JobUserAssociation{ JobId = analizStageJob1Guid, UserId = userIds["project-user-8"]},
                new JobUserAssociation{ JobId = analizStageJob1Guid, UserId = userIds["project-user-7"]},
                new JobUserAssociation{ JobId = analizStageJob2Guid, UserId = userIds["project-user-6"]},
                new JobUserAssociation{ JobId = analizStageJob3Guid, UserId = userIds["project-user-4"]},
                new JobUserAssociation{ JobId = analizStageJob3Guid, UserId = userIds["project-user-2"]},
                new JobUserAssociation{ JobId = analizStageJob4Guid, UserId = userIds["project-user-9"]},
                new JobUserAssociation{ JobId = analizStageJob5Guid, UserId = userIds["project-user-8"]}
            );

            builder.Entity<Project>().HasData(
                new Project
                {
                    Id = blogSiteProjectGuid,
                    ProjectName = "Blog Site Projesi",
                    Description = "Bu proje, kullanıcıların makaleler ve yazılar paylaşabileceği, okuyucuların yorum yapabileceği ve içeriklerin kategorize edilebileceği bir blog sitesi geliştirmeyi hedeflemektedir. Amacımız, kullanımı kolay bir arayüz ve zengin özellikler ile kullanıcıların etkili bir şekilde içerik oluşturmasını sağlamaktır.",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(30),
                    CreatedOn = DateTime.Now
                },
                new Project
                {
                    Id = stockTrackingProjectGuid,
                    ProjectName = "Stock takip Projesi",
                    Description = "Bu proje, şirketlerin stok yönetim süreçlerini izlemelerini ve kontrol etmelerini sağlayan bir stok takip sistemi geliştirmeyi amaçlamaktadır. Kullanıcılar, stok seviyelerini gerçek zamanlı olarak izleyebilir, sipariş yönetimini yapabilir ve stokla ilgili raporlar oluşturabilir.",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(60),
                    CreatedOn = DateTime.Now,
                },
                new Project
                {
                    Id = yazilimProjesiProjectGuid,
                    ProjectName = "Yazılım Projesi",
                    Description = "Bu yazılım projesi, şirket içi süreçleri optimize etmeyi ve verimliliği artırmayı amaçlayan bir yönetim yazılımı geliştirmeyi içermektedir. Proje, çeşitli modüller aracılığıyla farklı departmanların ihtiyaçlarını karşılayacak ve entegre bir çözüm sunacaktır.",
                    StartDate = new DateTime(2024, 1, 1),
                    CreatedOn = DateTime.Now,
                    EndDate = new DateTime(2024, 12, 31)
                },
                new Project
                {
                    Id = pazarlamaKampanyasıProjectGuid,
                    ProjectName = "Pazarlama Kampanyası",
                    Description = "Yeni bir ürünün pazarlama stratejisinin oluşturulması",
                    StartDate = new DateTime(2024, 3, 1),
                    CreatedOn = DateTime.Now,
                    EndDate = new DateTime(2024, 6, 30)
                },
                new Project
                {
                    Id = yeniUrunTasarimiProjectGuid,
                    ProjectName = "Yeni Ürün Tasarımı",
                    Description = "Yeni bir ürünün tasarım sürecinin yürütülmesi",
                    StartDate = new DateTime(2024, 5, 1),
                    CreatedOn = DateTime.Now,
                    EndDate = new DateTime(2024, 9, 30)
                }
            );

            builder.Entity<ProjectUserAssociation>().HasData(
               new ProjectUserAssociation { ProjectId = blogSiteProjectGuid, UserId = userIds["project-manager"] },
               new ProjectUserAssociation { ProjectId = stockTrackingProjectGuid, UserId = userIds["project-user"] },
               new ProjectUserAssociation { ProjectId = stockTrackingProjectGuid, UserId = userIds["project-manager"] },
               new ProjectUserAssociation { ProjectId = stockTrackingProjectGuid, UserId = userIds["user"] },
               new ProjectUserAssociation { ProjectId = stockTrackingProjectGuid, UserId = userIds["project-user-2"] },
               new ProjectUserAssociation { ProjectId = stockTrackingProjectGuid, UserId = userIds["project-user-3"] },


               new ProjectUserAssociation { ProjectId = yazilimProjesiProjectGuid, UserId = userIds["project-manager"] },
               new ProjectUserAssociation { ProjectId = yazilimProjesiProjectGuid, UserId = userIds["project-user-2"] },
               new ProjectUserAssociation { ProjectId = yazilimProjesiProjectGuid, UserId = userIds["project-user"] },
               new ProjectUserAssociation { ProjectId = yazilimProjesiProjectGuid, UserId = userIds["project-user-3"] },
               new ProjectUserAssociation { ProjectId = yazilimProjesiProjectGuid, UserId = userIds["project-user-4"] },
               new ProjectUserAssociation { ProjectId = yazilimProjesiProjectGuid, UserId = userIds["project-user-5"] },
               new ProjectUserAssociation { ProjectId = yazilimProjesiProjectGuid, UserId = userIds["project-user-6"] },
               new ProjectUserAssociation { ProjectId = yazilimProjesiProjectGuid, UserId = userIds["project-user-7"] },
               new ProjectUserAssociation { ProjectId = yazilimProjesiProjectGuid, UserId = userIds["project-user-8"] },
               new ProjectUserAssociation { ProjectId = yazilimProjesiProjectGuid, UserId = userIds["project-user-9"] }
            );

            builder.Entity<BoardUserAssociation>().HasData(
                new BoardUserAssociation { AppUserId = userIds["project-user"], BoardId = frontendBoarGuid },
                new BoardUserAssociation { AppUserId = userIds["project-user-2"], BoardId = frontendBoarGuid },
                new BoardUserAssociation { AppUserId = userIds["project-user-3"], BoardId = frontendBoarGuid },
                new BoardUserAssociation { AppUserId = userIds["project-user"], BoardId = gelistirmeBoardGuid },
                new BoardUserAssociation { AppUserId = userIds["project-user-2"], BoardId = gelistirmeBoardGuid },
                new BoardUserAssociation { AppUserId = userIds["project-user-3"], BoardId = gelistirmeBoardGuid },
                new BoardUserAssociation { AppUserId = userIds["project-user-4"], BoardId = gelistirmeBoardGuid },
                new BoardUserAssociation { AppUserId = userIds["project-user-5"], BoardId = gelistirmeBoardGuid },
                new BoardUserAssociation { AppUserId = userIds["project-user-6"], BoardId = gelistirmeBoardGuid },
                new BoardUserAssociation { AppUserId = userIds["project-user-7"], BoardId = gelistirmeBoardGuid },
                new BoardUserAssociation { AppUserId = userIds["project-user-8"], BoardId = gelistirmeBoardGuid },
                new BoardUserAssociation { AppUserId = userIds["project-user-9"], BoardId = gelistirmeBoardGuid }
            );

            builder.Entity<Board>().HasData(
                new Board { Id = frontendBoarGuid, ProjectId = stockTrackingProjectGuid, Title = "Front-end board" },
                new Board { Id = backendBoarGuid, ProjectId = stockTrackingProjectGuid, Title = "Back-end board" },
                new Board
                {
                    Id = analizBoardGuid,
                    Title = "Analiz",
                    ProjectId = yazilimProjesiProjectGuid,
                },
                new Board
                {
                    Id = gelistirmeBoardGuid,
                    Title = "Geliştirme",
                    ProjectId = yazilimProjesiProjectGuid,
                }
            );

            builder.Entity<Stage>().HasData(
                new Stage
                {
                    Id = homePageStageGuid,
                    StageName = "Home Page",
                    Description = "Design stage for the blog site project",
                    CreatedOn = DateTime.Now,
                    BoardId = frontendBoarGuid
                },
                new Stage
                {
                    Id = supplierPageGuid,
                    StageName = "Supplier Page",
                    Description = "Planning stage for the stock tracking project",
                    CreatedOn = DateTime.Now,
                    BoardId = frontendBoarGuid
                },
                new Stage
                {
                    Id = analizStageGuid,
                    StageName = "Analiz",
                    Description = "Geliştirme aşaması için analiz aşaması",
                    CreatedOn = DateTime.Now,
                    BoardId = gelistirmeBoardGuid
                },
                new Stage
                {
                    Id = tasarimStageGuid,
                    StageName = "Tasarım",
                    Description = "Geliştirme aşaması için tasarım aşaması",
                    CreatedOn = DateTime.Now,
                    BoardId = gelistirmeBoardGuid
                },
                new Stage
                {
                    Id = kodlamaStageGuid,
                    StageName = "Kodlama",
                    Description = "Geliştirme aşaması için kodlama aşaması",
                    CreatedOn = DateTime.Now,
                    BoardId = gelistirmeBoardGuid
                },
                new Stage
                {
                    Id = testStageGuid,
                    StageName = "Test",
                    Description = "Geliştirme aşaması için test aşaması",
                    CreatedOn = DateTime.Now,
                    BoardId = gelistirmeBoardGuid
                }
            );

            builder.Entity<Job>().HasData(
                new Job
                {
                    Id = designUIJobGuid,
                    Title = "Design UI",
                    Description = "Design user interface for the blog site",
                    StartDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7),
                    Priority = JobPriority.low,
                    CreatedOn = DateTime.Now,
                    StageId = supplierPageGuid,
                },
                new Job
                {
                    Id = requirenmentAnalysisJobGuid,
                    Title = "Requirement Analysis",
                    Description = "Analyze requirements for the stock tracking project",
                    StartDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(14),
                    Priority = JobPriority.medium,
                    CreatedOn = DateTime.Now,
                    StageId = homePageStageGuid,
                },
                new Job
                {
                    Id = dependJobGuid,
                    Title = "Depend job",
                    Description = "Depend job",
                    StartDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(14),
                    Priority = JobPriority.high,
                    CreatedOn = DateTime.Now,
                    StageId = homePageStageGuid,
                },
                new Job
                {
                    Id = analizStageJob1Guid,
                    Title = "Müşteri toplantısı ve gereksinimlerin belirlenmesi",
                    Description = "Müşteri ile bir araya gelerek yazılım gereksinimlerinin detaylı bir şekilde incelenmesi",
                    StartDate = new DateTime(2024, 1, 1),
                    CreatedOn = new DateTime(2024, 1, 1),
                    DueDate = new DateTime(2024, 1, 15),
                    Priority = JobPriority.medium,
                    StageId = analizStageGuid,
                },
                new Job
                {
                    Id = analizStageJob2Guid,
                    Title = "Fonksiyonel gereksinimlerin belirlenmesi",
                    Description = "Yazılımın işlevsel gereksinimlerinin ayrıntılı bir şekilde belirlenmesi",
                    StartDate = new DateTime(2024, 1, 2),
                    CreatedOn = new DateTime(2024, 1, 2),
                    DueDate = new DateTime(2024, 1, 16),
                    Priority = JobPriority.low,
                    StageId = analizStageGuid
                },
                new Job
                {
                    Id = tasarimStageJob1Guid,
                    Title = "Prototip tasarımı",
                    Description = "Yazılımın prototipinin tasarlanması ve kullanıcı geri bildirimlerinin alınması",
                    StartDate = new DateTime(2024, 1, 3),
                    CreatedOn = new DateTime(2024, 1, 3),
                    DueDate = new DateTime(2024, 1, 17),
                    Priority = JobPriority.high,
                    StageId = tasarimStageGuid,
                },
                new Job
                {
                    Id = tasarimStageJob2Guid,
                    Title = "Arayüz tasarım revizyonu",
                    Description = "Kullanıcı arayüzünün revize edilmesi ve geliştirilmiş bir versiyonunun hazırlanması",
                    StartDate = new DateTime(2024, 1, 4),
                    CreatedOn = new DateTime(2024, 1, 4),
                    DueDate = new DateTime(2024, 1, 18),
                    Priority = JobPriority.high,
                    StageId = tasarimStageGuid,
                },
                new Job
                {
                    Id = kodlamaStageJob1Guid,
                    Title = "Backend API geliştirme",
                    Description = "Yazılımın arka uç (backend) API'larının geliştirilmesi ve test edilmesi",
                    StartDate = new DateTime(2024, 1, 5),
                    CreatedOn = new DateTime(2024, 1, 5),
                    DueDate = new DateTime(2024, 1, 19),
                    Priority = JobPriority.high,
                    StageId = kodlamaStageGuid,
                },
                new Job
                {
                    Id = kodlamaStageJob2Guid,
                    Title = "Frontend komponent geliştirme",
                    Description = "Kullanıcı arayüzünün ön uç (frontend) bileşenlerinin geliştirilmesi ve entegrasyon testlerinin yapılması",
                    StartDate = new DateTime(2024, 1, 6),
                    CreatedOn = new DateTime(2024, 1, 6),
                    DueDate = new DateTime(2024, 1, 20),
                    Priority = JobPriority.medium,
                    StageId = kodlamaStageGuid
                },
                new Job
                {
                    Id = testStageJob1Guid,
                    Title = "Birinci aşama test senaryolarının hazırlanması",
                    Description = "Yazılımın test edilmesi için birinci aşama test senaryolarının hazırlanması",
                    StartDate = new DateTime(2024, 1, 7),
                    CreatedOn = new DateTime(2024, 1, 7),
                    DueDate = new DateTime(2024, 1, 21),
                    Priority = JobPriority.low,
                    StageId = testStageGuid
                },
                new Job
                {
                    Id = testStageJob2Guid,
                    Title = "Sistem entegrasyon testlerinin yapılması",
                    Description = "Yazılımın farklı bileşenlerinin bir araya getirilerek sistem entegrasyon testlerinin yapılması",
                    StartDate = new DateTime(2024, 1, 8),
                    CreatedOn = new DateTime(2024, 1, 8),
                    DueDate = new DateTime(2024, 1, 22),
                    Priority = JobPriority.medium,
                    StageId = testStageGuid
                },
                new Job
                {
                    Id = analizStageJob3Guid,
                    Title = "Mevcut sistem analizi",
                    Description = "Mevcut sistem ve iş süreçlerinin detaylı bir şekilde incelenmesi",
                    StartDate = new DateTime(2024, 1, 14),
                    DueDate = new DateTime(2024, 1, 28),
                    Priority = JobPriority.medium,
                    StageId = analizStageGuid
                },
                new Job
                {
                    Id = analizStageJob4Guid,
                    Title = "Müşteri ihtiyaçlarının belirlenmesi",
                    Description = "Müşteri gereksinimlerinin toplanması ve analiz edilmesi",
                    StartDate = new DateTime(2024, 1, 15),
                    DueDate = new DateTime(2024, 1, 29),
                    Priority = JobPriority.low,
                    StageId = analizStageGuid,
                },
                new Job
                {
                    Id = analizStageJob5Guid,
                    Title = "Analiz sonuçlarının dokümantasyonu",
                    Description = "Yapılan analiz çalışmalarının sonuçlarının detaylı bir şekilde dokümante edilmesi",
                    StartDate = new DateTime(2024, 1, 16),
                    DueDate = new DateTime(2024, 1, 30),
                    Priority = JobPriority.low,
                    StageId = analizStageGuid
                },
                new Job
                {
                    Id = tasarimStageJob3Guid,
                    Title = "Kullanıcı arayüzünün mockup'larının hazırlanması",
                    Description = "Yazılımın kullanıcı arayüzü tasarımının ilk mockup'ları oluşturulması",
                    StartDate = new DateTime(2024, 1, 9),
                    DueDate = new DateTime(2024, 1, 23),
                    Priority = JobPriority.medium,
                    StageId = tasarimStageGuid,
                },
                new Job
                {
                    Id = tasarimStageJob4Guid,
                    Title = "Arayüz tasarımı için renk paletinin belirlenmesi",
                    Description = "Kullanılacak renklerin ve renk paletinin belirlenmesi",
                    StartDate = new DateTime(2024, 1, 10),
                    DueDate = new DateTime(2024, 1, 24),
                    Priority = JobPriority.high,
                    StageId = tasarimStageGuid
                },
                new Job
                {
                    Id = tasarimStageJob5Guid,
                    Title = "Arayüzün kullanılabilirlik testlerinin yapılması",
                    Description = "Kullanıcı arayüzünün kullanılabilirliğinin test edilmesi ve geri bildirimlerin alınması",
                    StartDate = new DateTime(2024, 1, 11),
                    DueDate = new DateTime(2024, 1, 25),
                    Priority = JobPriority.high,
                    StageId = tasarimStageGuid,
                },
                new Job
                {
                    Id = tasarimStageJob6Guid,
                    Title = "Tasarım revizyonu",
                    Description = "Tasarım aşamasında alınan geri bildirimler doğrultusunda gerekli revizyonların yapılması",
                    StartDate = new DateTime(2024, 1, 12),
                    DueDate = new DateTime(2024, 1, 26),
                    Priority = JobPriority.high,
                    StageId = tasarimStageGuid
                },
                new Job
                {
                    Id = tasarimStageJob7Guid,
                    Title = "Arayüz animasyonlarının hazırlanması",
                    Description = "Kullanıcı arayüzünde kullanılacak animasyonların hazırlanması ve uygulanması",
                    StartDate = new DateTime(2024, 1, 13),
                    DueDate = new DateTime(2024, 1, 27),
                    Priority = JobPriority.high,
                    StageId = tasarimStageGuid
                }
            );

            builder.Entity<Dependency>().HasData(
                new Dependency
                {
                    Id = dependencyGuid,
                    DependsOnJobId = requirenmentAnalysisJobGuid,
                    CreatedOn = DateTime.Now,
                    JobId = dependJobGuid,
                }
            );

            builder.Entity<Cost>().HasData(
                new Cost
                {
                    Id = developerConstGuid,
                    Description = "Sample cost",
                    Amount = 500.00m,
                    Date = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    ProjectId = blogSiteProjectGuid,
                }
            );

            builder.Entity<Cost>().HasData(
                new Cost
                {
                    Id = serverConstGuid,
                    Description = "Sample cost",
                    Amount = 200.00m,
                    Date = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    ProjectId = stockTrackingProjectGuid,
                }
            );
        }

        private void SeedUsers(ModelBuilder builder, out Dictionary<string, Guid> userIds)
        {
            userIds = new Dictionary<string, Guid>(){
                {"admin", Guid.NewGuid()},
                {"project-manager", Guid.NewGuid()},
                {"user", Guid.NewGuid()},
                {"project-user", Guid.NewGuid()},
                {"project-user-2",Guid.NewGuid()},
                {"project-user-3",Guid.NewGuid()},
                {"project-user-4",Guid.NewGuid()},
                {"project-user-5",Guid.NewGuid()},
                {"project-user-6",Guid.NewGuid()},
                {"project-user-7",Guid.NewGuid()},
                {"project-user-8",Guid.NewGuid()},
                {"project-user-9",Guid.NewGuid()},
            };

            AppUser admin = new AppUser()
            {
                Id = userIds["admin"],
                FirstName = "Furkan",
                LastName = "Aydin",
                BirthDay = DateTime.Now,
                Gender = Gender.Male,
                CreatedOn = DateTime.Now,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            AppUser projectManager = new AppUser()
            {
                Id = userIds["project-manager"],
                FirstName = "Ali",
                LastName = "Yildiz ",
                BirthDay = DateTime.Now,
                Gender = Gender.Male,
                CreatedOn = DateTime.Now,
                UserName = "aliyildiz123",
                NormalizedUserName = "ALIYILDIZ123",
                Email = "aliyildiz@gmail.com",
                NormalizedEmail = "ALIYILDIZ@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            AppUser user = new AppUser()
            {
                Id = userIds["user"],
                FirstName = "Ayse",
                LastName = "Yildiz",
                BirthDay = DateTime.Now,
                Gender = Gender.Female,
                CreatedOn = DateTime.Now,
                UserName = "ayseyildiz123",
                NormalizedUserName = "AYSEYILDIZ123",
                Email = "ayseyildiz@gmail.com",
                NormalizedEmail = "AYSEYILDIZ@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            AppUser projectUser = new AppUser()
            {
                Id = userIds["project-user"],
                FirstName = "Esref",
                LastName = "Yildiz",
                BirthDay = DateTime.Now,
                Gender = Gender.Female,
                CreatedOn = DateTime.Now,
                UserName = "esrefyildiz123",
                NormalizedUserName = "ESREFYILDIZ123",
                Email = "esrefyildiz@gmail.com",
                NormalizedEmail = "ESREFYILDIZ@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            AppUser projectUser2 = new AppUser()
            {
                Id = userIds["project-user-2"],
                FirstName = "Furkan",
                LastName = "Aydin",
                BirthDay = DateTime.Now,
                Gender = Gender.Male,
                CreatedOn = DateTime.Now,
                UserName = "furkanaydin123",
                NormalizedUserName = "FURKANAYDIN123",
                Email = "furkanaydin@gmail.com",
                NormalizedEmail = "FURKANAYDIN@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            AppUser projectUser3 = new AppUser()
            {
                Id = userIds["project-user-3"],
                FirstName = "Firat Can",
                LastName = "Yanan",
                BirthDay = DateTime.Now,
                Gender = Gender.Male,
                CreatedOn = DateTime.Now,
                UserName = "firatcanyanan123",
                NormalizedUserName = "FIRATCANYANAN123",
                Email = "firatcanyanan@gmail.com",
                NormalizedEmail = "FIRATCANYANAN@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            AppUser projectUser4 = new AppUser()
            {
                Id = userIds["project-user-4"],
                FirstName = "Mustafa",
                LastName = "Turker",
                BirthDay = DateTime.Now,
                Gender = Gender.Male,
                CreatedOn = DateTime.Now,
                UserName = "mustafaturke123",
                NormalizedUserName = "MUSTAFATURKER123",
                Email = "mustafaturker@gmail.com",
                NormalizedEmail = "MUSTAFATURKER@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            AppUser projectUser5 = new AppUser()
            {
                Id = userIds["project-user-5"],
                FirstName = "Kemal",
                LastName = "Cakır",
                BirthDay = DateTime.Now,
                Gender = Gender.Male,
                CreatedOn = DateTime.Now,
                UserName = "kemalcakir123",
                NormalizedUserName = "KEMALCAKIR123",
                Email = "kemalcakir@gmail.com",
                NormalizedEmail = "KEMALCAKIR@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            AppUser projectUser6 = new AppUser()
            {
                Id = userIds["project-user-6"],
                FirstName = "Melek",
                LastName = "Cay",
                BirthDay = DateTime.Now,
                Gender = Gender.Male,
                CreatedOn = DateTime.Now,
                UserName = "melekcay123",
                NormalizedUserName = "MELEKCAY123",
                Email = "melekcay@gmail.com",
                NormalizedEmail = "MELEKCAY@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            AppUser projectUser7 = new AppUser()
            {
                Id = userIds["project-user-7"],
                FirstName = "Gamze",
                LastName = "Kayıs",
                BirthDay = DateTime.Now,
                Gender = Gender.Male,
                CreatedOn = DateTime.Now,
                UserName = "gamzekayıs123",
                NormalizedUserName = "gamzekayıs123",
                Email = "gamzekayıs@gmail.com",
                NormalizedEmail = "GAMZEKAYIS@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            AppUser projectUser8 = new AppUser()
            {
                Id = userIds["project-user-8"],
                FirstName = "Rabia",
                LastName = "Topcu",
                BirthDay = DateTime.Now,
                Gender = Gender.Male,
                CreatedOn = DateTime.Now,
                UserName = "rabiatopcu123",
                NormalizedUserName = "RABIATOPCU123",
                Email = "rabiatopcu@gmail.com",
                NormalizedEmail = "RABIATOPCU@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            AppUser projectUser9 = new AppUser()
            {
                Id = userIds["project-user-9"],
                FirstName = "Yasin",
                LastName = "Gok",
                BirthDay = DateTime.Now,
                Gender = Gender.Male,
                CreatedOn = DateTime.Now,
                UserName = "yasingok123",
                NormalizedUserName = "YASINGOK123",
                Email = "yasingok@gmail.com",
                NormalizedEmail = "YASINGOK@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            CreatePasswordFor(builder,
                new UserSeedDataModel<AppUser>() { User = admin, Password = "admin123" },
                new UserSeedDataModel<AppUser>() { User = projectManager, Password = "user123" },
                new UserSeedDataModel<AppUser>() { User = user, Password = "user123" },
                new UserSeedDataModel<AppUser>() { User = projectUser, Password = "user123" },
                new UserSeedDataModel<AppUser>() { User = projectUser2, Password = "user123" },
                new UserSeedDataModel<AppUser>() { User = projectUser4, Password = "user123" },
                new UserSeedDataModel<AppUser>() { User = projectUser5, Password = "user123" },
                new UserSeedDataModel<AppUser>() { User = projectUser6, Password = "user123" },
                new UserSeedDataModel<AppUser>() { User = projectUser7, Password = "user123" },
                new UserSeedDataModel<AppUser>() { User = projectUser8, Password = "user123" },
                new UserSeedDataModel<AppUser>() { User = projectUser9, Password = "user123" },
                new UserSeedDataModel<AppUser>() { User = projectUser3, Password = "user123" });
        }

        private void SeedRoles(ModelBuilder builder, out Dictionary<string, Guid> roleIds)
        {
            roleIds = new Dictionary<string, Guid>(){
                {"admin", Guid.NewGuid()},
                {"project-manager", Guid.NewGuid()},
                {"user", Guid.NewGuid()},
                {"project-user", Guid.NewGuid()}
            };

            builder.Entity<AppRole>().HasData(
                           new AppRole
                           {
                               Id = roleIds["admin"],
                               CreatedOn = DateTime.Now,
                               Name = "admin",
                               NormalizedName = "ADMIN",
                           },
                           new AppRole
                           {
                               Id = roleIds["project-manager"],
                               CreatedOn = DateTime.Now,
                               Name = "project-manager",
                               NormalizedName = "PROJECT-MANAGER",
                           }, new AppRole
                           {
                               Id = roleIds["user"],
                               CreatedOn = DateTime.Now,
                               Name = "user",
                               NormalizedName = "USER",
                           },
                           new AppRole
                           {
                               Id = roleIds["project-user"],
                               CreatedOn = DateTime.Now,
                               Name = "project-user",
                               NormalizedName = "PROJECT-USER",
                           });
        }

        private void SeedUserRoles(ModelBuilder builder, out Dictionary<string, Guid> userIds)
        {
            Dictionary<string, Guid> roleIds;

            SeedRoles(builder, out roleIds);
            SeedUsers(builder, out userIds);

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>() { RoleId = roleIds["admin"], UserId = userIds["admin"] },
                new IdentityUserRole<Guid>() { RoleId = roleIds["project-manager"], UserId = userIds["project-manager"] },
                new IdentityUserRole<Guid>() { RoleId = roleIds["project-user"], UserId = userIds["user"] },
                new IdentityUserRole<Guid>() { RoleId = roleIds["project-user"], UserId = userIds["project-user"] },
                new IdentityUserRole<Guid>() { RoleId = roleIds["project-user"], UserId = userIds["project-user-2"] },
                new IdentityUserRole<Guid>() { RoleId = roleIds["project-user"], UserId = userIds["project-user-3"] },
                new IdentityUserRole<Guid>() { RoleId = roleIds["project-user"], UserId = userIds["project-user-4"] },
                new IdentityUserRole<Guid>() { RoleId = roleIds["project-user"], UserId = userIds["project-user-5"] },
                new IdentityUserRole<Guid>() { RoleId = roleIds["project-user"], UserId = userIds["project-user-6"] },
                new IdentityUserRole<Guid>() { RoleId = roleIds["project-user"], UserId = userIds["project-user-7"] },
                new IdentityUserRole<Guid>() { RoleId = roleIds["project-user"], UserId = userIds["project-user-8"] },
                new IdentityUserRole<Guid>() { RoleId = roleIds["project-user"], UserId = userIds["project-user-9"] }
                );
        }

        private void CreatePasswordFor<TUser>(ModelBuilder builder, params UserSeedDataModel<TUser>[] userSeedDataModel)
            where TUser : IdentityUser<Guid>, new()
        {
            foreach (var item in userSeedDataModel)
            {
                PasswordHasher<TUser> passwordHasher = new PasswordHasher<TUser>();
                item.User.PasswordHash = passwordHasher.HashPassword(item.User, item.Password);

                builder.Entity<TUser>().HasData(item.User);
            }
        }

        private void CreatePasswordFor<TUser, TRole>(ModelBuilder builder, params UserRoleSeedDataModel<TUser, TRole>[] userSeedDataModel)
            where TUser : IdentityUser, new()
            where TRole : IdentityRole, new()
        {
            foreach (var item in userSeedDataModel)
            {
                PasswordHasher<TUser> passwordHasher = new PasswordHasher<TUser>();
                passwordHasher.HashPassword(item.User, item.Password);
                builder.Entity<TUser>().HasData(item.User);

                if (item.Role != null)
                    builder.Entity<IdentityUserRole<string>>()
                        .HasData(new IdentityUserRole<string>()
                        {
                            RoleId = item.Role.Id,
                            UserId = item.User.Id,
                        });
            }
        }

        private class UserRoleSeedDataModel<TUser, TRole>
            where TUser : IdentityUser, new()
            where TRole : IdentityRole, new()
        {
            public TUser User { get; set; }
            public string Password { get; set; }
            public TRole Role { get; set; }
        }

        private class UserSeedDataModel<TUser>
           where TUser : IdentityUser<Guid>, new()
        {
            public TUser User { get; set; }
            public string Password { get; set; }
        }
    }
}