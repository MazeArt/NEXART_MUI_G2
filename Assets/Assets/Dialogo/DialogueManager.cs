using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// Agregar al manager del juego. Dialogue Controller, solo se necesita uno en la escena. Solo puede haber un dialogo en escena interactuando.
/// </summary>
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialoguesDataScriptable dialoguesData;
    [HideInInspector] public AudioSource audioSource;
    [HideInInspector] public DialogueHolder activeHolder;
    public float typingSpeed = 0.05f;
    public AudioClip typingSound;
    string activeSentence;
    public int activeSentencePosition = 0;
    public GameObject holder;
    bool sentenceTimeFinished = false;
    public bool playingADialogue = true;
    public Animator dialogueAnimator;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void Start()
    {
        addPhysics2DRaycaster();
    }
    /// <summary>
    /// Inicia la accion de cambiar el texto cuando se presiona el click izquierdo (o tap) en la pantalla
    /// </summary>
    /// 
    [System.Obsolete]
    private void OnGUI()
    {
        if (Input.GetMouseButtonUp(0))//esta es la entrada que activa el cambio de dialogo
        {
            if (sentenceTimeFinished)
            {
                if (activeSentencePosition < activeHolder.onScreenDialogue.dialogueScript.Count - 1
                    && activeHolder.gameObject.active == true)
                {
                    sentenceTimeFinished = false;
                    StartCoroutine(OnTapTheScreen());
                }
            }
        }
    }

    /// <summary>
    /// Realiza el cambio de la ORACI�N en el holder activo, basado en la posici�n activa
    /// </summary>
    /// <param name="thisDialogueHolder"></param>
    IEnumerator OnTapTheScreen()
    {
        yield return new WaitForSeconds(0.1f);
        if (playingADialogue)
        {
            activeSentencePosition++;
            Debug.Log(activeSentencePosition);
            activeSentence = activeHolder.onScreenDialogue.dialogueScript[activeSentencePosition];
            StopCoroutine(WritingTheSentence(activeHolder));
            StartCoroutine(WritingTheSentence(activeHolder));
            if (activeSentencePosition == 10)
            {
                dialogueAnimator.Play("introOffAnim");

                StartCoroutine(DialogueOffEvent());
            }

        }
        else if (!playingADialogue)
        {
            sentenceTimeFinished = true;
        }
    }

    IEnumerator DialogueOffEvent()
    {
        yield return new WaitForSeconds(2);
        holder.SetActive(false);
    }

    /// <summary>
    /// Comienza a escribir un nuevo dialogo desde el principio en el holder
    /// </summary>
    /// <param name="dialogueHolder">el holder</param>
    /// <param name="wantedDialogue">nuevo dialogo</param>
    public void StartNewDialogueManager(DialogueHolder dialogueHolder, string wantedDialogue, float waitForSeconds = 0, bool playingD = true)
    {
        StartCoroutine(StartDialogue(dialogueHolder, wantedDialogue, waitForSeconds, playingD));
    }
    IEnumerator StartDialogue(DialogueHolder dialogueHolder, string wantedDialogue, float waitForSeconds = 0, bool playingD = true)
    {
        playingADialogue = playingD;
        activeHolder = dialogueHolder;
        activeHolder.dialoguePlayed = false;
        activeHolder.myDialogueIs = wantedDialogue;
        sentenceTimeFinished = false;
        activeHolder.GetComponentInChildren<Text>().text = "";
        yield return new WaitForSeconds(waitForSeconds);
        GetActiveDialogue(wantedDialogue);
        activeSentencePosition = 0;
        activeSentence = activeHolder.onScreenDialogue.dialogueScript[activeSentencePosition];
        StartCoroutine(WritingTheSentence(activeHolder));
        activeHolder.dialoguePlayed = true;
    }
    /// <summary>
    /// Escribe la oraci�n letra por letra en el holder
    /// </summary>
    /// <param name="thisDialogueHolder"></param>
    /// <returns></returns>
    private IEnumerator WritingTheSentence(DialogueHolder thisDialogueHolder)
    {
        thisDialogueHolder.GetComponentInChildren<Text>().text = "";
        foreach (char letter in activeSentence)
        {
            audioSource.PlayOneShot(typingSound);
            thisDialogueHolder.GetComponentInChildren<Text>().text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        sentenceTimeFinished = true;
    }

    /// <summary>
    /// Obtiene el dialogo completo y lo posiciona en el holder activo
    /// </summary>
    /// <param name="wantedDialogue"></param>
    private void GetActiveDialogue(string wantedDialogue)
    {
        bool found = false;
        foreach (var dialogue in dialoguesData.dialogueScripts)
        {
            if (dialogue.dialogueName == wantedDialogue && found == false)
            {
                activeHolder.onScreenDialogue = dialogue;
                found = true;
            }
        }
    }
    private void addPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }
}
[System.Serializable]
public class Dialogue
{
    public string dialogueName;
    public List<string> dialogueScript;
}