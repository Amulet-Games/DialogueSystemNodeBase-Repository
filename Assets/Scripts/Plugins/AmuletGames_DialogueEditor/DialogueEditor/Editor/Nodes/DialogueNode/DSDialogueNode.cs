using UnityEditor;
using UnityEngine;

namespace AG
{
    public class DSDialogueNode : DSNodeFrameBase<DSDialogueNodePresenter, DSDialogueNodeSerializer, DSDialogueNodeCallback>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue node.
        /// </summary>
        /// <param name="position">The vector2 position on the graph where this node'll be placed to once it's created.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSDialogueNode(Vector2 position, DSGraphView graphView)
            : base(DSStringsConfig.DialogueNodeDefaultLabelText, position, graphView)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPortsLayout();

            AddStyleSheet();

            InvokeInitalizedAction();

            void SetupFrameFields()
            {
                DSDialogueNodeModel model = new DSDialogueNodeModel(this);

                Presenter = new DSDialogueNodePresenter(this, model);
                Serializer = new DSDialogueNodeSerializer(this, model);
                Callback = new DSDialogueNodeCallback(this, model);
            }

            void CreateNodeElements()
            {
                Presenter.CreateNodeElements();
            }

            void CreateNodePorts()
            {
                Presenter.CreateNodePorts();
            }

            void AddStyleSheet()
            {
                styleSheets.Add(DSStylesConfig.DialogueNodeStyle);
                styleSheets.Add(DSStylesConfig.DSSegmentsStyle);
                styleSheets.Add(DSStylesConfig.DSIntegrantsStyle);
            }

            void InvokeInitalizedAction()
            {
                Callback.InitializedAction();
            }
        }
    }
}