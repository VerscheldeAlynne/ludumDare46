﻿using UnityEngine;

public class S_MeshGlitch : MonoBehaviour
{
    public float glitchIntensity = 0.01f;

    Mesh mesh;
    Vector3[] vertices;
    Vector3[] verticesOriginalLocation;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        verticesOriginalLocation = mesh.vertices;

    }

    void Update()
    {
        
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
            if (Vector3.Distance(vertices[i], verticesOriginalLocation[i]) > 0.5f)
            {
                vertices[i] = verticesOriginalLocation[i];
            }
        }

        // assign the local vertices array into the vertices array of the Mesh.
        mesh.vertices = vertices;
        mesh.RecalculateBounds();

    }
}