using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CartItem:IEntity
    {
        [Key]
        public int CartItemId { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
    }
}
