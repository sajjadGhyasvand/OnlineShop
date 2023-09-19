using AccountManagement.Application.Contracts.Account;
using ShopManagement.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.AccountACL
{
    public class ShopAccountAcl : IShopAccountAcl
    {
        private readonly IAccountApplication _accountApplication;

        public ShopAccountAcl(IAccountApplication accountApplication)
        {
            _accountApplication=accountApplication;
        }

        public (string name, string mobile) GetAccountBy(long id)
        {
            var accout = _accountApplication.GetAccountBy(id);
            return (accout.Fullname, accout.Mobile);
        }
    }
}
