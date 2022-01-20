using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemo.Module.Blazor.Editors
{
    using DevExpress.ExpressApp.Blazor.Editors;
    using DevExpress.ExpressApp.Blazor.Editors.Adapters;
    using DevExpress.ExpressApp.Editors;
    using DevExpress.ExpressApp.Model;
    using System;
    // ...
    [PropertyEditor(typeof(decimal),"Raiting")]
    public class CustomRaitingPropertyEditor : BlazorPropertyEditorBase
    {
        
        public CustomRaitingPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
        protected override IComponentAdapter CreateComponentAdapter() => new RaitingAdapter(new RaitingModel());
    }
}
