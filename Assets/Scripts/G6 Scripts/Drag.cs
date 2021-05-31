using UnityEngine;

public class Drag : MonoBehaviour
{
    GameObject destiny;

    private float step;
    public bool returning;
    private Vector3 screenPoint;
    private Vector3 offset;
    private void Start()
    {
        step = 400 * gameObject.GetComponent<Rigidbody>().mass;
    }
    private void Update()
    {
        if (returning)
        {
            gameObject.transform.position = transform.position = Vector3.MoveTowards(transform.position, destiny.transform.position, step * Time.deltaTime);
            if (gameObject.transform.position == destiny.transform.position)
            {
                returning = false;
            }
        }
    }
    void OnMouseDown()
    {
        destiny = GameObject.Find("respawn");
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PinR" || other.name =="PinL")
        {
            returning = true;
            destiny = other.gameObject;
        }
        if (other.name == "vacio")
        {
            gameObject.transform.position = GameObject.Find("respawn").transform.position;
        }
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
}

