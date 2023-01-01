using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public partial class MessageModifier
        : ModifierFrameBase<MessageModifier, MessageModifierData>
    {
        /// <summary>
        /// 
        /// </summary>
        Folder folder;


        /// <summary>
        /// 
        /// </summary>
        Button moveUpButton;


        /// <summary>
        /// 
        /// </summary>
        Button moveDownButton;


        /// <summary>
        /// 
        /// </summary>
        Button renameButton;


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateRootElements(NodeBase node)
        {
            void SetupModifierBox()
            {
                MainBox = new();
                MainBox.AddToClassList(StylesConfig.Modifier_Message_Rooted_Main_Box);
            }

            void SetupFolder()
            {
                //folder.CreateRootElements();
            }

            void SetupMoveUpButton()
            {

            }

            void SetupMoveDownButton()
            {

            }

            void SetupRenameButton()
            {

            }

            void SetupRemoveButton()
            {

            }

            void AddFieldsToBox()
            {

            }

            void AddBoxToNode()
            {

            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <inheritdoc />
        public override void SaveModifierValue(MessageModifierData data)
        {
        }


        public override void LoadModifierValue(MessageModifierData data)
        {
        }
    }
}