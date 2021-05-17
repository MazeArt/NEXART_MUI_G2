using UnityEngine;
using UnityEngine.EventSystems;

public class Detecting2D : MonoBehaviour, IPointerDownHandler
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
            Debug.Log("hi");
        if (eventData.pointerCurrentRaycast.gameObject.tag == "DontPlaySound")
        {
            dialogueManager.StopAllCoroutines();

        }
    }
}
