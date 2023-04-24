using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class OptionPortGroupCellPresenter
    {
        /// <summary>
        /// Method for creating the UIElements for the option port group cell model.
        /// </summary>
        /// <param name="model">The targeting option port group cell model to set for.</param>
        /// <param name="connectorWindow">The node creation connector window to set for.</param>
        /// <param name="direction">The direction type to set for.</param>
        public static void CreateElements
        (
            OptionPortGroupModel.CellModel model,
            NodeCreationConnectorWindow connectorWindow,
            Direction direction
        )
        {
            CreateOptionPort();

            SetupRemoveButton();

            void CreateOptionPort()
            {
                model.Port = OptionPort.CreateElements<OptionEdge>
                (
                    connectorWindow: connectorWindow,
                    direction: direction
                );
            }

            void SetupRemoveButton()
            {
                model.RemoveButton = CommonButtonPresenter.CreateElements
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.RemoveButtonIconSprite,
                    buttonUSS01: StyleConfig.Instance.OptionPortGroup_RemoveButton
                );

                model.Port.contentContainer.Add(model.RemoveButton);
            }
        }
    }
}