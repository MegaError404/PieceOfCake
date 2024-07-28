using Alaiala_API.Enumerations;
using Alaiala_API.Models.Orders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alaiala_API.Models.NewFolder
{
    public class CaptainsCanceledOrders
	{
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public Guid GUID { get; set; } = Guid.Empty;

        [Required]
        public string Number { get; set; } = "0";

        [Required]
        public OrderTypes OrderType { get; set; } = OrderTypes.None;

        [Required]
        public PaymentCases PaymentStatus { get; set; } = PaymentCases.None;

        [Required]
        public DateTime CreatingDateTime { get; set; } = DateTime.MinValue;

        [Required]
        public DateTime AcceptingDateTime { get; set; } = DateTime.MinValue;

        [Required]
        public DateTime DeliveringDateTime { get; set; } = DateTime.MinValue;

        [Required]
        public DateTime CancelingDateTime { get; set; } = DateTime.MinValue;


        [Required]
        public string Notes { get; set; } = string.Empty;

        private decimal _OrderCost = decimal.Zero;
        private decimal _DeliveringCost = decimal.Zero;
        private decimal _ServiceCost = decimal.Zero;
        private decimal _OverLoadCost = decimal.Zero;
       
        [Required]
        public decimal TotalCost { get; set; } = decimal.Zero;

        [Required]
        public decimal OrderCost
        {
            get { return _OrderCost; }
            set
            {
                TotalCost -= _OrderCost;
                _OrderCost = value;
                TotalCost += _OrderCost;
            }
        }

        [Required]
        public decimal DeliveringCost
        {
            get { return _DeliveringCost; }
            set
            {
                TotalCost -= _DeliveringCost;
                _DeliveringCost = value;
                TotalCost += _DeliveringCost;
            }
        }

        [Required]
        public decimal ServiceCost
        {
            get { return _ServiceCost; }
            set
            {
                TotalCost -= _ServiceCost;
                _ServiceCost = value;
                TotalCost += _ServiceCost;
            }
        }

        [Required]
        public decimal OverLoadCosts
        {
            get { return _OverLoadCost; }
            set
            {
                TotalCost -= _OverLoadCost;
                _OverLoadCost = value;
                TotalCost += _OverLoadCost;
            }
        }

		[Required]
		public Captains.Captains Captain { get; set; }
       
        [Required]
        public Stores Store { get; set; }

        [Required]
        public Vehicles Vehicle { get; set; }

        [Required]
        public Customers Customer { get; set; }

        [Required]
        public OrderCancellationReasons Reason { get; set; }
    }
}
