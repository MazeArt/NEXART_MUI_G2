using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueSoundCancelerClickingThis : MonoBehaviour, IPointerDownHandler
{
    DialogueManager dialogueManager;

    void Start()
    {
        addPhysics2DRaycaster();
        dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
    }
    public void addPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
            dialogueManager.StopAllCoroutines();
    }
}
