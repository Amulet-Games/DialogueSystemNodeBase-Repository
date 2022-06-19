using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace AG
{
    public static class DSBuiltInFieldsMaker
    {
        /// Assets.
        public static Sprite hintImageSpriteAsset;

        #region Setup.
        public static void Setup()
        {
            SetupSpriteAssets();

            void SetupSpriteAssets()
            {
                hintImageSpriteAsset = Resources.Load<Sprite>("Sprite Assets/FreeFlatChat1Bars");
            }
        }
        #endregion

        /// Text Field.
        public static TextField GetNewTextField(TextContainer textsContainer, string placeholderText, string USS01 = "")
        {
            TextField textField;

            CreateTextField();

            ConnectFieldToContainer();

            RegisterFieldEvents();

            UpdatePlaceHolderText();

            AddFieldToStyleClass();

            return textField;

            void CreateTextField()
            {
                textField = new TextField();

                textField.SetValueWithoutNotify(textsContainer.Value);
            }

            void ConnectFieldToContainer()
            {
                // Connect this TextField to the Container's Reference.
                textsContainer.TextField = textField;
            }

            void RegisterFieldEvents()
            {
                DSTextFieldUtilityEditor.RegisterValueChangedEvent(textsContainer);
                DSTextFieldUtilityEditor.RegisterFieldFocusInEvent(textField);
                DSTextFieldUtilityEditor.RegisterFieldFocusOutEvent(textsContainer);
            }

            void UpdatePlaceHolderText()
            {
                // Save the placeholder texts to Container.
                textsContainer.PlaceholderText = placeholderText;

                // Setup field's placeholder.
                DSTextFieldUtility.ToggleEmptyStyle(textsContainer);
            }

            void AddFieldToStyleClass()
            {
                textField.AddToClassList(USS01);
            }
        }

        public static TextField GetTitleTextField(string contentText, string placeholderText, string USS01 = "")
        {
            TextField textField;

            CreateTextField();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return textField;

            void CreateTextField()
            {
                textField = new TextField();

                textField.SetValueWithoutNotify(contentText);
            }

            void RegisterFieldEvents()
            {
                DSTitleTextFieldUtilityEditor.RegisterTitleChangedEvent(textField);
                DSTitleTextFieldUtilityEditor.RegisterTitleFocusOutEvent(textField);
            }

            void AddFieldToStyleClass()
            {
                textField.AddToClassList(USS01);
            }
        }

        /// Int Field.
        public static IntegerField GetNewIntegerField(IntContainer intContainer, string USS01 = "")
        {
            IntegerField intField;

            CreateIntField();

            ConnectFieldToContainer();

            SetupContainerField();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return intField;

            void CreateIntField()
            {
                intField = new IntegerField();
            }

            void ConnectFieldToContainer()
            {
                // Connect this IntField to the Container's Reference.
                intContainer.IntField = intField;
            }

            void SetupContainerField()
            {
                intContainer.SetupContainerField();
            }

            void RegisterFieldEvents()
            {
                DSIntFieldUtilityEditor.RegisterValueChangedEvent(intContainer);
            }

            void AddFieldToStyleClass()
            {
                intField.AddToClassList(USS01);
            }
        }

        /// Float Field.
        public static FloatField GetNewFloatField(FloatContainer floatContainer, string USS01 = "")
        {
            FloatField floatField;

            CreateFloatField();

            ConnectFieldToContainer();

            SetupContainerField();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return floatField;

            void CreateFloatField()
            {
                floatField = new FloatField();
            }

            void ConnectFieldToContainer()
            {
                // Connect this FloatField to the Container's Reference.
                floatContainer.FloatField = floatField;
            }

            void SetupContainerField()
            {
                floatContainer.SetupContainerField();
            }

            void RegisterFieldEvents()
            {
                DSFloatFieldUtilityEditor.RegisterValueChangedEvent(floatContainer);
            }

            void AddFieldToStyleClass()
            {
                floatField.AddToClassList(USS01);
            }
        }

        /// Object Field.
        public static ObjectField GetNewSpriteField(SpriteObjectContainer spriteContainer, Image imageElement, string USS01 = "")
        {
            ObjectField objectField;

            CreateObjectField();

            ConnectFieldToContainer();

            SetupContainerField();

            RegisterFieldEvents();

            UpdateImagePreview();

            AddFieldToStyleClass();

            return objectField;

            void CreateObjectField()
            {
                objectField = new ObjectField();
            }

            void ConnectFieldToContainer()
            {
                // Connect this ObjectField to the Container's Reference.
                spriteContainer.ObjectField = objectField;
            }

            void SetupContainerField()
            {
                spriteContainer.SetupContainerField();
            }

            void RegisterFieldEvents()
            {
                DSSpriteFieldUtilityEditor.RegisterValueChangedEvent(spriteContainer, imageElement);
            }

            void UpdateImagePreview()
            {
                DSObjectFieldUtility.UpdateImagePreview(spriteContainer.Value, imageElement);
            }

            void AddFieldToStyleClass()
            {
                objectField.AddToClassList(USS01);
            }
        }

        public static ObjectField GetNewObjectField<T>(ObjectContainer<T> objectContainer, string USS01 = "") where T : Object
        {
            ObjectField objectField;

            CreateObjectField();

            ConnectFieldToContainer();

            SetupContainerField();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return objectField;

            void CreateObjectField()
            {
                objectField = new ObjectField();
            }

            void ConnectFieldToContainer()
            {
                // Connect this ObjectField to the Container's Reference.
                objectContainer.ObjectField = objectField;
            }

            void SetupContainerField()
            {
                objectContainer.SetupContainerField();
            }

            void RegisterFieldEvents()
            {
                DSObjectFieldUtilityEditor.RegisterValueChangedEvent(objectContainer);
            }

            void AddFieldToStyleClass()
            {
                objectField.AddToClassList(USS01);
            }
        }

        /// Enum Field.
        public static EnumField GetNewEnumField(EnumContainerBase enumContainer, string USS01 = "")
        {
            EnumField enumField;

            CreateEnumField();

            ConnectFieldToContainer();

            SetupContainerField();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return enumField;

            void CreateEnumField()
            {
                enumField = new EnumField();
            }

            void ConnectFieldToContainer()
            {
                // Connect this EnumField to the Container's Reference.
                enumContainer.EnumField = enumField;
            }

            void SetupContainerField()
            {
                enumContainer.SetupContainerField();
            }

            void RegisterFieldEvents()
            {
                DSEnumFieldUtilityEditor.RegisterValueChangedEvent(enumContainer);
            }

            void AddFieldToStyleClass()
            {
                enumField.AddToClassList(USS01);
            }
        }

        public static EnumField GetNewEnumField(EnumContainerBase enumContainer, Action fieldValueChangedAction, string USS01 = "")
        {
            EnumField enumField;

            CreateEnumField();

            ConnectFieldToContainer();

            SetupContainerField();

            RegisterFieldEvents();

            AddFieldToStyleClass();

            return enumField;

            void CreateEnumField()
            {
                enumField = new EnumField();
            }

            void ConnectFieldToContainer()
            {
                // Connect this EnumField to the Container's Reference.
                enumContainer.EnumField = enumField;
            }

            void SetupContainerField()
            {
                enumContainer.SetupContainerField();
            }

            void RegisterFieldEvents()
            {
                DSEnumFieldUtilityEditor.RegisterValueChangedEvent(enumContainer, fieldValueChangedAction);
            }

            void AddFieldToStyleClass()
            {
                enumField.AddToClassList(USS01);
            }
        }
        
        /// Toolbar Menu.
        public static ToolbarMenu GetNewToolbarMenu(string toolbarText, string USS01 = "")
        {
            ToolbarMenu dropdownMenu;

            SetupToolbar();

            AddMenuToStyleClass();

            return dropdownMenu;

            void SetupToolbar()
            {
                dropdownMenu = new ToolbarMenu();
                dropdownMenu.text = toolbarText;
            }

            void AddMenuToStyleClass()
            {
                dropdownMenu.AddToClassList(USS01);
            }
        }

        /// Label Element.
        public static Label GetNewLabel(string labelName, string USS01 = "")
        {
            // Setup label
            Label label = new Label(labelName);

            // Add label to style class
            label.AddToClassList(USS01);

            return label;
        }

        /// Button Element.
        public static Button GetNewButton(string btnText, Action buttonClickedAction, string USS01 = "")
        {
            Button btn;

            SetupButton();

            RegisterButtonAction();

            AddButtonToStyleClass();

            return btn;

            void SetupButton()
            {
                btn = new Button();
                btn.text = btnText;
            }

            void RegisterButtonAction()
            {
                DSButtonUtilityEditor.DSButtonClickedAction(btn, buttonClickedAction);
            }

            void AddButtonToStyleClass()
            {
                btn.AddToClassList(USS01);
            }
        }

        public static Button GetNewButtonNonAlert(string btnText, Action buttonClickedAction, string USS01 = "")
        {
            // Create and return a button ui element,
            // however its clicked action doesn't invoke DSWindowChangedEvent.

            Button btn;

            SetupButton();

            RegisterButtonAction();

            AddButtonToStyleClass();

            return btn;

            void SetupButton()
            {
                btn = new Button();
                btn.text = btnText;
            }

            void RegisterButtonAction()
            {
                btn.clicked += buttonClickedAction;
            }

            void AddButtonToStyleClass()
            {
                btn.AddToClassList(USS01);
            }
        }

        /// Image Element.
        public static Image GetNewImage(string USS01 = "", string USS02 = "")
        {
            Image image;

            SetupImage();

            AddImageToStyleClass();

            return image;

            void SetupImage()
            {
                image = new Image();
            }

            void AddImageToStyleClass()
            {
                image.AddToClassList(USS01);
                image.AddToClassList(USS02);
            }
        }
    }
}