using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerG4 : MonoBehaviour
{
    private DialogueManager dialogueManager;
    [SerializeField] private TriviaUI triviaUI;
    [SerializeField] private QuizDataScriptable quizData;
    private List<Question> _questions;
    public GameObject initialCanvas, themesCanvas, triviaCanvas, finalCanvas;
    public int timeLimit;
    public int questionsInGameCount;
    private int selectedTheme;
    public Text timer;
    [SerializeField] private Button finishTheGameBtn;

    public float requirementPercentage;
    public GameObject wrongAnsweredPrefab;

    private int timeToWaitForHide = 1;
    private Question selectedQuestionToAnswer;

    [Header("In game lists, no editar desde inspector ya que se llenan por c�digo")]

    public float maxPoints;
    public float myPoints;
    public Question selectedQuestionFromList;
    public List<Button> notUsedThemes;
    public List<Question> _selectedQuestionsList; 
    public List<Question> _wrongAnswered;
    public List<Question> temp = null;
    public List<int> usedInt = null;

    void Start()
    {
        dialogueManager = this.gameObject.GetComponent<DialogueManager>();
        maxPoints = 0;
        myPoints = 0;
        _questions = quizData.questions;
        var collection = themesCanvas.GetComponentsInChildren<Button>();
        foreach (Button button in collection)
        {
            notUsedThemes.Add(button);
            Debug.Log(button.GetComponentInChildren<Text>().text);
            
        }
        triviaCanvas.SetActive(false);
        themesCanvas.SetActive(false);
        finalCanvas.SetActive(false);

        GameIntroduction();
    }
    public void GameIntroduction()
    {
        //El profesor introduce y expone el objetivo
        //(escena video)
        //se presiona bot�n del canvas para continuar
        initialCanvas.SetActive(true);
        dialogueManager.activeHolder = initialCanvas.GetComponentInChildren<DialogueHolder>();
        dialogueManager.ResetDialogueManager();

    }
    public void GameIterationStart()
    {
        initialCanvas.SetActive(false);
        themesCanvas.SetActive(true);
        foreach (var nUsed in notUsedThemes)
        {
            nUsed.interactable = true;
        }
        selectedQuestionFromList = null;
        _selectedQuestionsList.Clear();
    }
    /// <summary>
    /// Se deshabilita el boton de la opcion seleccionada
    /// </summary>
    /// <param name="button">Se debe seleccionar por inspector el boton a deshabilitar</param>
    public void RemoveButtonFromOptions(Button button)
    {
        Button[] buttons = themesCanvas.GetComponentsInChildren<Button>();
        foreach (var but in buttons)
        {
            but.interactable = false;
        }
        notUsedThemes.Remove(button);
        StartCoroutine(WaitToHideSomething(timeToWaitForHide, themesCanvas));
    }
    /// <summary>
    /// Esperar un tiempo para desactivar un objeto
    /// </summary>
    /// <param name="time">tiempo de espera</param>
    /// <param name="elementToHide">elemento que se desactivara</param>
    /// <returns></returns>
    IEnumerator WaitToHideSomething(int time, GameObject elementToHide)
    {
        yield return new WaitForSeconds(time);
        elementToHide.SetActive(false);
    }
    /// <summary>
    /// Se selecciona el tema en base al bot�n seleccionado. Se utiliza para seleccionar las preguntas relacionadas con el tema llenando la lista "_selectedQuestionsList"
    /// </summary>
    /// <param name="theme">Se debe configurar por inspector el numero del tema (del 0 a n-1) cuando n = numero de temas</param>
    public void SelectTheme(int theme)
    {
        //Se reinicia el contador cada vez que comienza un nuevo tema
        StartCoroutine(TimerTriviaAndDeadEnd(timeLimit, timeToWaitForHide));
        selectedTheme = theme;
        temp.Clear();
        usedInt.Clear();
        foreach (var question in _questions)
        {
            //Se agregan a la lista todas las preguntas relacionadas con el tema
            if (question.questionTheme == selectedTheme)
            {
                selectedQuestionFromList = question;
                temp.Add(selectedQuestionFromList);
            }

        }
            SelectQuestionsFromList(temp);
        SelectQuestionToAnswer();

    }
    void SelectQuestionsFromList(List<Question> list)
    {
        for (int i = 0; i < questionsInGameCount; i++)
        {
            int rnd = Random.Range(0, list.Count);
            RecCallSelectQuestionsFromList(list, rnd);
        }
        foreach (var item in usedInt)
        {
                Debug.Log(item);
            }
    }
    void RecCallSelectQuestionsFromList(List<Question> list, int rnd)
    {
        if (usedInt.Contains(rnd))
        {
            rnd = Random.Range(0, list.Count);
            RecCallSelectQuestionsFromList(list, rnd);
        }
        else
        {
            usedInt.Add(rnd);
            _selectedQuestionsList.Add(temp[rnd]);
            maxPoints = maxPoints + temp[rnd].points;
        }
    }
    /// <summary>
    /// Selecciona una pregunta aleatoria de la lista de preguntas generada y la elimina de la lista
    /// </summary>
    void SelectQuestionToAnswer()
    {
        int rnd = Random.Range(0, _selectedQuestionsList.Count);
        selectedQuestionToAnswer = _selectedQuestionsList[rnd];
        _selectedQuestionsList.RemoveAt(rnd);


        triviaUI.SetQuestion(selectedQuestionToAnswer);

    }
    public bool Answer(string answered)
    {
        bool correctAnswer = false;
        if (answered == selectedQuestionToAnswer.correctAnswer)
        {
            //correcto
            correctAnswer = true;
            myPoints = myPoints + selectedQuestionToAnswer.points;
        }
        else
        {
            //Incorrecto
            _wrongAnswered.Add(selectedQuestionToAnswer); //recordar respuestas incorrectas

        }
        if (_selectedQuestionsList.Count != 0)
        {
            Invoke("SelectQuestionToAnswer", 1);
        }
        else
        {
            RunOutOfQuestionsInTheme();

        }
        return correctAnswer;
    }
    public IEnumerator TimerTriviaAndDeadEnd(int timeLimit, int tiempoDelay)
    {
        for (int i = tiempoDelay; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
        }
        triviaCanvas.SetActive(true);
        for (int i = timeLimit; i > 0; i--)
        {
            timer.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        timer.text = null;
        triviaCanvas.SetActive(false);
        Debug.Log("capum!"); //escena video
    }
    public void PlayAgainAudioQuestion(AudioSource audioSource)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.PlayOneShot(selectedQuestionToAnswer.questionAudioClip);
    }
    public void PlayAgainVideoQuestion(UnityEngine.Video.VideoPlayer videoPlayer)
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }
        videoPlayer.Play();
    }
    public void RunOutOfQuestionsInTheme()
    {
        if (notUsedThemes.Count != 0)
        {
            triviaCanvas.SetActive(false);
            initialCanvas.SetActive(true);
            dialogueManager.activeHolder = initialCanvas.GetComponentInChildren<DialogueHolder>();
            dialogueManager.activeHolder.GetComponentInChildren<Text>().text = "";
            dialogueManager.ResetDialogueManager();
            finishTheGameBtn.transform.gameObject.SetActive(true);
        }
        else
        {
            EndOfTheGame();
        }
        
    }
    public void EndOfTheGame()
    {
        StopAllCoroutines();
        triviaCanvas.SetActive(false);
        initialCanvas.SetActive(false);
        themesCanvas.SetActive(false);
        finalCanvas.SetActive(true);
        dialogueManager.activeHolder = finalCanvas.GetComponentInChildren<DialogueHolder>();
        Debug.Log("THE END");
        Debug.Log(myPoints + "/" + maxPoints);
        if (myPoints / (maxPoints * (requirementPercentage / 100)) >= 1)
        {
            //Animacion de victoria
            if (myPoints == maxPoints)
            {
                Jackpot();
            }
        }
        else
        {
            //animacion de derrota
        }
            GetAndShowWrongAnswered();
    }
    public void Jackpot()
    {
        Debug.Log("Jackpot!");
    }
    public void GetAndShowWrongAnswered()
    {
        foreach (Question question in _wrongAnswered)
        {   GameObject wrongAnswered = Instantiate(wrongAnsweredPrefab, FindObjectOfType<GridLayoutGroup>().gameObject.transform);
            wrongAnswered.name = question.questionInfo;
            wrongAnswered.GetComponentInChildren<Text>().text = question.questionInfo;
            wrongAnswered.transform.Find("Explanation").GetComponent<Text>().text = question.answerExplanation;

        }
    }
}


[System.Serializable]
public class Question
{
    public int questionTheme;
    public string questionInfo;
    public QuestionType questionType;
    public Sprite questionImg;
    public AudioClip questionAudioClip;
    public UnityEngine.Video.VideoClip questionVideoClip;

    public List<string> options;
    public List<Sprite> optionsOrderSprites;
    [Tooltip("Si question type es igual a Order, en respuesta correcta debe escribir options en orden esperado separado por ', ' (coma y espacio)")]
    public string correctAnswer;
    public string answerExplanation;
    public int points;

}
[System.Serializable]
public enum QuestionType
{
    TEXT,
    IMAGE,
    VIDEO,
    AUDIO,
    ORDER
}