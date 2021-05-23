using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaUI : MonoBehaviour
{
    [SerializeField] private ManagerG4 manager;
    [SerializeField] private Text questionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private UnityEngine.Video.VideoPlayer questionVideo;
    [SerializeField] private AudioSource questionAudio;
    [SerializeField] private GameObject order;
    [SerializeField] private GameObject optionsHolder;
    [SerializeField] private List<Button> options;
    [SerializeField] private List<GameObject> optionsOrder;
    [HideInInspector][SerializeField] private List<Vector3> optionsOrderInitialPosition;
    [SerializeField] private List<GameObject> slotOptionsOrder;
    [SerializeField] private Button confirmButtonOrder;
    [SerializeField] private Color correctColor, wrongColor, normalColor, notHalfColor, moreHalfColor, fullColor;
    [SerializeField] private Transform poolOptionTransform;
    [SerializeField] public Image progressBarFill;
    public AudioClip rightAnswer, wrongAnswer;

    private Question actualQuestion;
    private bool answered;

    void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));

        }
        for (int i = 0; i < optionsOrder.Count; i++)
        {
            optionsOrderInitialPosition.Add(optionsOrder[i].GetComponent<RectTransform>().position);

        }
        confirmButtonOrder.onClick.AddListener(() => OnClick(confirmButtonOrder));
    }
    void Update()
    {
        progressBarFill.fillAmount = manager.myPoints / ((manager.maxPoints * manager.requirementPercentage) / 100);
        if (progressBarFill.fillAmount < 0.6)
        {
            progressBarFill.color = notHalfColor;
        }
        else if (progressBarFill.fillAmount >= 0.6 && 1 > progressBarFill.fillAmount)
        {
            progressBarFill.color = moreHalfColor;
        }
        else
        {
           progressBarFill.color = fullColor;
        }
    
    }
    public void SetQuestion(Question question)
    {
        this.actualQuestion = question;
        ViewHolderInitialSet();
        switch (question.questionType)
        {
            case QuestionType.TEXT:
                questionText.transform.parent.gameObject.SetActive(true);
                FillQuestionOptionsNormal();
                break;
            case QuestionType.IMAGE:
                questionImage.transform.gameObject.SetActive(true);
                FillQuestionOptionsNormal();
                questionImage.sprite = question.questionImg;
                break;
            case QuestionType.VIDEO:
                questionVideo.transform.gameObject.SetActive(true);
                questionVideo.clip = question.questionVideoClip;
                questionVideo.SetDirectAudioVolume(0, manager.audioSourceMusic.volume);
                FillQuestionOptionsNormal();
                questionVideo.Play();
                break;
            case QuestionType.AUDIO:
                questionAudio.transform.gameObject.SetActive(true);
                FillQuestionOptionsNormal();
                questionAudio.clip = question.questionAudioClip;
                questionAudio.volume = manager.audioSourceMusic.volume;
                questionAudio.Play();
                break;
            case QuestionType.ORDER:
                order.transform.gameObject.SetActive(true);
                FillQuestionOptionsOrder();
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
    void FillQuestionOptionsOrder()
    {
        List<string> optionList = actualQuestion.options;
        List<Sprite> spriteOptionList = actualQuestion.optionsOrderSprites;

        ShuffleList.ShuffledTwoListKeepingSamePosition(optionList, spriteOptionList);

        for (int i = 0; i < optionsOrder.Count; i++)
        {
            optionsOrder[i].transform.SetParent(poolOptionTransform);
            optionsOrder[i].GetComponentInChildren<Text>().text = optionList[i];
            optionsOrder[i].name = optionList[i];
            optionsOrder[i].GetComponentInChildren<GuideItem>().gameObject.GetComponent<Image>().sprite = actualQuestion.optionsOrderSprites[i];
            optionsOrder[i].transform.position = optionsOrderInitialPosition[i];
        }
        confirmButtonOrder.image.color = normalColor;
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
            bool isRightAnswer = false;
            switch (actualQuestion.questionType)
            {
                case QuestionType.ORDER:
                    for (int i = 0; i < slotOptionsOrder.Count; i++)
                    {
                        if (slotOptionsOrder[i].GetComponent<DropSlot>().item == null)
                        {
                            answered = false;
                            break;
                        }
                    }

                    isRightAnswer = manager.Answer(slotOptionsOrder[0].GetComponent<DropSlot>().item.name + ", " + 
                                                         slotOptionsOrder[1].GetComponent<DropSlot>().item.name + ", " + 
                                                         slotOptionsOrder[2].GetComponent<DropSlot>().item.name + ", " + 
                                                         slotOptionsOrder[3].GetComponent<DropSlot>().item.name);
                    if (isRightAnswer)
                    {
                        button.image.color = correctColor;

                    }
                    else
                    {
                        button.image.color = wrongColor;
                    }
                    break;
                default:
                    isRightAnswer = manager.Answer(button.name);
                    if (isRightAnswer)
                    {
                        button.image.color = correctColor;
                        manager.PlaySFXSound(rightAnswer);
                    }
                    else
                    {
                        button.image.color = wrongColor;
                        manager.PlaySFXSound(wrongAnswer);
                    }
                    break;
            }

        }
    }
}
