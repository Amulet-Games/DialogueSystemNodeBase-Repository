using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionPortGroupCell : VisualElement
    {
        /// <summary>
        /// The option port.
        /// </summary>
        public OptionPort Port;


        /// <summary>
        /// Button to remove the cell view from the group. 
        /// </summary>
        public CommonButton RemoveButton;
    }
}