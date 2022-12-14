using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class List : SingleComponent,
        ICanCreate<ListItem>
    {
        public ListType Type { get; set; }
        public List(ListType listType)
            : base(listType == ListType.Ordered ? "ol" : "ul")
        {
            Type = listType;
        }

        protected override void PreBuild()
        {
            switch (Type)
            {
                case ListType.Unstyled:
                    AddCss(Css.ListUnstyled);
                    break;
                case ListType.Inline:
                    AddCss(Css.ListInline);
                    break;
            }

            base.PreBuild();
        }
    }
}
