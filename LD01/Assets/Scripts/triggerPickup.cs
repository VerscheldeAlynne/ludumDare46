using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerPickup : MonoBehaviour
{

    public Transform tool;
    public Transform destination;

    private void OnTriggerStay (Collider other)
    {
        if (other.tag == "well")
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("emmer");
                tool.transform.position = destination.position;
                tool.transform.parent = GameObject.Find("toolDestination").transform;
                tool.GetComponent<Renderer>().enabled = true;
            }
        }
    }

   
}
