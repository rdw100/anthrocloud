﻿using AnthroCloud.Entities;

namespace AnthroCloud.UI.BlazorApp.Components
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
