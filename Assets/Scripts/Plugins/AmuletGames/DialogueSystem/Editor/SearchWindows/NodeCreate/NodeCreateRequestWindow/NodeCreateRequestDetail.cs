namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateRequestDetail : NodeCreateDetailBase
    {
        /// <summary>
        /// Constructor of the node create request detail.
        /// </summary>
        public NodeCreateRequestDetail()
        {
            SetTypeHorizontalAlignment(value: HorizontalAlignmentType.MIDDLE);
            SetTypeConnector(value: ConnectorType.NONE);
            SetPortConnector(value: null);
        }
    }
}
