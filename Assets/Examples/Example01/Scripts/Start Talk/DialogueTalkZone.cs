using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AG
{
    public class DialogueTalkZone : MonoBehaviour
    {
        [SerializeField] private GameObject speechBubble;
        [SerializeField] private KeyCode talkKey = KeyCode.K;
        [SerializeField] private Text keyInputText;

        private DialogueController dialogueController;

        private void Awake()
        {
            speechBubble.SetActive(false);
            keyInputText.text = talkKey.ToString();
            dialogueController = GetComponent<DialogueController>();
        }

        void Update()
        {
            if (Input.GetKeyDown(talkKey) && speechBubble.activeSelf)
            {
                //dialogueController.StartDialogue();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                speechBubble.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                speechBubble.SetActive(false);
            }
        }
    }
}