using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element 
{
    public int id;
    public string title;
    public string description;
    public GameObject prefab;
    public Dictionary<string, int> ElementStats = new Dictionary<string, int>();

    public Element(int id, string title, string description,Dictionary<string, int> ElementStats)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.prefab = Resources.Load<GameObject>("ElementsPrefabs/" + title);
        this.ElementStats = ElementStats;
    }
    
    public Element(Element element)
    {
        this.id = element.id;
        this.title = element.title;
        this.description = element.description;
        this.prefab = Resources.Load<GameObject>("ElementsPrefabs/" + element.title);
        this.ElementStats = element.ElementStats;
    }
}
