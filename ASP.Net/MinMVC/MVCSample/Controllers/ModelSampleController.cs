using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace ModelTest.Controllers
{
    public class ModelSampleController : Controller
    {
        //
        // GET: /MyModel/

        #region UIHintAttributeSample
        public ActionResult UIHintAttributeSample()
        {
            return View(new DemoModel());
        }
        public class ModelMetadataInfo
        {
            public ModelMetadata ModelMetadata { get; set; }
            public Expression<Func<ModelMetadata, object>>[] PropertyAccessors { get; private set; }
            public ModelMetadataInfo(Type modelType, params Expression<Func<ModelMetadata, object>>[] propertyAccessors)
            {
                this.ModelMetadata = new ModelMetadata(ModelMetadataProviders.Current, null, null, modelType, null);
                this.PropertyAccessors = propertyAccessors;
            }
        }
        public class DemoModel
        {
            public string Foo { get; set; }
            [UIHint("AAA")]
            public string Bar { get; set; }
            [Display(Prompt="Water",Name="ddd",ShortName="222")]
            public string Baz { get; set; }
            public bool A { get; set; }
        }
        #endregion


    }
}
