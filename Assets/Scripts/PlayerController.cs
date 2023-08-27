using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition2 = getNewPosition();

        if (!newPosition2.Equals(this.transform.position))
        {
            transform.Translate(newPosition2);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Vector3 newPosition2 = getNewPosition();
            transform.Translate(new Vector3(newPosition2.x * -1.5f, newPosition2.y * -1.5f, newPosition2.z));
        }
    }

    private Vector3 getNewPosition()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return new Vector3(-1 * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            return new Vector3(+1 * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            return new Vector3(0, 1 * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            return new Vector3(0, -1 * Time.deltaTime, 0);
        }
        else
        {
            return this.transform.position; 
        }
    }
}
