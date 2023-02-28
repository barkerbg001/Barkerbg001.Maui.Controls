using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barkerbg001.Maui.Controls.Components;
public class CustomLabel : Label
{
    public CustomLabel()
    {
        GestureRecognizers.Add(TapGestureRecognizer = new TapGestureRecognizer());
    }

    private readonly object _tappedEventPadlock = new object();
    /// <summary>
    /// Event invoked when this button's TapGestureRecogniser is tapped
    /// </summary>string
    public event System.EventHandler<Microsoft.Maui.Controls.TappedEventArgs> Tapped
    {
        add
        {
            lock (_tappedEventPadlock)
            {
                TapGestureRecognizer.Tapped += value;
            }

        }
        remove
        {
            lock (_tappedEventPadlock)
            {
                TapGestureRecognizer.Tapped -= value;
            }
        }
    }

    /// <summary>
    /// Handles tap events on this button, by default will invoke TapGestureRecognizer_Tapped, and call the Tapped ICommand
    /// </summary>
    protected TapGestureRecognizer TapGestureRecognizer
    {
        get;
        set;
    }
}