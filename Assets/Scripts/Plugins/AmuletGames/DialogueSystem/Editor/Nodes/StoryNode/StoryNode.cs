using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class StoryNode : NodeFrameBase
    <
        StoryNode,
        StoryNodeView
    >
    {
        /// <inheritdoc />
        public override StoryNode Setup
        (
            StoryNodeView view,
            INodeCallback callback,
            GraphViewer graphViewer,
            LanguageHandler languageHandler
        )
        {
            base.Setup(view, callback, graphViewer, languageHandler);

            SetupSelectionBorder();

            SetupNodeBorder();

            SetupTopContainer();

            SetupTitleContainer();

            SetupPortContainer();

            SetupInputContainer();

            SetupOutputContainer();

            SetupMainContainer();

            AddDefaultStyleClass();

            AddDefaultStyleSheet();

            AddStyleSheet();

            return this;
        }


        /// <summary>
        /// Add the style sheet.
        /// </summary>
        void AddStyleSheet()
        {
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.StoryNodeStyle);
        }


        // ----------------------------- Override -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
        }


        /// TODO: Delete this method once the apply design stage is finished.
        // ----------------------------- Event -----------------------------
        public void GeometryChangedEvent(GeometryChangedEvent evt)
        {
            var margin = 10;

            // Create sample node.
            var target = NodeManager.Instance.Spawn
            (
                GraphViewer,
                nodeType: NodeType.Boolean,
                LanguageHandler
            );

            // Set sample node position
            var createPosition = localBound.position;
            createPosition.x += margin;
            createPosition.y += topContainer.layout.height + InputContainer.parent.layout.height + margin + 1;

            target.SetPosition(newPos: new Rect(createPosition, Vector2Utility.Zero));

            // Add sample node to graph
            GraphViewer.Add(target);

            // Set sample node details
            target.capabilities = Capabilities.Movable;
            target.SetEnabled(false);
            target.style.opacity = 1;
            target.topContainer.ElementAt(index: 1).style.backgroundColor = new Color(0.357f, 0.537f, 0.75f, 1);

            target.NodeBorder.style.borderBottomColor = new Color(r: 0, g: 0, b: 0, a: 0);
            target.NodeBorder.style.borderLeftColor = new Color(r: 0, g: 0, b: 0, a: 0);
            target.NodeBorder.style.borderRightColor = new Color(r: 0, g: 0, b: 0, a: 0);
            target.NodeBorder.style.borderTopColor = new Color(r: 0, g: 0, b: 0, a: 0);

            var dNode = (BooleanNode)target;
            dNode.View.ContentButton.Click();

            BringToFront();
        }
    }
}