using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ContentButtonClickable : Clickable
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the content button clickable class.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="delay">Determines when the event begins. Value is defined in milliseconds. Applies if delay > 0.</param>
        /// <param name="interval">Determines the time delta between event repetition. Value is defined in milliseconds. Applies if interval < 0.</param>
        public ContentButtonClickable(Action handler, long delay, long interval)
            : base(handler, delay, interval)
        {
        }


        /// <summary>
        /// Invoke the base clickable class's clicked action.
        /// </summary>
        public void Invoke() => Invoke(null);
    }
}