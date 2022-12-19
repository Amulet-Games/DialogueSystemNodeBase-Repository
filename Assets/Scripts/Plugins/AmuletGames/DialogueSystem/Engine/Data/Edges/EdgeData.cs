using System;

namespace AG.DS
{
    [Serializable]
    public class EdgeData
    {
        /// <summary>
        /// The data's input port GUID value.
        /// </summary>
        public string InputPortGUID;


        /// <summary>
        /// The data's output port GUID value.
        /// </summary>
        public string OutputPortGUID;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the edge data class.
        /// </summary>
        /// <param name="inputPortGUID">The input port GUID to set for.</param>
        /// <param name="outputPortGUID">The output port GUID to set for.</param>
        public EdgeData
        (
            string inputPortGUID,
            string outputPortGUID
        )
        {
            InputPortGUID = inputPortGUID;
            OutputPortGUID = outputPortGUID;
        }
    }
}