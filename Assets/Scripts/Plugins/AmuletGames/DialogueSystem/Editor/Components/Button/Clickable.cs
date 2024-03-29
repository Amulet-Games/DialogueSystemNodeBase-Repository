using System;

namespace AG.DS
{
    public class Clickable : UnityEngine.UIElements.Clickable
    {
        /// <summary>
        /// Constructor of the clickable class.
        /// </summary>
        /// <param name="clicked">The clicked action to set for.</param>
        /// <param name="delay">Determines when the event begins. Value is defined in milliseconds. Applies if delay > 0.</param>
        /// <param name="interval">Determines the time delta between event repetition. Value is defined in milliseconds. Applies if interval < 0.</param>
        public Clickable(Action clicked, long delay, long interval)
            : base(clicked, delay, interval)
        {
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Invoke the clicked action.
        /// </summary>
        public void Invoke() => Invoke(null);
    }
}