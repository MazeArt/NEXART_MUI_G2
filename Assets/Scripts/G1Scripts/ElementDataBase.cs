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

                    new Element(7, "NGC 1281", "Absorbe todas las perticulas a su alrededor  ",
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
                    ,

                    new Element(9, "Via Lactea", "Galaxia espiral, contiene el Sistema Solar  ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    })
                    ,

                    new Element(10, "NGC 1803", "Galaxia espiral, en constelación de Pictor  ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(11, "NGC 2336", "Galaxia espiral, en constelación Camelopardalis  ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(12, "Messier 51A", "Galaxia espiral, primera clasificada como espiral  ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(13, "Andromeda", "Objeto visible a simple vista más lejano de la Tierra  ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(14, "ESO 33-4", "La galaxia del Triángulo  ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(15, "IC 4710", "A unos 34 millones de años luz de distancia  ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(16, "Messier 32", "Galaxia elíptica de la galaxia de Andrómeda  ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(17, "NGC 524", "Galaxia lenticular en la constelación de Piscis  ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(18, "Sirius", "Estrella enana blanca ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(19, "Alnitak", "En Cinturon de Orion, parte de las tres Marías ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(20, "Arturo", "Tercera estrella más brillante del cielo nocturno ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(21, "PSR J0437-4715 ", "El púlsar gira alrededor de su eje 173,7 por seg",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(22, "51 pegasi b", "Dimidio​, planeta extrasolar, como júpiter caliente ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(23, "Kelt 9b", "Exoplaneta gigante de gas más caliente conocido ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(24, "Kepler - 7b", "Su temperatura es más caliente que la lava fundida ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(25, "Sagittarius A", "Compacta y brillante en el centro de la Vía Láctea ",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(26, "TON 618", "Agujero negro supermasivo más grande descubierto",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(27, "Messier 51A", "LLamada la Galaxia Remolino",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(28, "Sol", "Estrella de tipo-G, se encuentra en el centro del sistema solar",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    }),

                    new Element(29, "Behemoth", "Agujero negro, centrico rodeado de estrellas",
                    new Dictionary<string, int>
                    {
                        { "Masa", 1/3 },
                        { "Gravedad", 1/4 }
                    })

            };
    }

}
