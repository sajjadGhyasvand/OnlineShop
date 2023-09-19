namespace _0_FrameWork.Application.Sms
{
    public interface ISmsService
    {
        void Send(string number, string message);
    }
}