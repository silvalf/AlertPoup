using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Serialization;

namespace AlertPoup.Extensions
{
    public static class InvokeExtensions
    {
        public static TResult Inv<TControl, TResult>(this TControl control, Func<TControl, TResult> func) where TControl : Control
        {
            return control.InvokeRequired ? (TResult)control.Invoke(func, control) : func(control);
        }

        public static void Inv<TControl>(this TControl control, Action<TControl> func) where TControl : Control
        {
            control.Inv(c => { func(c); return c; });
        }

        public static void Inv<TControl>(this TControl control, Action action) where TControl : Control
        {
            control.Inv(c => action());
        }
    }
}
