
using _0_FrameWork.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Role
{
    public interface IRoleApplication
    {
        OprationResult Create(CreateRole command);
        OprationResult Edit(EditRole command);
        List<RoleViewModel> List();
        EditRole GetDetails(long id);
    }
}
