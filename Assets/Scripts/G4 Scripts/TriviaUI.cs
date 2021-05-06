using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaUI : MonoBehaviour
{
    [SerializeField] private SequenceG4 triviaManager;
    [SerializeField] private Text questionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private UnityEngine.Video.VideoPlayer questionVideo;
    [SerializeField] private AudioSource questionAudio;
    [SerializeField] private GameObject order;
    [SerializeField] private GameObject optionsHolder;
    [SerializeField] private List<Button> options;
    [SerializeField] private Color correctColor, wrongColor, normalColor;

    private Question actualQuestion;
    private bool answered;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));

        }
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
                questionText.transform.parent.gameObject.SetActive(true);
                FillQuestionOptionsNormal();
                break;
            case QuestionType.IMAGE:
                ViewHolderInitialSet();
                questionImage.transform.gameObject.SetActive(true);
                questionImage.sprite = question.questionImg;
                FillQuestionOptionsNormal();
                break;
            case QuestionType.VIDEO:
                ViewHolderInitialSet();
                questionVideo.transform.gameObject.SetActive(true);
                questionVideo.clip = question.questionVideoClip;
                questionVideo.Play();
                FillQuestionOptionsNormal();
                break;
            case QuestionType.AUDIO:
                ViewHolderInitialSet();
                questionAudio.transform.gameObject.SetActive(true);
                questionAudio.PlayOneShot(actualQuestion.questionAudioClip);
                FillQuestionOptionsNormal();
                break;
            case QuestionType.ORDER:
                ViewHolderInitialSet();
                order.transform.gameObject.SetActive(true);

                break;
            default:
                break;
        }
        questionText.text = actualQuestion.questionInfo;
        
    }
    void FillQuestionOptionsNormal()
    {

        optionsHolder.transform.gameObject.SetActive(true);
        List<string> optionList = ShuffleList.ShuffledList(actualQuestion.options);
        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = optionList[i];
            options[i].name = optionList[i];
            options[i].image.color = normalColor;
        }
        answered = false;
    }
    void ViewHolderInitialSet()
    {
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.gameObject.SetActive(false);
        questionVideo.transform.gameObject.SetActive(false);
        questionAudio.transform.gameObject.SetActive(false);
        order.transform.gameObject.SetActive(false);
        optionsHolder.transform.gameObject.SetActive(false);

    }
    public void OnClick(Button button)
    {
        if (!answered)
        {
            answered = true;
            bool isRightAnswer = triviaManager.Answer(button.name);
            if (isRightAnswer)
            {
                button.image.color = correctColor;

            }
            else
            {
                button.image.color = wrongColor;
            }
        }
    }
}
