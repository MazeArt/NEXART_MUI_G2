using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Dialogue Controller, solo se necesita uno en la escena. Solo puede haber un dialogo en escena interactuando.
/// </summary>
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialoguesDataScriptable dialoguesData;
    [HideInInspector] public AudioSource audioSource;
    [HideInInspector] public DialogueHolder activeHolder;
    public float typingSpeed = 0.05f;
    public AudioClip typingSound;
    string activeSentence;
    int activeSentencePosition = 0;
    bool sentenceTimeFinished = false;

    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
    /// <summary>
    /// Inicia la accion de cambiar el texto cuando se presiona el click izquierdo (o tap) en la pantalla
    /// </summary>
    [System.Obsolete]
    private void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (sentenceTimeFinished)
            {
                if (activeSentencePosition < activeHolder.onScreenDialogue.dialogueScript.Count-1 && activeHolder.gameObject.active == true)
                {
                    OnTapTheScreen(activeHolder);
                }
            }
        }
    }

    /// <summary>
    /// Realiza el cambio de la ORACIÓN en el holder activo, basado en la posición activa
    /// </summary>
    /// <param name="thisDialogueHolder"></param>
    private void OnTapTheScreen(DialogueHolder thisDialogueHolder)
    {
        sentenceTimeFinished = false;
        activeSentencePosition++;
        activeSentence = thisDialogueHolder.onScreenDialogue.dialogueScript[activeSentencePosition];
        StopCoroutine(WritingTheSentence(thisDialogueHolder));
        StartCoroutine(WritingTheSentence(thisDialogueHolder));
    }
    /// <summary>
    /// Comienza a escribir un nuevo dialogo desde el principio en el holder
    /// </summary>
    /// <param name="dialogueHolder">el holder</param>
    /// <param name="wantedDialogue">nuevo dialogo</param>
    public void StartNewDialogueManager(DialogueHolder dialogueHolder, string wantedDialogue, float waitForSeconds = 0)
    {
        StartCoroutine(StartDialogue(dialogueHolder, wantedDialogue, waitForSeconds));
    }
    IEnumerator StartDialogue(DialogueHolder dialogueHolder, string wantedDialogue, float waitForSeconds = 0)
    {
        yield return new WaitForSeconds(waitForSeconds);
        activeHolder = dialogueHolder;
        activeHolder.dialoguePlayed = false;
        activeHolder.myDialogueIs = wantedDialogue;
        sentenceTimeFinished = false;
        activeHolder.GetComponentInChildren<Text>().text = "";
        GetActiveDialogue(wantedDialogue);
        activeSentencePosition = 0;
        activeSentence = activeHolder.onScreenDialogue.dialogueScript[activeSentencePosition];
        StartCoroutine(WritingTheSentence(activeHolder));
        activeHolder.dialoguePlayed = true;
    }
    /// <summary>
    /// Escribe la oración letra por letra en el holder
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
}
[System.Serializable]
public class Dialogue
{
    public string dialogueName;
    public List<string> dialogueScript;
}
