using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemo.Module.Blazor.Editors
{
    using System;
    using DevExpress.ExpressApp.Blazor.Components.Models;
    public class RaitingModel : ComponentModelBase
    {
        public decimal Value
        {
            get => GetPropertyValue<decimal>();
            set => SetPropertyValue(value);
        }
        public bool ReadOnly
        {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(value);
        }
        public void SetValueFromUI(decimal value)
        {
            SetPropertyValue(value, notify: false, nameof(Value));
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler ValueChanged;
    }
}
