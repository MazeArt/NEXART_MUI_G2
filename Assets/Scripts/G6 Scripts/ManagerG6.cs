using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerG6 : MonoBehaviour
{
    public Camera cam1, cam2;
    public GameObject panelCam1L, panelCam1R, panelCam2L, panelCam2R;
    public Text textoChico;
    //public Text textCam1L, textCam1R, textCam2L, textCam2R;

    private void Start()
    {   
        panelCam1L.SetActive(false);
        panelCam1R.SetActive(false);
        panelCam2L.SetActive(false);
        panelCam2R.SetActive(false);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="textMass1">Masa camara 1</param>
    /// <param name="textSize1">Tamaño camara 1</param>
    /// <param name="textMass2">Masa camara 2</param>
    /// <param name="textSize2">Tamaño camara 2</param>
    /// <param name="position">r = 0, L = 1</param>
    public void BalanzaCanvasUpdate(string textMass1, string textSize1, string textMass2, string textSize2, int position)
    {
        if (position == 0)
        {
            panelCam1R.SetActive(true);
            panelCam2R.SetActive(true);
            panelCam1R.GetComponentInChildren<Text>().text = ("Volumen: " + textMass1 + "\nTamaño: " + textSize1);
            panelCam2R.GetComponentInChildren<Text>().text = ("Volumen: " + textMass2 + "\nTamaño: " + textSize2);
        }
        if (position == 1)
        {
            panelCam1L.SetActive(true);
            panelCam2L.SetActive(true);
            panelCam1L.GetComponentInChildren<Text>().text = ("Volumen: " + textMass1 + "\nTamaño: " + textSize1);
            panelCam2L.GetComponentInChildren<Text>().text = ("Volumen: " + textMass2 + "\nTamaño: " + textSize2);
        }
    }
    //DialogueManager dialogueManager;
    //// Start is called before the first frame update
    //void Start()
    //{   //obtiene el DialogueManager en pantalla (solo 1 por escena)
    //    dialogueManager = FindObjectOfType<DialogueManager>();

    //    //Linea para que se genere un dialogo en el holder en pantalla
          //dialogueManager.StartNewDialogueManager(FindObjectOfType<DialogueHolder>().GetComponent<DialogueHolder>(), "DialogueName", 1f);
    //}

}
