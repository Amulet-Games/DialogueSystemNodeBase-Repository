using System;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class VariableGroupModel
    {
        /// <summary>
        /// The group's boolean variable value.
        /// </summary>
        [SerializeField] public BooleanVariable BoolVariable;


        /// <summary>
        /// The group's float variable value.
        /// </summary>
        [SerializeField] public FloatVariable FloatVariable;


        /// <summary>
        /// The group's string variable value.
        /// </summary>
        [SerializeField] public StringVariable StringVariable;
    }
}