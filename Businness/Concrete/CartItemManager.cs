using Businness.Abstract;
using Businness.Constants;
using Businness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Performance;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private readonly ICartItemDal _cartItemDal;

        public CartItemManager(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }

        [CacheRemoveAspect("ICartItemService.Get")]
        [ValidationAspect(typeof(CartItemValidator))]
        [PerformanceAspect(5)]
        public IResult Delete(CartItem cartItem)
        {
            _cartItemDal.Delete(cartItem);
            return new SuccessResult(Messages.CartItemDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CartItem>> GetAll()
        {
            return new SuccessDataResult<List<CartItem>>(_cartItemDal.GetAll(),Messages.CartItemListed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<CartItem> GetById(int id)
        {
            return new SuccessDataResult<CartItem>(_cartItemDal.GetById(x=>x.CartItemId == id), Messages.CartItemListed);
        }

        [CacheRemoveAspect("ICartItemService.Get")]
        [ValidationAspect(typeof(CartItemValidator))]
        [PerformanceAspect(5)]
        public IResult Insert(CartItem cartItem)
        {
            _cartItemDal.Add(cartItem);
            return new SuccessResult(Messages.CartItemInserted);
        }

        [CacheRemoveAspect("ICartItemService.Get")]
        [ValidationAspect(typeof(CartItemValidator))]
        [PerformanceAspect(5)]
        public IResult Update(CartItem cartItem)
        {
            _cartItemDal.Update(cartItem);
            return new SuccessResult(Messages.CartItemUpdated);
        }
    }
}
