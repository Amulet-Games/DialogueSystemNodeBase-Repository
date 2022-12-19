using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class DefaultEdgeCallbacks
    {
        /// <summary>
        /// Register focus and blur events to the edge in order to change its color
        /// <br>when it's selected or checked.</br>
        /// </summary>
        /// <param name="defaultEdge">The default edge of which this event is register to.</param>
        public static void Register(Edge defaultEdge)
        {
            SetAllowsFocus();

            AddDefaultEdgeStyle();

            RegisterFocusEvent();

            RegisterBlurEvent();

            void SetAllowsFocus()
            {
                // Set its focusable property to true so that it can register to FocusEvent.
                defaultEdge.focusable = true;
            }

            void AddDefaultEdgeStyle()
            {
                // Add to the default edge style class.
                defaultEdge.AddToClassList(StylesConfig.Default_Edge);
            }

            void RegisterFocusEvent()
            {
                defaultEdge.RegisterCallback<FocusEvent>(callback =>
                {
                    // Add to selected style class.
                    defaultEdge.AddToClassList(StylesConfig.Default_Edge_Selected);
                });
            }

            void RegisterBlurEvent()
            {
                defaultEdge.RegisterCallback<BlurEvent>(callback =>
                {
                    // Remove from selected style class.
                    defaultEdge.RemoveFromClassList(StylesConfig.Default_Edge_Selected);
                });
            }
        }
    }
}