using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsAnalysisDemo.ML.Model
{
    public class AnalyzeInput
    {
        [LoadColumn(0), ColumnName("Label")]
        public bool Category { get; set; }

        [LoadColumn(1), ColumnName("Message")]
        public string Message { get; set; }
    }
}