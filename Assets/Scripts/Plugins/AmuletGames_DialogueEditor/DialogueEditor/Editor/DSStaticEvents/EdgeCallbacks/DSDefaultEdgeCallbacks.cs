using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DSDefaultEdgeCallbacks
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
                defaultEdge.AddToClassList(DSStylesConfig.Default_Edge);
            }

            void RegisterFocusEvent()
            {
                defaultEdge.RegisterCallback<FocusEvent>(_ =>
                {
                    // Add to selected style class.
                    defaultEdge.AddToClassList(DSStylesConfig.Default_Edge_Selected);
                });
            }

            void RegisterBlurEvent()
            {
                defaultEdge.RegisterCallback<BlurEvent>(_ =>
                {
                    // Remove from selected style class.
                    defaultEdge.RemoveFromClassList(DSStylesConfig.Default_Edge_Selected);
                });
            }
        }
    }
}