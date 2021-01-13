using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AIO.BackendServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<EntityEntry> modified = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            foreach (EntityEntry item in modified)
            {
                if (item.Entity is IDateTracking changedOrAddedItem)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.CreateDate = DateTime.Now;
                    }
                    else
                    {
                        changedOrAddedItem.LastModifiedDate = DateTime.Now;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(50).IsUnicode(false);
            builder.Entity<User>().Property(x => x.Id).HasMaxLength(50).IsUnicode(false);

            builder.Entity<LabelInKnowledgeBase>()
                        .HasKey(c => new { c.LabelId, c.KnowledgeBaseId });

            builder.Entity<Permission>()
                       .HasKey(c => new { c.RoleId, c.FunctionId, c.CommandId });

            builder.Entity<CommandInFunction>()
                       .HasKey(c => new { c.CommandId, c.FunctionId });

            builder.HasSequence("KnowledgeBaseSequence");
        }

        public DbSet<Command> Commands { set; get; }
        public DbSet<CommandInFunction> CommandInFunctions { set; get; }

        public DbSet<ActivityLog> ActivityLogs { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<Function> Functions { set; get; }
        public DbSet<KnowledgeBase> KnowledgeBases { set; get; }
        public DbSet<LabelInKnowledgeBase> LabelInKnowledgeBases { set; get; }
        public DbSet<Label> Labels { set; get; }
        public DbSet<Permission> Permissions { set; get; }
        public DbSet<Report> Reports { set; get; }

        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<KhachSan> KhachSans { get; set; }

        public DbSet<CauHinhKhachSan> CauHinhKhachSans { get; set; }

        public DbSet<CongTy> CongTys { get; set; }
      
        public DbSet<NgonNgu> NgonNgus { get; set; }
       
        public DbSet<NN_KhachSan> NN_KhachSans { get; set; }
        public DbSet<NN_TienIchMoRong> NN_TienIchMoRongs { get; set; }
        public DbSet<NN_HuongNhin> NN_HuongNhins { get; set; }
        public DbSet<NN_SoNguoiToiDa> NN_SoNguoiToiDas { get; set; }
        public DbSet<NN_TienIch> NN_TienIchs { get; set; }
        public DbSet<NN_LoaiGiuong> NN_LoaiGiuongs { get; set; }
        public DbSet<NN_LoaiPhong> NN_LoaiPhongs { get; set; }
        public DbSet<NN_DichVu> NN_DichVus { get; set; }
        public DbSet<NN_KhuyenMaiDatPhong> NN_KhuyenMaiDatPhongs { get; set; }

        public DbSet<LoaiPhong_Gallery> LoaiPhong_Gallerys { get; set; }
        public DbSet<LoaiPhong_LoaiGiuong> LoaiPhong_LoaiGiuongs { get; set; }
        public DbSet<LoaiPhong_TienIch> LoaiPhong_TienIchs { get; set; }

        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<KhuyenMaiDatPhong> KhuyenMaiDatPhongs { get; set; }

        public DbSet<SoNguoiToiDa> SoNguoiToiDas { get; set; }
        public DbSet<TienIch> TienIchs { get; set; }
        public DbSet<HuongNhin> HuongNhins { get; set; }
        public DbSet<LoaiGiuong> LoaiGiuongs { get; set; }


        public DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public DbSet<TienIchMoRong_CongTy> TienIchMoRong_CongTys { get; set; }
    }
}