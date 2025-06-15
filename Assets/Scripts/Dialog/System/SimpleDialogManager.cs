using System;
using System.Collections.Generic;
using System.Linq;
using Dialog.Model;
using Interactable;
using UnityEngine;
using UnityEngine.UI;

namespace Dialog.System
{
    public class SimpleDialogueManager : MonoBehaviour, IInteractable
    {
        public GameObject optionButtonPrefab;
        public Transform optionsContainer;

        [SerializeField] private List<DialogueNode> dialogue;
        private void ShowNode(string nodeId)
        {
            DialogueController.instance.ClearDialogueInstance();
            // Ищем узел по ID в списке
            var node = dialogue.FirstOrDefault(n => n.NodeId == nodeId);
            if (node == null) return;

            DialogueController.instance.NewDialogueInstance(node.Response, node.CharacterId);
            ClearOptions();

            foreach (var option in node.Options)
            {
                if (option.NextNodeId == "Key")
                {
                    if (Player.Player.instance.ArtCount < 3)
                    {
                        continue;
                    }
                }
                
                var btn = Instantiate(optionButtonPrefab, optionsContainer);
                btn.GetComponentInChildren<Text>().text = option.responses;
                var btnComponent = btn.GetComponent<Button>();
                
                btnComponent.onClick.AddListener(() => ShowNode(option.NextNodeId));
                btnComponent.onClick.AddListener(() => option.OnClick.Invoke());
            }
        }
        
        private void ClearOptions()
        {
            foreach (Transform child in optionsContainer)
            {
                Destroy(child.gameObject);
            }
        }

        public void Interact()
        {
            ShowNode("start");
        }

        public string GetDescription()
        {
            return "Поговорить";
        }
    }
}