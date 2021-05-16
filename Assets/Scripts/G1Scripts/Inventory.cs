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
    public int points;
    public float spacing;

    public ChangeLevel changeLvl;
    public List<GameObject> lvlOne = new List<GameObject>();
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
            foreach (var v in lvlOne)
            {
                v.SetActive(false);
            }
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
            foreach (var v in lvlOne)
            {
                v.SetActive(true);
            }            
        } 
        
        if (changeLvl.lvl == 2)
        {
            foreach (var v in lvlTwo)
            {
                v.SetActive(true);
            }
        }

        if (changeLvl.lvl == 3)
        {
            foreach (var v in lvlThree)
            {
                v.SetActive(true);
            }
        }

        if (changeLvl.lvl == 4)
        {
            foreach (var v in lvlFourth)
            {
                v.SetActive(true);
            }
        }


    }
    public void TakeElement(string Elementname)
    {
        Element elementAdd = elementDataBase.GetElement(Elementname);
        playerElements.Add(elementAdd);
        localCount++;
        points += 10;
        GameObject p = Instantiate(elementAdd.prefab, pos1);
        p.layer = 3;
        p.transform.localScale = new Vector3(planetSize, planetSize, planetSize);
        p.transform.position += new Vector3(0, -spacing * localCount, 0);
        p.AddComponent<SphereCollider>();        

        #region AddElementsToLists
        if (changeLvl.lvl == 1)
        {
            lvlOne.Add(p);
        }

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
        Element elementAdd = elementDataBase.GetElement(ElementTitle);        
        Debug.Log("Nombre " + elementAdd.title);
        nameText.text = elementAdd.title;
        descriptionText.text = elementAdd.description;        
        massText.text = "Masa: " + elementAdd.ElementStats["Masa"].ToString() + " x 10^23 kg ";        
        gravityText.text =  "Gravedad: " +  elementAdd.ElementStats["Gravedad"].ToString() + " m/s2";
    }

    #endregion
}
