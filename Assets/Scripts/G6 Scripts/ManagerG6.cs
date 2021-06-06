using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerG6 : MonoBehaviour
{
    public Camera cam1, cam2;
    public GameObject panelCam1L, panelCam1R, panelCam2L, panelCam2R;
    public Text textoChico;
    public ObjBaseOrden[] objBases;
    string greatertolessOrlesstogreater = "greater";
    private string stage; //S1F1; S1F1; S2F1;

    private void Start()
    {   
        panelCam1L.SetActive(false);
        panelCam1R.SetActive(false);
        panelCam2L.SetActive(false);
        panelCam2R.SetActive(false);
        StageOneOrderFaseOne();
    }
    public void StageOneOrderFaseOne() //Ordenar por masa
    {
        GameObject.Find("Stage 1").gameObject.SetActive(true);
        stage = "S1F1";

    }
    public void StageOneOrderFaseTwo() //Ordenar por volumen
    {
        GameObject.Find("Stage 1").gameObject.SetActive(true);
        stage = "S1F2";
    }
    public void StageTwoMassComparisonFaseOne()
    {
        GameObject.Find("Stage 2").gameObject.SetActive(true);
    }
    public void CompareElements()
    {
        var last = 0f;
        bool ok = true;
        switch (stage)
        {
            case "S1F1": //MASA
                switch (greatertolessOrlesstogreater)
                {
                    case "greater":
                        last = objBases[0].massCam1;
                        for (int i = 1; i < objBases.Length; i++)
                        {
                            if (objBases[i].massCam1 > last && ok)
                            {
                                last = objBases[i].massCam1;
                                Debug.Log("ok");
                            }
                            else
                            {
                                ok = false;
                                Debug.Log("Wrong");
                            }
                        }
                        //if (bases[0].massCam1 > bases[1].massCam1 && bases[1].massCam1 > bases[2].massCam1 && bases[2].massCam1 > bases[3].massCam1)
                        //{
                        //    Debug.Log("win");
                        //}
                        break;
                    case "less":
                        last = objBases[0].massCam1;
                        for (int i = 1; i < objBases.Length; i++)
                        {
                            if (objBases[i].massCam1 < last && ok)
                            {
                                last = objBases[i].massCam1;
                                Debug.Log("ok");
                            }
                            else
                            {
                                ok = false;
                                Debug.Log("Wrong");
                            }
                        }
                        break;
                    default:
                        last = objBases[0].massCam1;
                        for (int i = 1; i < objBases.Length; i++)
                        {
                            if (objBases[i].massCam1 > last && ok)
                            {
                                last = objBases[i].massCam1;
                                Debug.Log("ok");
                            }
                            else
                            {
                                ok = false;
                                Debug.Log("Wrong");
                            }
                        }
                        break;

                }
                break;
            case "S1F2": //VOLUMEN
                switch (greatertolessOrlesstogreater)
                {
                    case "greater":
                        last = objBases[0].volumeCam1;
                        for (int i = 1; i < objBases.Length; i++)
                        {
                            if (objBases[i].volumeCam1 > last && ok)
                            {
                                last = objBases[i].volumeCam1;
                                Debug.Log("ok");
                            }
                            else
                            {
                                ok = false;
                                Debug.Log("Wrong");
                            }
                        }
                        break;
                    case "less":
                        last = objBases[0].volumeCam1;
                        for (int i = 1; i < objBases.Length; i++)
                        {
                            if (objBases[i].volumeCam1 < last && ok)
                            {
                                last = objBases[i].volumeCam1;
                                Debug.Log("ok");
                            }
                            else
                            {
                                ok = false;
                                Debug.Log("Wrong");
                            }
                        }
                        break;
                    default:
                        last = objBases[0].volumeCam1;
                        for (int i = 1; i < objBases.Length; i++)
                        {
                            if (objBases[i].volumeCam1 > last && ok)
                            {
                                last = objBases[i].volumeCam1;
                                Debug.Log("ok");
                            }
                            else
                            {
                                ok = false;
                                Debug.Log("Wrong");
                            }
                        }
                        break;
                }
                break;
            default:
                break;
        }

        if (ok)
        {
            //Setear algun texto de que lo ha hecho bien
        }
        else
        {
            //Setear algun texto de que lo ha hecho mal y por qué
        }

    }
    /// <summary>
    /// Actualizar los 2 textos de cada camara.
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

    //--------------------------------------------- Buttons -----------------------------------------------------------
    public void ResetElements()
    {
        foreach (ObjToCompare obj in FindObjectsOfType<ObjToCompare>())
        {
            obj.ResetMyPosition();
        }
        Debug.Log("Reset");
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
