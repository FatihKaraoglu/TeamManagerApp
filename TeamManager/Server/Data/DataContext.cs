namespace TeamManager.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.PhoneNumber)
                .IsRequired(false); // Make the PhoneNumber property optional
            modelBuilder.Entity<User>()
            .HasOne(u => u.Address)
            .WithOne(a => a.User)
            .HasForeignKey<Address>(a => a.UserId) // Assuming Address has a UserId property
            .IsRequired(false); // Make the relationship optional

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }
        public DbSet<VacationBalance> VacationBalances { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Address> Adresses { get; set; }



    }
}
