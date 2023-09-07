

using _0_FrameWork.Application;

namespace CommentManagement.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        OprationResult Add(AddComment command);
        OprationResult Confirm(long id);
        OprationResult Cancel(long id);
        List<CommentViewModel> Search(CommentSearchModel searchModel);
    }
}
