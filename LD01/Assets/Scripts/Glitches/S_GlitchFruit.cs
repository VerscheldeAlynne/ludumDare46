using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GlitchFruit : MonoBehaviour
{

    [Tooltip("Maximum distance a vertex can stray from its original point")]
    public float glitchDistance = 1;
    [Tooltip("Time delta in seconds to glitch")]
    public float glitchFrequency = 1;
    public float glitchChance = 0.5f;

    public GameObject meshRed;
    public GameObject meshBlue;
    public Material red;
    public Material blue;


    Mesh mesh;

        // Start is called before the first frame update
    void Start()
    {
        meshRed.GetComponents<MeshRenderer>()[0].enabled = false;
        meshBlue.GetComponents<MeshRenderer>()[0].enabled = false;
        InvokeRepeating("GlitchFruit", 0, glitchFrequency);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GlitchFruit()
    {
        float glitchTest = Random.Range(0f, 1f);

        if (glitchTest <= glitchChance)
        {
            gameObject.GetComponents<MeshRenderer>()[0].enabled = false;
            meshRed.GetComponents<MeshRenderer>()[0].enabled = true;
            meshBlue.GetComponents<MeshRenderer>()[0].enabled = true;

            Vector3 newLocationMeshRed = new Vector3(Random.Range(glitchDistance * -1, glitchDistance), Random.Range(glitchDistance * -1, glitchDistance), Random.Range(glitchDistance * -1, glitchDistance));
            Vector3 newLocationMeshBlue = new Vector3(Random.Range(glitchDistance * -1, glitchDistance), Random.Range(glitchDistance * -1, glitchDistance), Random.Range(glitchDistance * -1, glitchDistance));
            meshRed.transform.localPosition = (newLocationMeshRed);
            meshBlue.transform.localPosition = (newLocationMeshBlue);
        }
        else
        {
            gameObject.GetComponents<MeshRenderer>()[0].enabled = true;
            meshRed.GetComponents<MeshRenderer>()[0].enabled = false;
            meshBlue.GetComponents<MeshRenderer>()[0].enabled = false;

        }
    }
}
