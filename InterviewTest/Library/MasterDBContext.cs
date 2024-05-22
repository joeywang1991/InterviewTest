using InterviewTest.Models.Table;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InterviewTest.Library
{
    public class MasterDBContext : DbContext
    {

        public MasterDBContext(DbContextOptions<MasterDBContext> options) : base(options)
        {
        }

        // Table
        public DbSet<LogModel> Log_APILog { get; set; }

        public DbSet<CurrencyInfoModel> Currency_Info { get; set; }

        public DbSet<ExchangeRateModel> Currency_ExchangeRate { get; set; }

        public DbSet<GetCurrencyInfo> GetCurrencyInfo { get; set; }

    }

}
