
using BookStore1.Domain;
using BookStore1.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BookStore1.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BookAuthor> BookAuthors {  get; set; }
    public DbSet<BookCategory> BookCategories {  get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // BookAuthor (Many-to-Many)
        modelBuilder.Entity<BookAuthor>()
            .HasKey(x => new { x.BookId, x.AuthorId });

        modelBuilder.Entity<BookAuthor>()
            .HasOne(x => x.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(x => x.BookId)
            .OnDelete(DeleteBehavior.Cascade); // مسموح: Book -> BookAuthor

        modelBuilder.Entity<BookAuthor>()
            .HasOne(x => x.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.Restrict); // ❌ امنع حذف Author لو ليه Books

        // BookCategory (Many-to-Many)
        modelBuilder.Entity<BookCategory>()
            .HasKey(x => new { x.BookId, x.CategoryId });

        modelBuilder.Entity<BookCategory>()
            .HasOne(x => x.Book)
            .WithMany(b => b.BookCategories)
            .HasForeignKey(x => x.BookId)
            .OnDelete(DeleteBehavior.Cascade); // مسموح

        modelBuilder.Entity<BookCategory>()
            .HasOne(x => x.Category)
            .WithMany(c => c.BookCategories)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); // ❌ امنع حذف Category لو ليها Books
    }

}
