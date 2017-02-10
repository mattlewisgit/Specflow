//using Glass.Mapper.Sc;
//using Glass.Mapper.Sc.Web;
//using Glass.Mapper.Sc.Web.Ui;
//using Sitecore.Data.Items;
//using Sitecore.Mvc.Configuration;
//using System;
//using System.Linq.Expressions;
//using System.Web;
//using System.Web.Mvc;
//using Glass.Mapper.Sc.Web.Mvc;

//namespace Vitality.Website.GlassExtensions
//{
//    public class VitalityGlassView<TModel> : GlassView<TModel> where TModel : class
//    {
//        public IGlassHtml VitalityGlassHtml { get; private set; }
//        public new ISitecoreContext SitecoreContext { get; private set; }

//        public override void InitHelpers()
//        {
//            base.InitHelpers();
//            this.SitecoreContext = (ISitecoreContext)Glass.Mapper.Sc.SitecoreContext.GetFromHttpContext((string)null);
//            this.VitalityGlassHtml = (IGlassHtml)new Glass.Mapper.Sc.GlassHtml(this.SitecoreContext);
//            this.RenderingContext = (IRenderingContext)new RenderingContextMvcWrapper();
//            if ((object)this.Model != null || (object)this.ViewData.Model != null)
//                return;
//            this.ViewData.Model = this.GetModel();
//        }

//        public override void Execute()
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// Renders an image allowing simple page editor support
//        ///
//        /// </summary>
//        /// <typeparam name="T">The model type</typeparam><param name="model">The model that contains the image field</param><param name="field">A lambda expression to the image field, should be of type Glass.Mapper.Sc.Fields.Image</param><param name="parameters">Image parameters, e.g. width, height</param><param name="isEditable">Indicates if the field should be editable</param><param name="outputHeightWidth">Indicates if the height and width attributes should be rendered to the HTML element</param>
//        /// <returns/>
//        public override HtmlString RenderImage<T>(T model, Expression<Func<T, object>> field, object parameters = null, bool isEditable = false, bool outputHeightWidth = false)
//        {
//            return new HtmlString(this.VitalityGlassHtml.RenderImage<T>(model, field, parameters, isEditable, outputHeightWidth));
//        }

//        /// <summary>
//        /// Renders an image allowing simple page editor support
//        ///
//        /// </summary>
//        /// <typeparam name="T">The model type</typeparam><param name="field">A lambda expression to the image field, should be of type Glass.Mapper.Sc.Fields.Image</param><param name="parameters">Image parameters, e.g. width, height</param><param name="isEditable">Indicates if the field should be editable</param>
//        /// <returns/>
//        public override HtmlString RenderImage(Expression<Func<TModel, object>> field, object parameters = null, bool isEditable = false, bool outputHeightWidth = false)
//        {
//            return new HtmlString(this.VitalityGlassHtml.RenderImage<TModel>(this.Model, field, parameters, isEditable, outputHeightWidth));
//        }
//    }
//}
