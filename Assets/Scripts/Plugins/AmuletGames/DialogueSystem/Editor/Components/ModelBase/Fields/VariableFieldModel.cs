using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace AG.DS
{
    [Serializable]
    public class VariableFieldModel : IReversible
    {
        /// <summary>
        /// One of the serializable value from the model.
        /// </summary>
        [SerializeField] public BoolVariable BoolVariable;


        /// <summary>
        /// One of the serializable value from the model.
        /// </summary>
        [SerializeField] public FloatVariable FloatVariable;


        /// <summary>
        /// One of the serializable value from the model.
        /// </summary>
        [SerializeField] public StringVariable StringVariable;


        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public ObjectField ObjectField;


        /// <summary>
        /// The variable type to use for determine which value is the object field using now or has to be saved
        /// <br>or loaded from when it comes to serializing the model.</br>
        /// </summary>
        [NonSerialized] G_VariableType assigningType;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the model values to the given data.
        /// </summary>
        /// <param name="data">The given data to save to.</param>
        public void Save(VariableGroupData data)
        {
            // Save value.
            BoolVariable = data.BoolVariable;
            FloatVariable = data.FloatVariable;
            StringVariable = data.StringVariable;
        }


        /// <summary>
        /// Load the model values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void Load(VariableGroupData data)
        {
            // Load value.
            BoolVariable = data.BoolVariable;
            FloatVariable = data.FloatVariable;
            StringVariable = data.StringVariable;

            // Update field object type.
            UpdateFieldObjectType();
        }


        // ----------------------------- Change Assigning Type -----------------------------
        /// <summary>
        /// Method to change the internal assigning type.
        /// </summary>
        /// <param name="variableType">Variable type to change to.</param>
        public void ChangeAssigningType(G_VariableType assigningType)
        {
            // Change internal assigning type.
            this.assigningType = assigningType;

            // Update field object type.
            UpdateFieldObjectType();
        }


        // ----------------------------- Set New Value -----------------------------
        /// <summary>
        /// Method to set a new value to the model.
        /// </summary>
        /// <param name="evt">The valueChangedEvent that stored the new value.</param>
        public void SetNewValue(ChangeEvent<Object> evt)
        {
            switch (assigningType)
            {
                case G_VariableType.Boolean:
                    BoolVariable = evt != null ? evt.newValue as BoolVariable : null;
                    break;
                case G_VariableType.Float:
                    FloatVariable = evt != null ? evt.newValue as FloatVariable : null;
                    break;
                case G_VariableType.String:
                    StringVariable = evt != null ? evt.newValue as StringVariable : null;
                    break;
            }
        }


        // ----------------------------- Update Field Object Type  -----------------------------
        /// <summary>
        /// Method to update the model's field object type.
        /// </summary>
        void UpdateFieldObjectType()
        {
            switch (assigningType)
            {
                case G_VariableType.Boolean:
                    UpdateHelper<BoolVariable, bool>(variable: BoolVariable);
                    break;
                case G_VariableType.Float:
                    UpdateHelper<FloatVariable, float>(variable: FloatVariable);
                    break;
                case G_VariableType.String:
                    UpdateHelper<StringVariable, string>(variable: StringVariable);
                    break;
            }

            /// <summary>
            /// Gereric helper method for assigning the correct variable value to the field.
            /// </summary>
            /// <typeparam name="TVariable">Type variable.</typeparam>
            /// <param name="value">The variable value to assign with.</param>
            void UpdateHelper<TVariable, T>
            (
                TVariable variable
            )
                where TVariable : VariableFrameBase<T>
            {
                // Change field assigning type.
                ObjectField.objectType = typeof(TVariable);

                // Load field.
                ObjectField.SetValueWithoutNotify(variable);

                // Toggle empty style.
                ObjectField.ToggleEmptyStyle();
            }
        }


        // ----------------------------- IReversible -----------------------------
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
                    case G_VariableType.Boolean:
                        ReverseTo<BoolVariable, bool>(BoolVariable);
                        break;
                    case G_VariableType.Float:
                        ReverseTo<FloatVariable, float>(FloatVariable);
                        break;
                    case G_VariableType.String:
                        ReverseTo<StringVariable, string>(StringVariable);
                        break;
                }
            }


            /// <summary>
            /// Generic helper method for reversing the model's value
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
                    // Load value.
                    value = reverseValue;

                    // Change field assigning type.
                    ObjectField.objectType = type;

                    // Load field.
                    ObjectField.SetValueWithoutNotify(value);

                    // Toggle empty style.
                    ObjectField.ToggleEmptyStyle();
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }
    }
}