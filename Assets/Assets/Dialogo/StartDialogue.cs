using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    DialogueManager dialogueManager;
    DialogueHolder dialogueholder;
    // Start is called before the first frame update
    void Start()
    {   //obtiene el DialogueManager en pantalla (solo 1 por escena)
        dialogueManager = FindObjectOfType<DialogueManager>();

        //Linea para que se genere un dialogo en el holder en pantalla
        dialogueManager.StartNewDialogueManager(FindObjectOfType<DialogueHolder>().GetComponent<DialogueHolder>(), "DialogueName", 1f);
    }
    private void Update()
    {
        
    }
}
