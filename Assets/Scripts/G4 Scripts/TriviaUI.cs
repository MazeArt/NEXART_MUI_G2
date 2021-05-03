using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaUI : MonoBehaviour
{
    [SerializeField] private SequenceG4 manager;
    [SerializeField] private Text questionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private UnityEngine.Video.VideoPlayer questionVideo;
    [SerializeField] private AudioSource questionAudio;
    [SerializeField] private GameObject order;
    [SerializeField] private List<Button> options;

    private Question actualQuestion;
    private bool answered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetQuestion(Question question)
    {
        this.actualQuestion = question;
        switch (question.questionType)
        {
            case QuestionType.TEXT:
                ViewHolderInitialSet();
                questionImage.transform.parent.gameObject.SetActive(true);
                break;
            case QuestionType.IMAGE:
                ViewHolderInitialSet();
                questionImage.transform.gameObject.SetActive(true);
                questionImage.sprite = question.questionImg;
                break;
            case QuestionType.VIDEO:
                ViewHolderInitialSet();
                questionVideo.transform.gameObject.SetActive(true);
                questionVideo.clip = question.questionVideoClip;
                questionVideo.Play();
                break;
            case QuestionType.AUDIO:
                ViewHolderInitialSet();
                questionVideo.transform.gameObject.SetActive(true);
                questionAudio.PlayOneShot(actualQuestion.questionAudioClip);
                break;
            case QuestionType.ORDER:
                ViewHolderInitialSet();
                questionAudio.transform.gameObject.SetActive(true);

                break;
            default:
                break;
        }
    }

    void ViewHolderInitialSet()
    {
        questionImage.transform.parent.gameObject.SetActive(false);
        questionImage.transform.gameObject.SetActive(false);
        questionVideo.transform.gameObject.SetActive(false);
        questionAudio.transform.gameObject.SetActive(false);
        order.transform.gameObject.SetActive(false);


    }
}
