using Microsoft.EntityFrameworkCore;
using Service.Models.Schemas;

namespace Service.Models.Contexts
{
    public partial class DocumentContext(DbContextOptions<DocumentContext> options) : DbContext(options)
    {
        public virtual DbSet<Document> DbDocumentModel { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>(entity => {
                entity.HasKey(k => k.DocumentId);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
