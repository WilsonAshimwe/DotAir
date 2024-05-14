﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAir.BLL.Infrastructure
{
    public static class HtmlRenderExtensions
    {
        public static string Render<T>(this HtmlRenderer renderer, Dictionary<string, object?> parameters) where T: IComponent
        {
            return renderer.Dispatcher.InvokeAsync(() =>
            {
                ParameterView p = ParameterView.FromDictionary(parameters);
                return renderer.RenderComponentAsync<T>(p).Result.ToHtmlString();
            }).Result;
        }

        public static string Render<T>(this HtmlRenderer renderer, object parameters) where T : IComponent
        {
            return renderer.Dispatcher.InvokeAsync(() =>
            {
                var dico = parameters.ToDictionary();
                ParameterView p = ParameterView.FromDictionary(dico);
                return renderer.RenderComponentAsync<T>(p).Result.ToHtmlString();
            }).Result;
        }

        public static Dictionary<string, object?> ToDictionary(this object o)
        {
            return o.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(o));
        }
    }
}
