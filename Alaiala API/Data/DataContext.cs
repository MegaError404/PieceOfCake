using Alaiala_API.Models;
using Alaiala_API.Models.Captains;
using Alaiala_API.Models.Merchants;
using Alaiala_API.Models.NewFolder;
using Alaiala_API.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace Alaiala_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //CaptainTables
        public DbSet<Captains> Captains { get; set; }
        public DbSet<CaptainsLocations> CaptainsLocations { get; set; }
        public DbSet<CaptainsNotes> CaptainsNotes { get; set; }
        public DbSet<CaptainsNotifications> CaptainsNotifications { get; set; }
        public DbSet<CaptainsSubscriptions> CaptainsSubscriptions { get; set; }
        public DbSet<CaptainWorkflow> CaptainWorkflows { get; set; }

        //MerchantTables
        public DbSet<Merchants> Merchants { get; set; }
        public DbSet<MerchantNotifications> MerchantNotifications { get; set; }
        public DbSet<MerchantsNotes> MerchantsNotes { get; set; }
        public DbSet<MerchantsRates> MerchantsRates { get; set; }
        public DbSet<MerchantsSubscriptions> MerchantsSubscriptions { get; set; }

        //OrderTables
        public DbSet<AcceptedOrders> AcceptedOrders { get; set; }
        public DbSet<CaptainsCanceledOrders> CaptainsCanceledOrders { get; set; }
        public DbSet<DeliveredOrders> DeliveredOrders { get; set; }
        public DbSet<InprogressOrders> InprogressOrders { get; set; }
        public DbSet<MerchantsCanceledOrders> MerchantsCanceledOrders { get; set; }
        public DbSet<NewOrders> NewOrders { get; set; }
        public DbSet<OrderCancellationReasons> OrderCancellationReasons { get; set; }
        public DbSet<OrdersComplaints> OrdersComplaints { get; set; }
        public DbSet<RedirectedOrders> RedirectedOrders { get; set; }

        //MoreTables
        public DbSet<Admins> Admins { get; set; }
        public DbSet<Advertisements> Advertisements { get; set; }
        public DbSet<BusinessActivities> BusinessActivities { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<General> Generals { get; set; }
        public DbSet<Governorates> Governorates { get; set; }
        public DbSet<ServiceRates> ServiceRates { get; set; }
        public DbSet<Stores> Stores { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
    }
}