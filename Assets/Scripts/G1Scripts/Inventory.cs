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
    private int localCount;
    public float spacing;

    #region Texts
    public Text nameText;
    public Text descriptionText;
    public Text massText;
    public Text gravityText;

    #endregion

    private void Update()
    {
        if (localCount == 4)
        {
            Debug.Log("Win");
        }
    }

    public void TakeElement(int id)
    {
        Element elementAdd = elementDataBase.GetElement(id);
        playerElements.Add(elementAdd);
        localCount++;
        GameObject p = Instantiate(elementAdd.prefab, pos1);
        p.transform.localScale = new Vector3(planetSize, planetSize, planetSize);
        p.transform.position += new Vector3(0, -spacing * localCount, 0);
        Debug.Log("Elemento agregado " + elementAdd.title);               
        
    }

    public void TakeElement(string Elementname)
    {
        Element elementAdd = elementDataBase.GetElement(Elementname);
        playerElements.Add(elementAdd);
        localCount++;
        GameObject p = Instantiate(elementAdd.prefab, pos1);
        p.transform.localScale = new Vector3(planetSize, planetSize, planetSize);
        p.transform.position += new Vector3(0, -spacing * localCount, 0);
        p.AddComponent<SphereCollider>();
        Debug.Log("Elemento agregado " + elementAdd.title);
        Debug.Log("Stats Masa " + elementAdd.ElementStats["Masa"]);
        Debug.Log("Stats Gravedad " + elementAdd.ElementStats["Gravedad"]);
        Debug.Log("Descripcion " + elementAdd.description);
        

    }
    public void ElementInfo(string ElementTitle)
    {
        Element elementAdd = elementDataBase.GetElement(ElementTitle);        
        Debug.Log("Nombre " + elementAdd.title);
        nameText.text = elementAdd.title;
        descriptionText.text = elementAdd.description;        
        massText.text = "Masa: " + elementAdd.ElementStats["Masa"].ToString();        
        gravityText.text =  "Gravidedad: " +  elementAdd.ElementStats["Gravedad"].ToString() + "m/s2";

    }

    public Element CheckForItem(int id)
    {
        return playerElements.Find(element => element.id == id);
    }
}
