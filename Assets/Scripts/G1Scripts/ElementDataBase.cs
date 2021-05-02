using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementDataBase : MonoBehaviour
{
    public List<Element> elements = new List<Element>();

    private void Awake()
    {
        BuildDataBase();
    }

    public Element GetElement(int id)
    {
        return elements.Find(element => element.id == id); 
    }public Element GetElement(string elementName)
    {
        return elements.Find(element => element.title == elementName); 
    }

    void BuildDataBase()
    {
        elements =  new List<Element>() {
                    new Element(0, "Tierra", "Planeta en el que vivimos. ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 5972  },
                        { "Gravedad", 98}
                    }),

                    new Element(1, "Marte", "Planeta Rojo. ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 12 },
                        { "Gravedad", 4}
                    }),

                    new Element(2, "Saturno", "Planeta con espiral. ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 100 },
                        { "Gravedad", 10}
                    }),

                    new Element(3, "Jupiter", "Planeta mas grande de la galaxia. ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 150 },
                        { "Gravedad", 28}
                    }),

                    new Element(4, "Venus", "Planeta de la via Lactea ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 150 },
                        { "Gravedad", 9}
                    })

            };
    }

}
