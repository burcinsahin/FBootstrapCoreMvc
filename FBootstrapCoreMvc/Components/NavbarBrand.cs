﻿using FBootstrapCoreMvc;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class NavbarBrand : Link
    {
        public NavbarBrand(IHtmlHelper helper, string? text = null)
            : base(helper)
        {
            AddCssClass(Css.NavbarBrand);
            InnerHtml.SetContent(text);
        }
    }
}