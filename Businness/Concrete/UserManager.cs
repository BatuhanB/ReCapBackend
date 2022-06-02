using Businness.Abstract;
using Businness.Constants;
using Businness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Performance;
using Core.Aspects.Autofac.Caching;
using Businness.BusinessAspects.Autofac;

namespace Businness.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
           _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        [PerformanceAspect(5)]
        //[SecuredOperation("customer.delete,admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeletedSuccess);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserListSuccess);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.GetById(x=>x.Id == id),Messages.UserListByIdSuccess);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.GetById(x => x.Email == email));
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        [ValidationAspect(typeof(UserValidator))]
        [PerformanceAspect(5)]
        //[SecuredOperation("customer.insert,admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Insert(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAddedSuccess);
        }

        [ValidationAspect(typeof(UserValidator))]
        //[SecuredOperation("customer.update,admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdatedSuccess);
        }
    }
}
