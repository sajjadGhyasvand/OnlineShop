namespace _0_FrameWork.Application.Email
{
    public interface IEmailService
    {
        void SendEmail(string title, string messageBody, string destination);
    }
}