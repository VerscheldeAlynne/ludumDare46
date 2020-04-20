using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemHover : MonoBehaviour
{
    float maxTransformDelta;
    public float originalZ;

    // Start is called before the first frame update
    void Start()
    {
        maxTransformDelta = 25;
        originalZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        transform.Rotate(new Vector3(0, 0, 1));

        float deltaHeight = (Mathf.Sin(Time.fixedTime + Time.deltaTime) - Mathf.Sin(Time.fixedTime)) / 8;

        transform.localPosition += new Vector3(0, 0, deltaHeight);

        //if (transform.localPosition.z >= (originalZ + maxTransformDelta))
        //{
        //    transform.localPosition = transform.localPosition + new Vector3(0, 0, 2f);
        //}
        //else if (transform.localPosition.z <= (originalZ - maxTransformDelta))
        //{
        //    transform.localPosition = transform.localPosition - new Vector3(0, 0, 1f);
        //}
    }
}
