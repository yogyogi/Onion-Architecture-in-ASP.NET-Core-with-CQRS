using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface IAppDbContext
    {
        DbSet<Student> Students { get; set; }
        Task<int> SaveChangesAsync();
    }
}
