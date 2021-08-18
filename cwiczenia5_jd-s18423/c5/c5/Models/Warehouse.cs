using System;
using System.ComponentModel.DataAnnotations;

namespace c5.Models
{
    public class Warehouse
    {
        [Required(ErrorMessage = "Product ID is required")]
        private int IdProduct;

        public int _IdProduct
        {
            get { return IdProduct; }
            set { IdProduct = value; }
        }

        [Required(ErrorMessage = "Warehouse ID is required")]
        private int IdWarehouse;

        public int _IdWarehouse
        {
            get { return IdWarehouse; }
            set { IdWarehouse = value; }
        }

        //3C
        [Required(ErrorMessage = "Amount is required")]
        [Range(1,int.MaxValue, ErrorMessage = "Amount must be bigger than {0}")]
        private int Amount;

        public int _Amount
        {
            get { return Amount; }
            set {
                //if (value <= 0)
                //    throw new ArgumentException("Amount must be more than 0");
                Amount = value; 
            }
        }

        [Required(ErrorMessage = "Date and time of creation is required")]
        [DataType(DataType.Text)]
        private DateTime CreatedAt;

        public DateTime _CreatedAt
        {
            get { return CreatedAt; }
            set { CreatedAt = value; }
        }
    }
}
