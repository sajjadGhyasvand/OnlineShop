using _0_FrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.PoductPicture
{
    public interface IProductPictureApplication
    {
        OprationResult Create(CreatePoductPicture command);
        OprationResult Edit(EditPoductPicture command);
        OprationResult Remove(long id);
        OprationResult Restore(long id);
        EditPoductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
