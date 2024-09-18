using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapboxMaui;

internal static class TemplateHelpers
{
    public static IPlatformViewHandler GetHandler(View view, IMauiContext context)
    {
        if (view == null)
        {
            throw new ArgumentNullException(nameof(view));
        }
        var handler = view.Handler;

        if (handler == null)
            handler = (IPlatformViewHandler)view.ToHandler(context);

        return (IPlatformViewHandler)handler;
    }
}
