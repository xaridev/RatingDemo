using System;
using DevExpress.ExpressApp.Blazor.Components.Models;
using RatingDemo.Module.BusinessObjects;

namespace RatingDemo.Module.Blazor.Editors.RatingOverall
{
    public class RatingOverallModel: ComponentModelBase
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
        public object CurrentObject
        {
            get => GetPropertyValue<object>();
            set
            {
                SetPropertyValue(value);
                decimal sum = 0;
                foreach (var item in ((Service)value).Comments)
                {
                    sum += item.Raiting;
                }
                Value = sum / ((Service)value).Comments.Count;
            }
        }
        public void SetValueFromUI(decimal value)
        {
            SetPropertyValue(value, notify: false, nameof(Value));
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler ValueChanged;
    }
}
