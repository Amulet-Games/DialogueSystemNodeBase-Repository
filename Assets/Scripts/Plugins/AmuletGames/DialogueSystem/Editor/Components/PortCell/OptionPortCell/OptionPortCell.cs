using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionPortCell : VisualElement
    {
        /// <summary>
        /// The property of the cell's port.
        /// </summary>
        public Port Port
        {
            get
            {
                return m_port;
            }
            set
            {
                m_port = value;

                Add(m_port);
            }
        }


        /// <summary>
        /// The cell's port.
        /// </summary>
        Port m_port;


        /// <summary>
        /// The property of the opponent cell.
        /// </summary>
        public OptionPortCell OpponentCell
        {
            get
            {
                return m_opponentCell;
            }
            set
            {
                m_opponentCell = value;

                this.ToggleConnectStyle();
            }
        }


        /// <summary>
        /// The opponent cell.
        /// </summary>
        OptionPortCell m_opponentCell;


        /// <summary>
        /// Can the cell overwrite the opponent cell's index?
        /// </summary>
        public bool IsIndexDominant;


        /// <summary>
        /// The cell's index.
        /// </summary>
        public int Index;


        /// <summary>
        /// Constructor of the option port cell element.
        /// </summary>
        /// <param name="isIndexDominant">The isIndexDominant value to set for.</param>
        /// <param name="index">The index to set for.</param>
        public OptionPortCell(bool isIndexDominant, int index)
        {
            IsIndexDominant = isIndexDominant;
            Index = index;
        }
    }
}