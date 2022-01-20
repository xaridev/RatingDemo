using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemo.Module.Blazor.Editors.RatingOverall
{
    using DevExpress.ExpressApp.Blazor.Editors;
    using DevExpress.ExpressApp.Blazor.Editors.Adapters;
    using DevExpress.ExpressApp.Editors;
    using DevExpress.ExpressApp.Model;
    using System;
    // ...
    [PropertyEditor(typeof(decimal), "ServiceRatingOverall")]
    public class CustomRatingOverallPropertyEditor : BlazorPropertyEditorBase
    {

        public CustomRatingOverallPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
        protected override IComponentAdapter CreateComponentAdapter() => new RatingOverallAdapter(new RatingOverallModel(), this.CurrentObject);
    }
}
