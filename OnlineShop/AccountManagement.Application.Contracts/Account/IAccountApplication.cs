using _0_Framework.Application;
using _0_FrameWork.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Account
{
    public interface IAccountApplication
    {
        AccountViewModel GetAccountBy(long id);
        OprationResult Register(RegisterAccount command);
        OprationResult Edit(EditAccount command);
        OprationResult ChangePassword(ChangePassword command);
        OprationResult Login(Login command);
        EditAccount GetDetails(long id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        void Logout();
        List<AccountViewModel> GetAccounts();
    }
}
