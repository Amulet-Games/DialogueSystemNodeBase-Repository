using System;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class VariableGroupData
    {
        /// <summary>
        /// The data's boolean variable value.
        /// </summary>
        [SerializeField] public BoolVariable BoolVariable;


        /// <summary>
        /// The data's float variable value.
        /// </summary>
        [SerializeField] public FloatVariable FloatVariable;


        /// <summary>
        /// The data's string variable value.
        /// </summary>
        [SerializeField] public StringVariable StringVariable;
    }
}