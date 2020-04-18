using UnityEngine;

public class S_MeshGlitch : MonoBehaviour
{
    public float glitchIntensity = 0.01f;

    Mesh mesh;
    Vector3[] vertices;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
    }

    void Update()
    {
        Vector3[] vertexOriginalLocation = vertices;

        for (var i = 0; i < vertices.Length; i++)
        {
            Vector3 glitchMovement = new Vector3(Random.Range(glitchIntensity*-1, glitchIntensity), Random.Range(glitchIntensity * -1, glitchIntensity), Random.Range(glitchIntensity * -1, glitchIntensity));
            vertices[i] = vertices[i] + glitchMovement;
        }

        // assign the local vertices array into the vertices array of the Mesh.
        mesh.vertices = vertices;
        mesh.RecalculateBounds();

        for (var i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertexOriginalLocation[i];
        }

        // assign the local vertices array into the vertices array of the Mesh.
        mesh.vertices = vertices;
        mesh.RecalculateBounds();

    }
}
