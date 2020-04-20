using UnityEngine;

public class S_MeshGlitch : MonoBehaviour
{
    [Tooltip("Glitch intensity")]
    public float glitchIntensity = 0.01f;
    [Tooltip("Maximum distance a vertex can stray from its original point")]
    public float maxGlitchiness = 0.5f;
    [Tooltip("Time delta in seconds to glitch")]
    public float glitchFrequency = .15f;
    public bool glitchOnSpawn = false;

    Mesh mesh;
    Vector3[] vertices;
    Vector3[] verticesOriginalLocation;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        verticesOriginalLocation = mesh.vertices;

        if (glitchOnSpawn == true)
        {
            InvokeRepeating("GlitchFruit", 0, glitchFrequency);
        }
    }

    void Update()
    {

    }

    void MeshGlitch()
    {
        if (gameObject.active == true) { 
                for (var i = 0; i < vertices.Length; i++)
                {
                    Vector3 glitchMovement = new Vector3(Random.Range(glitchIntensity * -1, glitchIntensity), Random.Range(glitchIntensity * -1, glitchIntensity), Random.Range(glitchIntensity * -1, glitchIntensity));
                    vertices[i] = vertices[i] + glitchMovement;
                }

            // assign the local vertices array into the vertices array of the Mesh.
            mesh.vertices = vertices;

            for (var i = 0; i < vertices.Length; i++)
            {
                if (Vector3.Distance(vertices[i], verticesOriginalLocation[i]) > 0.5f)
                {
                    vertices[i] = verticesOriginalLocation[i];
                }
            }

            // assign the local vertices array into the vertices array of the Mesh.
            mesh.vertices = vertices;
        }
    }

    public void StartGlitching()
    {
        InvokeRepeating("MeshGlitch", 0, glitchFrequency);
    }

    public void StopGlitching()
    {
        CancelInvoke("MeshGlitch");
    }
}
