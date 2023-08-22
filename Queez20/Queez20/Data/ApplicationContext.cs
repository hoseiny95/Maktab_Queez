using Microsoft.EntityFrameworkCore;

namespace Queez20.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
{
}
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    //modelBuilder.Entity<Student>()
    //.HasOne(a => a.Grade)
    //.WithOne(a => a.Student)
    //.HasForeignKey<Grade>(c => c.GradeID);

}

}
