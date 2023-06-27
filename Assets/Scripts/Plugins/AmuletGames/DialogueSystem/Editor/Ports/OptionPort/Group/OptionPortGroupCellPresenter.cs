using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class OptionPortGroupCellPresenter
    {
        /// <summary>
        /// Method for creating the elements for the option port group cell view.
        /// </summary>
        /// <param name="view">The targeting option port group cell view to set for.</param>
        /// <param name="connectorWindow">The node create connector window to set for.</param>
        /// <param name="direction">The direction type to set for.</param>
        public static void CreateElement
        (
            OptionPortGroupView.CellView view,
            NodeCreateConnectorWindow connectorWindow,
            Direction direction
        )
        {
            CreateOptionPort();

            SetupRemoveButton();

            void CreateOptionPort()
            {
                view.Port = OptionPort.CreateElement<OptionEdge>
                (
                    connectorWindow: connectorWindow,
                    direction: direction
                );
            }

            void SetupRemoveButton()
            {
                view.RemoveButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIconSprite,
                    buttonUSS: StyleConfig.OptionPortGroup_RemoveButton
                );

                view.Port.contentContainer.Add(view.RemoveButton);
            }
        }
    }
}