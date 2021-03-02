using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AnthroCloud.Business;
using AnthroCloud.Entities;

namespace AnthroCloud.UI.Blazor.Components
{
    public class FormViewModel
    {
        public FormViewModel()
        {
            FormInputs = new Inputs();
            FormOutputs = new Outputs();
        }

        public Inputs FormInputs { get; set; }
        public Outputs FormOutputs { get; set; }
    }
}
