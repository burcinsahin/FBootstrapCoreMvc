﻿using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class CheckBox : BaseInput,
        ICanBeChecked
    {
        public bool Checked { get; set; }
        public bool Disabled { get; set; }

        public CheckBox() : base(FormInputType.Checkbox)
        {
        }

        protected override void PreBuild()
        {
            if (Checked)
                MergeAttribute("checked");
            if (Disabled)
                MergeAttribute("disabled");

            base.PreBuild();
        }
    }
}