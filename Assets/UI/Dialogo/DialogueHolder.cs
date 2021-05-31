using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// Componente del prefab DialogueHolder. Solo puede haber uno ACTIVO por pantalla (pueden haber más, no interactuables)
/// </summary>
public class DialogueHolder : MonoBehaviour, IPointerDownHandler
{
    [HideInInspector] public string myDialogueIs;
    public Dialogue onScreenDialogue;
    public bool dialoguePlayed;
    private DialogueManager dialogueManager;
    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        dialogueManager.playingADialogue = true;
    }
}
