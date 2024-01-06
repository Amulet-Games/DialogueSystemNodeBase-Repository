namespace AG.DS
{
    public class OptionPortCell : PortCellBase
    {
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
        /// The property of the cell's index.
        /// </summary>
        public int Index;
        

        /// <summary>
        /// Constructor of the option port cell element.
        /// </summary>
        /// <param name="index">The index to set for.</param>
        public OptionPortCell(int index)
        {
            Index = index;
        }
    }
}