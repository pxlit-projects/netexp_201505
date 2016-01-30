using System;
using System.Windows.Markup;

namespace BruPark.Apps.WPF.Converters
{
    public abstract class AbstractConverter : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
