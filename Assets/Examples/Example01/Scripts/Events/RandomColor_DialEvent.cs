using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "Dialogue/New Dialogue Event/Random Color")]
    public class RandomColor_DialEvent : DialogueEvent
    {
        public Material mat;

        public override void Execute()
        {
            mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}