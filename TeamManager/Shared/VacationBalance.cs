using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Shared
{
    public class VacationBalance
    {
        public int VacationBalanceId { get; set; }
        public int UserId { get; set; }
        public int TotalBalance { get; set; }
        public int RemainingBalance { get; set; }
        public int Year { get; set; }

        public User User { get; set; }
    }
}
