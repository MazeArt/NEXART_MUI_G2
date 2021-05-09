using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialoguesDataScriptable dialoguesData;
    public AudioSource audioSource;
    public float typingSpeed = 0.05f;
    public AudioClip typingSound;
    string activeSentence;
    int activeSentencePosition = 0;
    bool sentenceTimeFinished = true;
    [Header("No editar desde el inspector")]
    public List<DialogueHolder> dialogueHolders;
    public DialogueHolder activeHolder;


    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        foreach (var holder in FindObjectsOfType<DialogueHolder>())
        {
            dialogueHolders.Add(holder);
        }
        foreach (var holder in dialogueHolders)
        {
            bool found = false;
            for (int i = 0; i < dialoguesData.dialogueScripts.Count; i++)
            {
                if (dialoguesData.dialogueScripts[i].dialogueName == holder.myDialogueIs && !found)
                {
                    holder.onScreenDialogue = dialoguesData.dialogueScripts[i];
                    holder.GetComponentInChildren<Text>().text = dialoguesData.dialogueScripts[i].dialogueScript[0];
                    found = true;
                }
            }
        }
    }

    [System.Obsolete]
    private void OnGUI()
    {

        if (sentenceTimeFinished)
        {
            if (activeSentencePosition < activeHolder.onScreenDialogue.dialogueScript.Count - 1 && activeHolder.gameObject.active == true)
            {


                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("I'm Working");
                    Debug.Log(activeSentencePosition + "activeSentencePosition");
                    Debug.Log(activeHolder.onScreenDialogue.dialogueScript.Count + "count");
                    OnTapTheScreen(activeHolder);
                }


            }
            else
            {
                ResetDialogueManager();
            }
        }

    }
    public void OnTapTheScreen(DialogueHolder thisDialogueHolder)
    {
        sentenceTimeFinished = false;
        activeSentence = thisDialogueHolder.onScreenDialogue.dialogueScript[activeSentencePosition + 1];
        activeSentencePosition++;
        StopCoroutine(WritingTheSentence(thisDialogueHolder));
        StartCoroutine(WritingTheSentence(thisDialogueHolder));
        //StartCoroutine("WritingTheSentence");
        //thisDialogueHolder.GetComponentInChildren<Text>().text = activeSentence;

    }
    public IEnumerator WritingTheSentence(DialogueHolder thisDialogueHolder)
    {
        Debug.Log("I'm writing");
        thisDialogueHolder.GetComponentInChildren<Text>().text = "";

        foreach (char letter in activeSentence)
        {
            audioSource.PlayOneShot(typingSound);
            thisDialogueHolder.GetComponentInChildren<Text>().text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

            sentenceTimeFinished = true;
        
    }
    
    public void ResetDialogueManager()
    {
        if (!activeHolder.dialoguePlayed)
        {
            activeSentencePosition = 0;
            activeHolder.dialoguePlayed = true;
        }
        else
        {

            activeSentencePosition = -1;
            sentenceTimeFinished = true;
        }
    }
}
[System.Serializable]
public class Dialogue
{
    public string dialogueName;
    public List<string> dialogueScript;
}
