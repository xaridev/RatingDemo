using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RatingDemo.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Service : BaseObject
    { 
        public Service(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string serviceName;
        decimal? raitingOverall;
        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ServiceName
        {
            get => serviceName;
            set => SetPropertyValue(nameof(ServiceName), ref serviceName, value);
        }
        [EditorAlias("ServiceRatingOverall")]
        [XafDisplayName("Rating")]
        public decimal? RaitingOverall
        {
            get 
            {
                return raitingOverall;
                //if (Comments.Any())
                //{
                //    if (!IsLoading && !IsSaving && raitingOverall == null)
                //        UpdateOrdersTotal(false);
                //    return raitingOverall;
                //}
                //return 0;
            }
            set => SetPropertyValue(nameof(RaitingOverall), ref raitingOverall, value);
        }
        public void UpdateOrdersTotal(bool forceChangeEvents)
        {
            decimal? oldOrdersTotal = raitingOverall;
           
            if (Comments.Any())
            {
                raitingOverall = Comments.Average(c => c.Raiting);
            }
            else
            {
                raitingOverall = 0;
            }
            if (forceChangeEvents)
                OnChanged(nameof(RaitingOverall), oldOrdersTotal, raitingOverall);
        }
        [Association("Service-Comments")]
        public XPCollection<Comment> Comments
        {
            get
            {

                var collection = GetCollection<Comment>(nameof(Comments));
                collection.ListChanged += Collection_ListChanged; ;
                return collection;
            }
        }

        private void Collection_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateOrdersTotal(true);
            
        }

        void UpdateCurrentInvoiceTotal(object sender, XPCollectionChangedEventArgs args)
        {
            
        }
        //[NonPersistent]
        //[ModelDefault("AllowEdit", "False")]
        //public decimal CurrentInvoiceTotal
        //{
        //    get
        //    {
        //        if (Comments.Any())
        //        {
        //            RaitingOverall = Comments.Average(c => c.Raiting); 
        //            return Comments.Average(c => c.Raiting); 
        //        }
        //        return 0;
        //    }
        //    set { SetPropertyValue(nameof(CurrentInvoiceTotal), value); }
        //}
        private void Comments_ListChanged(object sender, ListChangedEventArgs e)
        {
            
        }
    }
}