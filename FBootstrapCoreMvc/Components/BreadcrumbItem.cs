using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class BreadcrumbItem : SingleComponent,
        ICanBeActive, ILink
    {
        public bool Active { get; set; }
        public string? Href { get; set; }

        public BreadcrumbItem()
            : base("li", Css.BreadcrumbItem)
        {
        }

        protected override void PreBuild()
        {
            if (Active)
                AddCss(Css.Active);

            if (Href != null)
            {
                var link = new HtmlElement("a")
                {
                    Content = Content
                };
                link.MergeAttribute("href", Href);
                Content = link;
            }
            base.PreBuild();
        }
    }
}