using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnthroCloud.Business;
using AnthroCloud.Entities;
using AnthroCloud.UI.Blazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace AnthroCloud.UI.Blazor.Components
{
    public class PersonComponentBase : ComponentBase
    {
        public Person Person = new Person();
        public string LastSubmitResult;

        public void ValidFormSubmitted(EditContext editContext)
        {
            Person.LastName = "Smith";

            LastSubmitResult = "OnValidSubmit was executed";
        }

        public void InvalidFormSubmitted(EditContext editContext)
        {
            LastSubmitResult = "OnInvalidSubmit was executed";
        }
    }
}
