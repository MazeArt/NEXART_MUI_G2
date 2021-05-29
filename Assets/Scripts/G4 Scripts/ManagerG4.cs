using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerG4 : MonoBehaviour
{
    private DialogueManager dialogueManager;
    [SerializeField] private TriviaUI triviaUI;
    [SerializeField] private QuizDataScriptable quizData;
    private List<Question> _questions;
    public GameObject initialCanvas, themesCanvas, triviaCanvas, finalCanvas, settingsTriviaCanvas, generalFinalCanvas, generalAnimationFinal, jackpotFinalCanvas;
    public int timeLimit;
    public int questionsInGameCount;
    private int selectedTheme;
    public Text timer;
    [SerializeField] private Button finishTheGameBtn;
    public Text puntaje;
    public AudioSource audioSourceMusic;
    public AudioSource audioSourceSFX;
    public GameObject picarte;


    public float requirementPercentage;
    public GameObject wrongAnsweredPrefab;
    public AudioClip endGameVictory, endGameDefeat, endGameJackpot, endThemeVictory, endThemeDefeat;
    private int timeToWaitForHide = 1;
    private Question selectedQuestionToAnswer;

    [HideInInspector] public float maxPoints;
    [HideInInspector] public float myPoints;
    [HideInInspector] public Question selectedQuestionFromList;
    [HideInInspector] public List<Button> notUsedThemes;
    [HideInInspector] public List<Question> _selectedQuestionsList;
    [HideInInspector] public List<Question> _wrongAnswered;
    [HideInInspector] public List<Question> temp = null;
    [HideInInspector] public List<int> usedInt = null;

    void Start()
    {
        StopAllCoroutines();
        dialogueManager = this.gameObject.GetComponent<DialogueManager>();
        settingsTriviaCanvas = GameObject.FindGameObjectWithTag("Settings");
        settingsTriviaCanvas.GetComponent<SettingsG4>().manager = this;
        settingsTriviaCanvas.GetComponent<SettingsG4>().GetStartSettings();
        maxPoints = 0;
        myPoints = 0;
        _questions = quizData.questions;
        var collection = themesCanvas.GetComponentsInChildren<Button>();
        foreach (Button button in collection)
        {
            notUsedThemes.Add(button);
        }
        settingsTriviaCanvas.SetActive(true);
        triviaCanvas.SetActive(false);
        themesCanvas.SetActive(false);
        finalCanvas.SetActive(false);
        initialCanvas.SetActive(false);
        generalAnimationFinal.SetActive(false);
    }
    /// <summary>
    /// Introduccion del juego, picarte pide ayuda para arreglar su computadora y se activa el contador de tiempo limite
    /// </summary>    
    public void GameIntroduction()
    {
        //Se inicia el contador
        StopAllCoroutines();
        StartCoroutine(TimerTriviaAndDeadEnd(timeLimit, timeToWaitForHide));
        settingsTriviaCanvas.SetActive(false);
        initialCanvas.SetActive(true);
        dialogueManager.StartNewDialogueManager(initialCanvas.GetComponentInChildren<DialogueHolder>(), "InitialExplanation");
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
    /// Se selecciona el tema en base al botón seleccionado. Se utiliza para seleccionar las preguntas relacionadas con el tema llenando la lista "_selectedQuestionsList"
    /// </summary>
    /// <param name="theme">Se debe configurar por inspector el numero del tema (del 0 a n-1) cuando n = numero de temas</param>
    public void SelectTheme(int theme)
    {
        StartCoroutine(WaitToShowSomething(1, triviaCanvas));
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
    /// <summary>
    /// Escoger aleatoriamente una cantidad de respuesta limitadas de una lista de preguntas
    /// </summary>
    /// <param name="list"></param>
    void SelectQuestionsFromList(List<Question> list)
    {
        if (list.Count >= questionsInGameCount)
        {
            for (int i = 0; i < questionsInGameCount; i++)
            {
                int rnd = Random.Range(0, list.Count);
                RecCallSelectQuestionsFromList(list, rnd);
            }
        }
        else
        {
            for (int i = 0; i < list.Count; i++)
            {
                int rnd = Random.Range(0, list.Count);
                RecCallSelectQuestionsFromList(list, rnd);
            }
        }
    }
    /// <summary>
    /// Funcion recursiva para elegir aleatoriamente la pregunta de una lista sin repetirlas
    /// </summary>
    /// <param name="list"></param>
    /// <param name="rnd"></param>
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
    /// Selecciona una pregunta aleatoria de la lista de preguntas generada con selectQuestionFromList, la elimina de la lista y la envía al display
    /// </summary>
    void SelectQuestionToAnswer()
    {
        int rnd = Random.Range(0, _selectedQuestionsList.Count);
        selectedQuestionToAnswer = _selectedQuestionsList[rnd];
        _selectedQuestionsList.RemoveAt(rnd);

        triviaUI.SetQuestion(selectedQuestionToAnswer);
    }
    /// <summary>
    /// Obtiene la respuesta evalúa si está correcta, después llama a otra pregunta para mostrar o a la funcion RunOutOfQuestionsInTheme
    /// </summary>
    /// <param name="answered"></param>
    /// <returns></returns>
    public bool Answer(string answered)
    {
        bool correctAnswer = false;
        if (answered == selectedQuestionToAnswer.correctAnswer) //respuesta correcta
        {
            correctAnswer = true;
            myPoints = myPoints + selectedQuestionToAnswer.points;
        }
        else //respuesta incorrecta
        {
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
    public void RunOutOfQuestionsInTheme()
    {
        if (notUsedThemes.Count != 0)
        {
            StartCoroutine(WaitToHideSomething(1, triviaCanvas));
            StartCoroutine(WaitToShowSomething(1, initialCanvas));
            dialogueManager.StartNewDialogueManager(initialCanvas.GetComponentInChildren<DialogueHolder>(), "AskIfContinue", 1f);
            finishTheGameBtn.transform.gameObject.SetActive(true);
            if (myPoints / ((maxPoints * requirementPercentage) / 100) >= 1)
            {
                PlaySFXSound(endThemeVictory);
            }
            else
            {
                PlaySFXSound(endThemeDefeat);
            }
        }
        else
        {
            EndOfTheGame();
        }
    }
    public void EndOfTheGame()
    {
        settingsTriviaCanvas.SetActive(false);
        triviaCanvas.SetActive(false);
        initialCanvas.SetActive(false);
        themesCanvas.SetActive(false);
        StopAllCoroutines();
        finalCanvas.SetActive(true);
        generalAnimationFinal.SetActive(true);
        generalFinalCanvas.SetActive(false);
        if (myPoints / ((maxPoints * requirementPercentage) / 100) >= 1)//evalua el porcentaje (si llega a lo exigido)
        {
            if (myPoints == maxPoints) //Animación victoria jackpot
            {
                StartCoroutine(FinalAnimation(1, jackpotFinalCanvas));
                Jackpot();
            }
            else //animación victoria
            {
                PlaySFXSound(endGameVictory);
                StartCoroutine(FinalAnimation(0, generalFinalCanvas));
            }
        }
        else //animacion de derrota
        {
            PlaySFXSound(endGameDefeat);
            StartCoroutine(FinalAnimation(2, generalFinalCanvas));
        }
    }
    public void Jackpot()
    {
        PlaySFXSound(endGameJackpot);
    }

    /// <summary>
    /// Muestra las preguntas respondidas incorrectamente en el drid layout grup que encuentre activo
    /// </summary>
    public void GetAndShowWrongAnswered()
    {
        foreach (Question question in _wrongAnswered)
        {
            GameObject wrongAnswered = Instantiate(wrongAnsweredPrefab, FindObjectOfType<GridLayoutGroup>().gameObject.transform);
            wrongAnswered.name = question.questionInfo;
            wrongAnswered.GetComponentInChildren<Text>().text = question.questionInfo;
            wrongAnswered.transform.Find("Explanation").GetComponent<Text>().text = question.answerExplanation;
        }
    }
    public void PlaySFXSound(AudioClip audioClip)
    {
        audioSourceSFX.PlayOneShot(audioClip);
    }

    //---------------------------------------------------Botones---------------------------------------------------------------------
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
    public void ReStartScene()
    {
        settingsTriviaCanvas.SetActive(true);
        SceneManager.LoadScene("G4 MainScene");
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
        StartCoroutine(WaitToHideSomething(1, themesCanvas));
    }
    //---------------------------------------------------Enumerators-----------------------------------------------------------------
    public IEnumerator TimerTriviaAndDeadEnd(int timeLimit, int tiempoDelay)
    {
        for (int i = tiempoDelay; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
        }

        for (int i = timeLimit; i > 0; i--)
        {
            timer.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        timer.text = null;
        EndOfTheGame();
    }
    /// <summary>
    /// Animacion de picarte al final del juego y activa el canvas correspondiente
    /// </summary>
    /// <param name="animationInt">Win = 0, jackpot = 1, defeat = 2, talk = 3</param>
    /// <param name="animatedObjectName"></param>
    /// <param name="timeShowing"></param>
    /// <returns></returns>
    IEnumerator FinalAnimation(int animationInt, GameObject finalCanvasToShow, float timeShowing = 3)
    {
        generalAnimationFinal.SetActive(true);
        picarte.GetComponent<Animator>().SetInteger("Victoria cero Jackpot uno Derrota dos", animationInt);
        yield return new WaitForSeconds(timeShowing);
        generalAnimationFinal.SetActive(false);
        if (finalCanvasToShow == generalFinalCanvas)
        {
            generalFinalCanvas.SetActive(true);
            dialogueManager.StartNewDialogueManager(finalCanvas.GetComponentInChildren<DialogueHolder>(), "FinalExplanation");
            GetAndShowWrongAnswered();
        }
        else if (finalCanvasToShow == jackpotFinalCanvas)
        {
            jackpotFinalCanvas.SetActive(true);
            dialogueManager.StartNewDialogueManager(finalCanvas.GetComponentInChildren<DialogueHolder>(), "JackPot");
        }
        puntaje.text = myPoints + "/" + maxPoints;
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
    IEnumerator WaitToShowSomething(int time, GameObject elementToShow)
    {
        yield return new WaitForSeconds(time);
        elementToShow.SetActive(true);
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