using Businness.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception//for jwt
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//ayni anda gelen requestleri tutar - binlerce kisi token requesti atarsa her biri icin thread olusur

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//attributte rolleri virgulle ayirarak verdigimiz icin split kullaniyoruz
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
