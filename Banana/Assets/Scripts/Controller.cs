using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (horizontal == 0 && vertical == 0) {

        } else {
            transform.position = new Vector3(
                transform.position.x + horizontal / 100,
                transform.position.y,
                transform.position.z + vertical / 100
            );
        }
    }
}
