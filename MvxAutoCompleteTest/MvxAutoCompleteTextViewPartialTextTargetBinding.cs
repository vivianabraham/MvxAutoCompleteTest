// MvxAutoCompleteTextViewPartialTextTargetBinding.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using System.Reflection;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Binding.Bindings.Target;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Binding;

namespace MvxAutoCompleteTest
{
    public class MyAutoCompleteTextViewPartialTextTargetBinding :
        MvxPropertyInfoTargetBinding<MyAutoCompleteTextView>
    {
        public MyAutoCompleteTextViewPartialTextTargetBinding(object target, PropertyInfo targetPropertyInfo)
            : base(target, targetPropertyInfo)
        {
            var autoComplete = View;
            if (autoComplete == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error,
                                      "Error - autoComplete is null in MvxAutoCompleteTextViewPartialTextTargetBinding");
            }
            else
            {
                autoComplete.PartialTextChanged += AutoCompleteOnPartialTextChanged;
            }
        }

        private void AutoCompleteOnPartialTextChanged(object sender, EventArgs eventArgs)
        {
            FireValueChanged(View.PartialText);
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneWayToSource; }
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if (isDisposing)
            {
                var autoComplete = View;
                if (autoComplete != null)
                {
                    autoComplete.PartialTextChanged -= AutoCompleteOnPartialTextChanged;
                }
            }
        }
    }
}
