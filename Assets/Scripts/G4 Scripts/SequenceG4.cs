using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceG4 : MonoBehaviour
{
    [SerializeField] private TriviaUI triviaUI;
    [SerializeField] private QuizDataScriptable quizData;
    private List<Question> _questions;
    public GameObject initialCanvas;
    [SerializeField] private Button finishTheGameBtn;
    public GameObject themesCanvas;
    public GameObject triviaCanvas;
    public int timeLimit;
    public int selectedTheme;
    public Text timer;

    private int timeToWaitForHide = 1;
    private Question selectedQuestionToAnswer;
    public List<Button> notUsedThemes;
    public Question selectedQuestionFromList; //No editar desde inspector, se llena por codigo
    public List<Question> _selectedQuestionsList; //No editar desde inspector, se llena por codigo

    /*Secuencia
     * Introducción
     * Mostrar temas para preguntas
     * --generar lista de botones con los temas posibles
     * --Los temas se van descartando
     */
    void Start()
    {
        _questions = quizData.questions;
        var collection = themesCanvas.GetComponentsInChildren<Button>();
        foreach (Button button in collection)
        {
            notUsedThemes.Add(button);
            Debug.Log(button.GetComponentInChildren<Text>().text);
            
        }
        triviaCanvas.SetActive(false);
        themesCanvas.SetActive(false);

        GameIntroduction();
    }
    public void GameIntroduction()
    {
        //El profesor introduce y expone el objetivo
        //(escena video)
        //se presiona botón del canvas para continuar
        initialCanvas.SetActive(true);

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
    /// Se selecciona el tema en base al botón seleccionado. Se utiliza para seleccionar las preguntas relacionadas con el tema llenando la lista "_selectedQuestionsList"
    /// </summary>
    /// <param name="theme">Se debe configurar por inspector el numero del tema (del 0 a n-1) cuando n = numero de temas</param>
    public void SelectTheme(int theme)
    {
        //Se reinicia el contador cada vez que comienza un nuevo tema
        StartCoroutine(TimerTriviaAndDeadEnd(timeLimit, timeToWaitForHide));
        selectedTheme = theme;
        
        foreach (var question in _questions)
        {
            //Se agregan a la lista todas las preguntas relacionadas con el tema
            if (question.questionTheme == selectedTheme)
            {
                selectedQuestionFromList = question;
                _selectedQuestionsList.Add(selectedQuestionFromList);
            }
        }
        SelectQuestionToAnswer();

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
            correctAnswer = true;
        }
        else
        {
            //Incorrecto
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
            finishTheGameBtn.transform.gameObject.SetActive(true);
        }
        else
        {
            EndOfTheGame();
        }
        
    }
    public void EndOfTheGame()
    {
        Debug.Log("THE END");
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