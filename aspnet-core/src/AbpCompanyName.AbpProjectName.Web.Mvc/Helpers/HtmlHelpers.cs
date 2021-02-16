using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Json;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AbpCompanyName.AbpProjectName.Web.Helpers
{
    public static class HtmlHelpers
    {
        public static IHtmlContent JsObjectVariable(this IHtmlHelper htmlHelper, string name, object value)
        {
            var settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var str = $"window.{name} = {Newtonsoft.Json.JsonConvert.SerializeObject(value, settings)};";
            return new HtmlString(str);
        }
    }
}
