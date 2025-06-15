using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueExample : MonoBehaviour
{
	private void Start() {
		DialogueController.instance.NewDialogueInstance("Hey! Hope you are doing well. This is a test dialogue instance for the new dialogue package EvMeshPro","1");
		DialogueController.instance.NewDialogueInstance("This is an [EXAGGERATE]easy to use package[/EXAGGERATE] to give developers a good looking and simple dialogue system."); 
	}
}
