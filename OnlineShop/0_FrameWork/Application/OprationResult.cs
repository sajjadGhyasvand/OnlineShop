using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_FrameWork.Application
{
    public class OprationResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }
        public OprationResult()
        {
            IsSuccedded= false;
        }
        public OprationResult succedde(string message ="عملیات با موفقیت انجام شد")
        {
            IsSuccedded= true;
            Message = message;
            return this;
        }
        public OprationResult Failed(string message )
        {
            IsSuccedded= false;
            Message = message;
            return this;
        }
    }
}
