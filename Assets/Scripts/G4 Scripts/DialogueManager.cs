using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialoguesDataScriptable dialoguesData;
    [HideInInspector] public AudioSource audioSource;
    public float typingSpeed = 0.05f;
    public AudioClip typingSound;
    string activeSentence;
    int activeSentencePosition = 0;
    bool sentenceTimeFinished = false;
    [HideInInspector] public DialogueHolder activeHolder;


    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

    }

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
    public void OnTapTheScreen(DialogueHolder thisDialogueHolder)
    {
        sentenceTimeFinished = false;
        activeSentencePosition++;
        activeSentence = thisDialogueHolder.onScreenDialogue.dialogueScript[activeSentencePosition];
        StopCoroutine(WritingTheSentence(thisDialogueHolder));
        StartCoroutine(WritingTheSentence(thisDialogueHolder));
    }
    public IEnumerator WritingTheSentence(DialogueHolder thisDialogueHolder)
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

    public void ResetDialogueManager(string wantedDialogue)
    {
        activeHolder.myDialogueIs = wantedDialogue;
        sentenceTimeFinished = false;
        activeHolder.GetComponentInChildren<Text>().text = "";
        GetActiveSentence(wantedDialogue);
        if (!activeHolder.dialoguePlayed)
        {
            activeSentencePosition = 0;
        }
        if (activeHolder.dialoguePlayed)
        {
            activeSentencePosition = -1;
        }
        activeSentence = activeHolder.onScreenDialogue.dialogueScript[activeSentencePosition];
        StartCoroutine(WritingTheSentence(activeHolder));
        activeHolder.dialoguePlayed = true;
    }
    public void GetActiveSentence(string wantedDialogue)
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
