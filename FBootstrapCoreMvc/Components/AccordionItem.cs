using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;

namespace FBootstrapCoreMvc.Components
{
    public class AccordionItem : SingleComponent
    {
        public bool Show { get; set; }
        public string? Header { get; internal set; }
        public string? ParentId { get; internal set; }

        public AccordionItem()
            : base("div", Css.AccordionItem)
        {
        }

        protected override void PreBuild()
        {
            var h2 = new Heading(2);
            h2.AddCss(Css.AccordionHeader);
            h2.SetId();

            var button = new HtmlElement("button", Css.AccordionButton)
            {
                Content = Header
            };
            button.MergeAttribute("type", "button");
            button.MergeAttribute("data-bs-toggle", "collapse");

            h2.Content = button;

            var accordionCollapse = new HtmlElement("div", Css.AccordionCollapse, Css.Collapse);
            accordionCollapse.SetId();

            if (ParentId != null)
                accordionCollapse.MergeAttribute("data-bs-parent", $"#{ParentId}");

            if (Show)
                accordionCollapse.AddCss(Css.Show);
            button.MergeAttribute("data-bs-target", $"#{accordionCollapse.Id}");

            var accordionBody = new HtmlElement("div", Css.AccordionBody);

            AddChild(h2, ChildLocation.Header);
            AddWrappingChild(accordionCollapse, WrapperType.Body);
            AddWrappingChild(accordionBody, WrapperType.Body);
            base.PreBuild();
        }
    }
}