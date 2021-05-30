using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Agregar a objeto que se desea clickear sin activar la corrutina. Obs: Corrutina activa primera letra
/// </summary>
public class DontPlayDialogueWhenClickingThis : MonoBehaviour, IPointerDownHandler
{
    DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dialogueManager.playingADialogue = false;
    }
}
