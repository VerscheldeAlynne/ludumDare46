using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
   

    private void OnTriggerStay (Collider other)
    {

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("pickup");
        }
    }

   
}
