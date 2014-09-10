using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectMedia.UI.Validations;
using PropertyChanged;

namespace PerfectMedia.UI.Cache
{
    [ImplementPropertyChanged]
    public class RequiredPropertyDecorator<T> : PropertyDecorator<T>
    {
        [LocalizedRequired]
        public override T Value
        {
            get { return base.Value; }
            set { base.Value = value; }
        }

        public RequiredPropertyDecorator(IPropertyViewModel<T> property)
            : base(property)
        { }
    }
}
