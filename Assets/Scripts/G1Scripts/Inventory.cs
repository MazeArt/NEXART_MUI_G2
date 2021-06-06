using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Element> playerElements = new List<Element>();
    public ElementDataBase elementDataBase;
    public Transform pos1;
    public float planetSize;
    public int localCount;
    public int FinalCount;
    public int points;
    public float spacing;
    public GameObject planetHolder;
    public float inventorySize;


    private int firstLVLCount;
    private int secondLVLCount;
    private int thirdLVLCount;
    private int fouthLVLCount;

    public GameObject[] textSpace;

    public ChangeLevel changeLvl;
    //public List<GameObject> lvlOne = new List<GameObject>();
    public GameObject lvlOne;
    public List<GameObject> lvlTwo = new List<GameObject>();
    public List<GameObject> lvlThree = new List<GameObject>();
    public List<GameObject> lvlFourth = new List<GameObject>();
    #region Texts
    public Text nameText;
    public Text descriptionText;
    public Text massText;
    public Text gravityText;

    #endregion

    #region Add To Inventory

    private void Update()
    {
        if (changeLvl.changeLVL == true)
        {
            foreach (var item in textSpace)
            {
                item.SetActive(false);
            }

            lvlOne.SetActive(false);
            foreach (var v in lvlTwo)
            {
                
                v.SetActive(false);
            }

            foreach (var v in lvlThree)
            {
                
                v.SetActive(false);
            }
            foreach (var v in lvlFourth)
            {

                v.SetActive(false);
            }
        }
        if (changeLvl.lvl == 1)
        {
            lvlOne.SetActive(true);
            textSpace[0].SetActive(true);
        } 
        
        if (changeLvl.lvl == 2)
        {
            textSpace[1].SetActive(true);
            foreach (var v in lvlTwo)
            {
                v.SetActive(true);
                
            }
        }

        if (changeLvl.lvl == 3)
        {
            textSpace[2].SetActive(true);
            foreach (var v in lvlThree)
            {
                v.SetActive(true);
                
            }
        }

        if (changeLvl.lvl == 4)
        {
            textSpace[3].SetActive(true);
            foreach (var v in lvlFourth)
            {
                v.SetActive(true);
                Debug.Log("Cuarto!!!!");
                
            }
        }


    }
    public void TakeElement(string Elementname)
    {
        //Busqueda de elemento dentro del proyecto 
        Element elementAdd = elementDataBase.GetElement(Elementname);
        playerElements.Add(elementAdd);

        //Puntos y Elementos Contables
        //localCount++;
        points += 10;
        FinalCount++;

        //Spawn in Pos1
        GameObject p = Instantiate(elementAdd.prefab, pos1);

        //Cambio de Layer
        p.layer = 3;
        if (p.transform.childCount >= 1)
        {
            foreach (Transform child in p.transform)
            {
                child.gameObject.layer = 3;
            }
        }
       
        //Agregar En posicion Local a inventario
        if (changeLvl.lvl == 1)
        {
            firstLVLCount++;
            localCount = firstLVLCount;
            
        }
        
        if (changeLvl.lvl == 2)
        {
            secondLVLCount++;
            localCount = secondLVLCount;
            
        }
        
        if (changeLvl.lvl == 3)
        {
            thirdLVLCount++;
            localCount = thirdLVLCount;
            
        }
        
        if (changeLvl.lvl == 4)
        {
            fouthLVLCount++;
            localCount = fouthLVLCount;
            
        }

        p.transform.position += new Vector3(0, -spacing * localCount, 0);
        //p.AddComponent<SphereCollider>();

        //cambio de tamaño Standard
        p.AddComponent<ContentOBJ>().NewScale(inventorySize);        

        #region AddElementsToLists
        //if (changeLvl.lvl == 1)
        //{
        //    lvlOne.Add(p);
        //}

        if (changeLvl.lvl == 2)
        {
            lvlTwo.Add(p);
        }

        if (changeLvl.lvl == 3)
        {
            lvlThree.Add(p);
        }

        if (changeLvl.lvl == 4)
        {
            lvlFourth.Add(p);
        }
        #endregion
    }

    public void ElementInfo(string ElementTitle)
    {        
        

        if (changeLvl.lvl == 3)
        {
            Element elementAdd = elementDataBase.GetElement(ElementTitle);
            Debug.Log("Nombre " + elementAdd.title);
            nameText.text = elementAdd.title;
            descriptionText.text = elementAdd.description;
            massText.text = "Distancia: " + elementAdd.ElementStats["Distancia"].ToString() + " Años Luz ";
            gravityText.text = "Masa: " + elementAdd.ElementStats["Masa"].ToString() + " Masa solar ";
        }
        if (changeLvl.lvl == 1)
        {
            Element elementAdd = elementDataBase.GetElement(ElementTitle);
            Debug.Log("Nombre " + elementAdd.title);
            nameText.text = elementAdd.title;
            descriptionText.text = elementAdd.description;
            massText.text = "Masa: " + elementAdd.ElementStats["Distancia"].ToString() + " Años Luz ";
            gravityText.text = "Gravedad: " + elementAdd.ElementStats["Masa"].ToString() + " Masa solar ";
        }
        if (changeLvl.lvl == 2)
        {
            Element elementAdd = elementDataBase.GetElement(ElementTitle);
            Debug.Log("Nombre " + elementAdd.title);
            nameText.text = elementAdd.title;
            descriptionText.text = elementAdd.description;
            massText.text = "Masa: " + elementAdd.ElementStats["Distancia"].ToString() + " Años Luz ";
            gravityText.text = "Gravedad: " + elementAdd.ElementStats["Masa"].ToString() + " Masa solar ";
        }
        if (changeLvl.lvl == 4)
        {
            Element elementAdd = elementDataBase.GetElement(ElementTitle);
            Debug.Log("Nombre " + elementAdd.title);
            nameText.text = elementAdd.title;
            descriptionText.text = elementAdd.description;
            massText.text = "Masa: " + elementAdd.ElementStats["Distancia"].ToString() + " millones km ";
            gravityText.text = "Gravedad: " + elementAdd.ElementStats["Masa"].ToString() + " x 10^23 kg ";
        }
    }

    #endregion
}
