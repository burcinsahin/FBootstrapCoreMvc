﻿using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;

namespace FBootstrapCoreMvc
{
    public class Bootstrap<TModel>
    {
        protected readonly IHtmlHelper<TModel> _htmlHelper;

        public Bootstrap(IHtmlHelper<TModel> helper)
        {
            _htmlHelper = helper;
        }

        #region Typography
        public HtmlElement Div()
        {
            return new HtmlElement(_htmlHelper, "div");
        }

        public Icon Icon(IconType icon, string? text = null)
        {
            return new Icon(_htmlHelper, icon).SetContent(text);
        }

        public Heading Heading(byte size = 1)
        {
            if (size < 1) size = 1;
            else if (size > 6) size = 6;

            return new Heading(_htmlHelper, size);
        }

        public Heading Heading1(string? text = null)
        {
            return new Heading(_htmlHelper, 1).SetContent(text);
        }

        public List List(ListType listType = ListType.Unstyled)
        {
            return new List(_htmlHelper, listType);
        }
        #endregion

        public Alert Alert()
        {
            return new Alert(_htmlHelper);
        }

        public Container Container()
        {
            return new Container(_htmlHelper);
        }

        /// <summary>
        /// Card is new version of old Panel
        /// </summary>
        /// <returns></returns>
        public Card Card(string? header = null, string? footer = null)
        {
            var card = new Card(_htmlHelper);
            if (header != null)
                card.SetHeader(header);
            if (footer != null)
                card.SetFooter(footer);
            return card;
        }

        public Navbar Navbar()
        {
            var navbar = new Navbar(_htmlHelper);
            return navbar;
        }

        public Component Element(string tagName, string text)
        {
            var element = new Component(_htmlHelper, tagName);
            element.InnerHtml.SetContent(text);
            return element;
        }

        public Input Hidden(string? name = null, object? value = null)
        {
            var input = new Input(_htmlHelper);
            input.SetType(FormInputType.Hidden);
            input.MergeAttribute("name", name);
            input.MergeAttribute("value", value?.ToString());
            return input;
        }

        public Image Image(string src, string? alt = null)
        {
            return new Image(_htmlHelper).AddAttribute("src", src).AddAttribute("alt", alt);
        }

        public Component Paragraph()
        {
            //TODO:
            var p = new Component(_htmlHelper, "p");
            return p;
        }

        public Link Link(object? content, string href = "#")
        {
            return new Link(_htmlHelper, content).SetHref(href);
        }

        public Link Link(string text, string action, string controller, object routeValues = null)
        {
            var link = new Link(_htmlHelper, text);
            var urlHelper = _htmlHelper.GetUrlHelper();
            var urlActionContext = new UrlActionContext() { Action = action, Controller = controller, Values = routeValues };
            var url = urlHelper?.Action(urlActionContext);
            link.MergeAttribute("href", url);
            return link;
        }

        public LinkButton LinkButton(string text, string action, string controller, object routeValues = null)
        {
            var linkButton = new LinkButton(_htmlHelper, ButtonState.Primary, text);
            var htmlHelper = _htmlHelper;
            var urlHelperFactory = htmlHelper.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory)) as IUrlHelperFactory;
            var urlHelper = urlHelperFactory?.GetUrlHelper(htmlHelper.ViewContext);
            var urlActionContext = new UrlActionContext() { Action = action, Controller = controller, Values = routeValues };
            var url = urlHelper?.Action(urlActionContext);
            linkButton.MergeAttribute("href", url);
            return linkButton;
        }

        public Form<TModel> Form()
        {
            return new Form<TModel>(_htmlHelper);
        }

        public Form<TModel> Form(string action, string controller, FormMethod method = FormMethod.Post, object routeValues = null)
        {
            var htmlHelper = _htmlHelper;
            var urlHelperFactory = htmlHelper.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory)) as IUrlHelperFactory;
            var urlHelper = urlHelperFactory?.GetUrlHelper(htmlHelper.ViewContext);
            var urlActionContext = new UrlActionContext() { Action = action, Controller = controller, Values = routeValues };
            var url = urlHelper?.Action(urlActionContext);
            return new Form<TModel>(_htmlHelper).SetAction(url).SetMethod(method.ToString());
        }

        public Table Table()
        {
            return new Table(_htmlHelper);
        }

        public Button Button(ButtonType buttonType = ButtonType.Button, object? value = null)
        {
            var button = new Button(_htmlHelper);
            button.SetType(buttonType);
            button.SetValue(value);
            return button;
        }

        public CheckBox CheckBox()
        {
            var checkbox = new CheckBox(_htmlHelper);
            return checkbox;
        }

        //public HtmlBuilder<TComponent> Begin<TComponent>(TComponent component)
        //    where TComponent : Component
        //{
        //    return new HtmlBuilder<TComponent>(_htmlHelper, component);
        //}
    }
}