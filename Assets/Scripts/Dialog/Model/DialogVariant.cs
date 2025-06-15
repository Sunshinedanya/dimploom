using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Dialog.Model
{
    [Serializable]
    public class DialogVariant
    {
        public List<string> responses;
    }
    
    [Serializable]
    public class DialogueOption
    {
        public string responses;
        public string NextNodeId;
        public UnityEvent OnClick;

        public DialogueOption(string responses, string nextId)
        {
            this.responses = responses;
            NextNodeId = nextId;
        }
    }
    
    [Serializable]
    public class DialogueNode
    {
        public string NodeId; // Новое поле для идентификатора узла
        public string CharacterId;
        public string Response;
        public List<DialogueOption> Options;

        // Обновлённый конструктор
        public DialogueNode(
            string nodeId,
            string response,
            string characterId,
            List<DialogueOption> options = null
        )
        {
            NodeId = nodeId;
            Response = response;
            CharacterId = characterId;
            Options = options ?? new List<DialogueOption>();
        }
    }
}