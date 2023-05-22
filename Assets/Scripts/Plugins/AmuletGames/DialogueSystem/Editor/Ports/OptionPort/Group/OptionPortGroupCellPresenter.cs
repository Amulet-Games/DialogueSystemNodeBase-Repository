using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class OptionPortGroupCellPresenter
    {
        /// <summary>
        /// Method for creating the elements for the option port group cell model.
        /// </summary>
        /// <param name="model">The targeting option port group cell model to set for.</param>
        /// <param name="connectorWindow">The node create connector window to set for.</param>
        /// <param name="direction">The direction type to set for.</param>
        public static void CreateElement
        (
            OptionPortGroupModel.CellModel model,
            NodeCreateConnectorWindow connectorWindow,
            Direction direction
        )
        {
            CreateOptionPort();

            SetupRemoveButton();

            void CreateOptionPort()
            {
                model.Port = OptionPort.CreateElement<OptionEdge>
                (
                    connectorWindow: connectorWindow,
                    direction: direction
                );
            }

            void SetupRemoveButton()
            {
                model.RemoveButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.RemoveButtonIconSprite,
                    buttonUSS01: StyleConfig.Instance.OptionPortGroup_RemoveButton
                );

                model.Port.contentContainer.Add(model.RemoveButton);
            }
        }
    }
}