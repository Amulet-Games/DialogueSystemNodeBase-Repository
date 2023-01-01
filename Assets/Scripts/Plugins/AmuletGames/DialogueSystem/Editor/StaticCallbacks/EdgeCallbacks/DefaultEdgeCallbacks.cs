using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class DefaultEdgeCallbacks
    {
        /// <summary>
        /// Register different actions to the given edge element.
        /// <para></para>
        /// This method is limited to default typed edges, for channel typed edges use <see cref="ChannelEdgeCallbacks.Register(Edge)"/> instead.
        /// </summary>
        /// <param name="edge">The edge to assign the actions to.</param>
        public static void Register(Edge edge)
        {
            SetAllowsFocus();

            AddDefaultEdgeStyle();

            RegisterFocusEvent();

            RegisterBlurEvent();

            void SetAllowsFocus()
            {
                // Set its focusable property to true so that it can register to FocusEvent.
                edge.focusable = true;
            }

            void AddDefaultEdgeStyle()
            {
                // Add to the default edge style class.
                edge.AddToClassList(StylesConfig.Default_Edge);
            }

            void RegisterFocusEvent()
            {
                edge.RegisterCallback<FocusEvent>(callback =>
                {
                    // Add to selected style class.
                    edge.AddToClassList(StylesConfig.Default_Edge_Selected);
                });
            }

            void RegisterBlurEvent()
            {
                edge.RegisterCallback<BlurEvent>(callback =>
                {
                    // Remove from selected style class.
                    edge.RemoveFromClassList(StylesConfig.Default_Edge_Selected);
                });
            }
        }
    }
}