namespace TeamManager.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VacationRequest>().HasData(
        new VacationRequest
        {
            VacationRequestId = 1,
            UserId = 1,
            StartDate = new DateTime(2023, 3, 1),
            EndDate = new DateTime(2023, 3, 7),
            Status = "Approved",
            Reason = "Vacation trip"
        },
        new VacationRequest
        {
            VacationRequestId = 2,
            UserId = 2,
            StartDate = new DateTime(2023, 4, 15),
            EndDate = new DateTime(2023, 4, 20),
            Status = "Pending",
            Reason = "Family vacation"
        }
    );

            modelBuilder.Entity<VacationBalance>().HasData(
                new VacationBalance
                {
                    VacationBalanceId = 1,
                    UserId = 1,
                    Year = 2024,
                    TotalBalance = 20 // Adjust as needed
                },
                new VacationBalance
                {
                    VacationBalanceId = 2,
                    UserId = 2,
                    Year = 2024,
                    TotalBalance = 25 // Adjust as needed
                }
            );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }
        public DbSet<VacationBalance> vacationBalances { get; set; }

    }
}
