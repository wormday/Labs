using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormWithRoute
{
    public partial class _default : System.Web.UI.Page
    {
        public class PointTypeConverter : System.ComponentModel.TypeConverter
        {
            public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, Type sourceType)
            {
                return base.CanConvertFrom(context, sourceType);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
}