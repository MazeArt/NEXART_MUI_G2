using UnityEngine;


public class Drag : MonoBehaviour
{
    GameObject origin;
    RaycastHit hit;

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
            gameObject.transform.position = transform.position = Vector3.MoveTowards(transform.position, origin.transform.position, step * Time.deltaTime);
            if (gameObject.transform.position == origin.transform.position)
            {
                returning = false;
            }
        }

    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }
    private void OnTriggerEnter(Collider other)
    {
        //    returning = true;
        //    origin = other.gameObject;
        if (other.name == "vacio")
        {
            gameObject.transform.position = new Vector3(0, 3, -2);
        }
    }
    void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        ray.origin = gameObject.transform.position;
        Debug.DrawRay(ray.origin, ray.direction * 8000, Color.green);


            if (Physics.Raycast(ray, out hit) == true && hit.collider.name != null)
            {
                origin = hit.collider.gameObject;
                Debug.Log(hit.collider.name);
            }

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }
    void OnMouseUp()
    {
       returning = true;
    }
}

