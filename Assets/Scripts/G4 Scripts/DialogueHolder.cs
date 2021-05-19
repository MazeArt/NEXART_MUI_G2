using UnityEngine;
/// <summary>
/// Componente del prefab DialogueHolder. Solo puede haber uno ACTIVO por pantalla (pueden haber más, no interactuables)
/// </summary>
public class DialogueHolder : MonoBehaviour
{
    [HideInInspector] public string myDialogueIs;
    public Dialogue onScreenDialogue;
    public bool dialoguePlayed;

}
