using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Abstract
{
    public interface ICartItemService
    {
        IDataResult<List<CartItem>> GetAll();
        IDataResult<CartItem> GetById(int id);
        IResult Insert(CartItem cartItem);
        IResult Update(CartItem cartItem);
        IResult Delete(CartItem cartItem);
    }
}
