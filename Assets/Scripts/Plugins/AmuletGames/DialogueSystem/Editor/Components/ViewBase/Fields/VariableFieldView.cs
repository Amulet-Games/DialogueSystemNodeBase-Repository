using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AG.DS
{
    [Serializable]
    public class VariableFieldView : IReversible
    {
        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public ObjectField ObjectField;


        /// <summary>
        /// The text to display when the field is empty.
        /// </summary>
        [NonSerialized] public string PlaceholderText;


        /// <summary>
        /// The variable type to use for determine which value is the object field using now or has to be saved
        /// <br>or loaded from when it comes to serializing the view.</br>
        /// </summary>
        [NonSerialized] VariableType assigningType;


        /// <summary>
        /// One of the serializable value of the view.
        /// </summary>
        [SerializeField] public BoolVariable BoolVariable;


        /// <summary>
        /// One of the serializable value of the view.
        /// </summary>
        [SerializeField] public FloatVariable FloatVariable;


        /// <summary>
        /// One of the serializable value of the view.
        /// </summary>
        [SerializeField] public StringVariable StringVariable;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the view values to the variable group model.
        /// </summary>
        /// <param name="model">The variable group model to set for.</param>
        public void Save(VariableGroupModel model)
        {
            // Save value.
            BoolVariable = model.BoolVariable;
            FloatVariable = model.FloatVariable;
            StringVariable = model.StringVariable;
        }


        /// <summary>
        /// Load the view values from the variable group model.
        /// </summary>
        /// <param name="model">The variable group model to set for.</param>
        public void Load(VariableGroupModel model)
        {
            // Load value.
            BoolVariable = model.BoolVariable;
            FloatVariable = model.FloatVariable;
            StringVariable = model.StringVariable;

            // Update field object type.
            UpdateFieldObjectType();
        }


        // ----------------------------- Change Assigning Type -----------------------------
        /// <summary>
        /// Method to change the internal assigning type.
        /// </summary>
        /// <param name="variableType">Variable type to change to.</param>
        public void ChangeAssigningType(VariableType assigningType)
        {
            // Change internal assigning type.
            this.assigningType = assigningType;

            // Update field object type.
            UpdateFieldObjectType();
        }


        // ----------------------------- Set New Value -----------------------------
        /// <summary>
        /// Method to set a new value to the view.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void SetNewValue(Object value)
        {
            switch (assigningType)
            {
                case VariableType.Boolean:
                    BoolVariable = value != null ? value as BoolVariable : null;
                    break;
                case VariableType.Float:
                    FloatVariable = value != null ? value as FloatVariable : null;
                    break;
                case VariableType.String:
                    StringVariable = value != null ? value as StringVariable : null;
                    break;
            }
        }


        // ----------------------------- Update Field Object Type  -----------------------------
        /// <summary>
        /// Method to update the view's field object type.
        /// </summary>
        void UpdateFieldObjectType()
        {
            switch (assigningType)
            {
                case VariableType.Boolean:
                    UpdateHelper<BoolVariable, bool>(variable: BoolVariable);
                    break;
                case VariableType.Float:
                    UpdateHelper<FloatVariable, float>(variable: FloatVariable);
                    break;
                case VariableType.String:
                    UpdateHelper<StringVariable, string>(variable: StringVariable);
                    break;
            }

            /// <summary>
            /// Generic helper method for assigning the correct variable value to the field.
            /// </summary>
            /// <typeparam name="TVariable">Type variable.</typeparam>
            /// <param name="value">The variable value to assign with.</param>
            void UpdateHelper<TVariable, T>
            (
                TVariable variable
            )
                where TVariable : VariableFrameBase<T>
            {
                ObjectField.objectType = typeof(TVariable);

                ObjectField.SetValueWithoutNotify(variable);

                ObjectField.ToggleEmptyStyle(PlaceholderText);
            }
        }


        // ----------------------------- Service -----------------------------
        /// <inheritdoc/>
        public byte[] StashData()
        {
            MemoryStream memoryStream = new();
            BinaryFormatter binaryFormatter = new();

            binaryFormatter.Serialize
            (
                serializationStream: memoryStream,
                graph: ObjectField.value != null

                        // Serialize value's asset path.
                        ? AssetDatabase.GetAssetPath(ObjectField.value)

                        // Serialize empty string.
                        : ""
            );

            memoryStream.Close();

            return memoryStream.ToArray();
        }


        /// <inheritdoc/>
        public void ReverseTo(byte[] array)
        {
            if (array != null)
            {
                switch (assigningType)
                {
                    case VariableType.Boolean:
                        ReverseTo<BoolVariable, bool>(BoolVariable);
                        break;
                    case VariableType.Float:
                        ReverseTo<FloatVariable, float>(FloatVariable);
                        break;
                    case VariableType.String:
                        ReverseTo<StringVariable, string>(StringVariable);
                        break;
                }
            }


            /// <summary>
            /// Generic helper method for reversing the view's value
            /// </summary>
            /// <typeparam name="TVariable">Type variable.</typeparam>
            /// <param name="value">The type variable that the reverse process is targeting.</param>
            void ReverseTo<TVariable, T>
            (
                TVariable value
            )
                where TVariable : VariableFrameBase<T>
            {
                // Get underlying type
                Type type = typeof(TVariable);

                // Load the stashed asset's value path and retrieve it from asset data base.
                var reverseValue = (TVariable)AssetDatabase.LoadAssetAtPath
                (
                    assetPath: (string)new BinaryFormatter().Deserialize(new MemoryStream(array)),
                    type: type
                );

                if (reverseValue != null)
                {
                    value = reverseValue;

                    ObjectField.objectType = type;

                    ObjectField.SetValueWithoutNotify(value);

                    ObjectField.ToggleEmptyStyle(PlaceholderText);
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }
    }
}