using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaUI : MonoBehaviour
{
    [SerializeField] private ManagerG4 triviaManager;
    [SerializeField] private Text questionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private UnityEngine.Video.VideoPlayer questionVideo;
    [SerializeField] private AudioSource questionAudio;
    [SerializeField] private GameObject order;
    [SerializeField] private GameObject optionsHolder;
    [SerializeField] private List<Button> options;
    [SerializeField] private List<GameObject> optionsOrder;
    [SerializeField] private List<Vector3> optionsOrderInitialPosition;
    [SerializeField] private List<GameObject> slotOptionsOrder;
    [SerializeField] private Button confirmButtonOrder;
    [SerializeField] private Color correctColor, wrongColor, normalColor;
    [SerializeField] public Image progressBarFill;
    Transform poolOptionTransform;

    private Question actualQuestion;
    private bool answered;

    void Awake()
    {
        poolOptionTransform = GameObject.FindGameObjectWithTag("ItemPool").transform;
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));

        }
        for (int i = 0; i < optionsOrder.Count; i++)
        {
            optionsOrderInitialPosition[i] = (optionsOrder[i].GetComponent<RectTransform>().position);

        }
        confirmButtonOrder.onClick.AddListener(() => OnClick(confirmButtonOrder));
    }
    void Update()
    {
        progressBarFill.fillAmount = triviaManager.myPoints / (triviaManager.maxPoints * (triviaManager.requirementPercentage / 100));
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
            optionsOrder[i].GetComponent<Image>().sprite = actualQuestion.optionsOrderSprites[i];
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

                    isRightAnswer = triviaManager.Answer(slotOptionsOrder[0].GetComponent<DropSlot>().item.name + ", " + 
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
                    isRightAnswer = triviaManager.Answer(button.name);
                    if (isRightAnswer)
                    {
                        button.image.color = correctColor;

                    }
                    else
                    {
                        button.image.color = wrongColor;
                    }
                    break;
            }

        }
    }
}
