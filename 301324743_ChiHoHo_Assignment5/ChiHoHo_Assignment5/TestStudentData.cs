using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiHoHo_Assignment5_Q3
{
    static class TestStudentData
    {
        internal static readonly Student[] student = new Student[]
        {
            //Middle
            new Student {
                STG = 0.09f,
                SCG = 0.15f,
                STR = 0.4f,
                LPR = 0.3f,
                PEG = 0.66f
            },
            //very_low
            new Student {
                STG = 0.0f,
                SCG = 0.1f,
                STR = 0.1f,
                LPR = 0.1f,
                PEG = 0.2f
            },
            //High
            new Student {
                STG = 0.1f,
                SCG = 0.2f,
                STR = 0.6f,
                LPR = 0.6f,
                PEG = 0.8f
            },
            //Low
            new Student {
                STG = 0.16f,
                SCG = 0.22f,
                STR = 0.3f,
                LPR = 0.3f,
                PEG = 0.3f
            }
        };
    }
}
