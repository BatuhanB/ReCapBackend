using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.ValidationRules.FluentValidation
{
    public class CartItemValidator:AbstractValidator<CartItem>
    {
        public CartItemValidator()
        {
            RuleFor(x=>x.UserId).NotEmpty();
            RuleFor(x=>x.CarId).NotEmpty();
        }
    }
}
