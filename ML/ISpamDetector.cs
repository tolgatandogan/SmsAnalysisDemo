using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsAnalysisDemo.ML
{
    public interface ISpamDetector
    {
        bool Check(string text, bool chkZip);
    }
}