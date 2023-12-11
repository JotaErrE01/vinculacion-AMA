using Microsoft.EntityFrameworkCore;
using Project_AMA.Models;
namespace Project_AMA.DB;

public class ApplicationDbContext: DbContext {
	
	// constructor
	public ApplicationDbContext(DbContextOptions options): base(options) {}
	
	// tables creation
	public DbSet<User> Users { get; set; }
	public DbSet<Brigada> Brigadas { get; set; }
}