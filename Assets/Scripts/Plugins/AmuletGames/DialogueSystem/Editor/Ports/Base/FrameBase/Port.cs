using System;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    //public abstract class Port<TPort>
    //    : PortBase
    //    where TPort : Port<TPort>
    //{
    //    /// <summary>
    //    /// Constructor of the port frame base class.
    //    /// </summary>
    //    /// <param name="model">The port model to set for.</param>
    //    protected Port(PortModel model) : base(model)
    //    {
    //        portName = model.Name;
    //        portColor = model.Color;
    //    }


    //    /// <summary>
    //    /// Setup for the port frame base class.
    //    /// </summary>
    //    /// <param name="edgeConnector">The edge connector to set for.</param>
    //    /// <param name="callback">The port callback to set for.</param>
    //    public virtual TPort Setup
    //    (
    //        EdgeConnector edgeConnector,
    //        IPortCallback callback
    //    )
    //    {
    //        EdgeConnector = edgeConnector;
    //        Callback = callback;
    //        Guid = Guid.NewGuid();
    //        return null;
    //    }


    //    /// <summary>
    //    /// Setup the connector box element.
    //    /// </summary>
    //    protected void SetupConnectorBox()
    //    {
    //        // Setup style class
    //        {
    //            ConnectorBox.name = "";
    //            ConnectorBox.AddToClassList(this.IsInput() ? StyleConfig.Input_Connector : StyleConfig.Output_Connector);
    //        }
    //    }


    //    /// <summary>
    //    /// Setup the connector text element.
    //    /// </summary>
    //    protected void SetupConnectorText()
    //    {
    //        // Setup style class
    //        {
    //            ConnectorText.name = "";
    //            ConnectorText.ClearClassList();
    //            ConnectorText.AddToClassList(this.IsInput() ? StyleConfig.Input_Label : StyleConfig.Output_Label);
    //        }
    //    }


    //    /// <summary>
    //    /// Setup the connector box cap element.
    //    /// </summary>
    //    protected void SetupConnectorBoxCap()
    //    {
    //        SetupDetails();

    //        SetupStyleClass();

    //        void SetupDetails()
    //        {
    //            ConnectorBoxCap.pickingMode = PickingMode.Position;
    //        }

    //        void SetupStyleClass()
    //        {
    //            ConnectorBoxCap.name = "";
    //            ConnectorBoxCap.AddToClassList(this.IsInput() ? StyleConfig.Input_Cap : StyleConfig.Output_Cap);
    //        }
    //    }


    //    /// <summary>
    //    /// Add the style class.
    //    /// </summary>
    //    protected void AddStyleClass()
    //    {
    //        name = "";
    //        ClearClassList();
    //        AddToClassList(this.IsInput() ? StyleConfig.Input_Port : StyleConfig.Output_Port);
    //    }


    //    // ----------------------------- Service -----------------------------
    //    /// <summary>
    //    /// Connect the port to the given edge.
    //    /// </summary>
    //    /// <param name="edge">The edge element to set for.</param>
    //    public void Connect(Edge<TPort> edge)
    //    {
    //        base.Connect(edge);
    //        Callback.OnPostConnect(edge);
    //    }


    //    /// <summary>
    //    /// Disconnect the port from the given edge.
    //    /// </summary>
    //    /// <param name="edge">The edge element to set for.</param>
    //    public void Disconnect(Edge<TPort> edge)
    //    {
    //        Callback.OnPreDisconnect(edge);
    //        base.Disconnect(edge);
    //    }


    //    /// <summary>
    //    /// Disconnect any edges that are connecting with the port.
    //    /// </summary>
    //    /// <param name="graphViewer">The graph viewer element to set for.</param>
    //    public void Disconnect(GraphViewer graphViewer)
    //    {
    //        if (!connected)
    //            return;

    //        foreach (Edge<TPort> edge in connections.ToList())
    //        {
    //            // Disconnect the opponent port.
    //            (this.IsInput() ? edge.Output : edge.Input).Disconnect(edge);

    //            Disconnect(edge);
    //            graphViewer.Remove(edge);
    //        }
    //    }
    //}
}