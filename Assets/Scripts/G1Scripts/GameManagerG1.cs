using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerG1 : MonoBehaviour
{
    public Timer timer;
    public Inventory inventory;
    public Text textPoints;
    public Text textPointsOnScreen;
    public Text textElements;
    public Text winText;
    public Text gameOverText;

    private void Update()
    {
        if (timer.time <= 0)
        {
            GameOver();
        }

        if (inventory.FinalCount == 16)
        {
           

            Win();
        }
        textPointsOnScreen.text = inventory.points.ToString();
        textElements.text = inventory.FinalCount.ToString();
    }

    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        textPoints.gameObject.SetActive(true);
        textPoints.text = "Tú puntaje fue de: " + inventory.points.ToString();
        StartCoroutine(TimerToEnd());
    }
    void Win()
    {
        winText.gameObject.SetActive(true);

        StartCoroutine(TimerToWin());
    }

    public IEnumerator TimerToEnd()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(0);
    }
    public IEnumerator TimerToWin()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(0);
    }
}
