using System;
using System.Collections.Generic;
using Interactable;
using UnityEngine;
using UnityEngine.Events;

namespace Scene_Setup
{
    public class GameEnd : MonoBehaviour, IInteractable
    {
        [SerializeField] private List<GameObject> artefacts;

        [SerializeField] private GameObject portal;

        [SerializeField] private UnityEvent onPortalEnter;
        
        [SerializeField] private bool _ritualStarted;
        
        private void StartRitual()
        {
            _ritualStarted = true;
            
            foreach (var artefact in artefacts)
            {
                artefact.SetActive(true);
                portal.SetActive(true);
            }
        }

        public void OnTrigger(Collider other)
        {
            if(_ritualStarted == false)
                return;
            
            var isPlayer = other.gameObject.CompareTag("Player");
            
            if(isPlayer == false)
                return;
            
            onPortalEnter.Invoke();
        }

        public void Interact()
        {
            StartRitual();
        }

        public string GetDescription()
        {
            return "Начать Ритуал";
        }
    }
}