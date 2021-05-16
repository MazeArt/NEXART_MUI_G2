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
                        { "Masa", 6  },
                        { "Gravedad", 10}
                    }),

                    new Element(1, "Marte", "Planeta Rojo. ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 6 },
                        { "Gravedad", 4}
                    }),

                    new Element(2, "Saturno", "Planeta con espiral. ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 6 },
                        { "Gravedad", 10}
                    }),

                    new Element(3, "Jupiter", "Planeta mas grande del sistema Solar. ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 2 },
                        { "Gravedad", 25}
                    }),

                    new Element(4, "Venus", "No posee satelites naturales ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 5 },
                        { "Gravedad", 9}
                    }),

                    new Element(5, "Mercurio", "El planeta más pequeño  ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 3 },
                        { "Gravedad", 4}
                    }),

                    new Element(6, "Urano", "Séptimo planeta y tecero más grande  ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 3 },
                        { "Gravedad", 4}
                    }),

                    new Element(7, "Agujero Negro", "Absorbe todas las perticulas a su alrededor  ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 0 },
                        { "Gravedad", 0 }
                    }),

                    new Element(8, "Planeta Gaseoso", "Compuesto por gases y casi nada de masa  ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    })

            };
    }

}
