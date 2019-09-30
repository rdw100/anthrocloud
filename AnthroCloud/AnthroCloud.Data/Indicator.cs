using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AnthroCloud.Data
{
    public enum Indicator
    {
        [Description("Length for Age")]
        LFA,
        [Description("Height for Age")]
        HFA,
        [Description("Weight for Age")]
        WFA,
        [Description("Weight for Length")]
        WFL,
        [Description("Weight for Height")]
        WFH,
        [Description("Body Mass Index for Age")]
        BFA,
        [Description("Head Circumference for Age")]
        HCFA,
        [Description("Arm Circumference for Age")]
        ACFA,
        [Description("Subscapular Skinfold for Age")]
        SSF,
        [Description("Triceps Skinfold for Age")]
        TSF
    }
}
