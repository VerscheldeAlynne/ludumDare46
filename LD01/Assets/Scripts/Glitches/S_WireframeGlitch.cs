using System.Collections;
using UnityEngine;

public class S_WireframeGlitch : MonoBehaviour
{
    //How often should the glitch effect happen (higher value means more frequently)
    public float glitchChance = 0.1f;
    public float glitchIntensity = 0.1f;
    public float glitchThicknessIntensity = 800;
    public float glitchSmoothnessIntensity = 20;
    [Tooltip("Time delta in seconds to glitch")]
    public float glitchFrequency = .15f;
    public bool glitchOnSpawn = false;

    Shader wireframeShader;
    Material wireframeMaterial;
    WaitForSeconds glitchLoopWait = new WaitForSeconds(0.1f);

    Material meshMaterial;

    // Start is called before the first frame update

    void Start()
    {
        wireframeMaterial = new Material(Shader.Find("SuperSystems/Wireframe-Transparent-Culled"));
        //meshMaterial = GetComponent<Renderer>().material;

        //float originalWireThickness = meshMaterial.GetFloat("_WireThickness");
        //float originalWireSmoothness = meshMaterial.GetFloat("_WireSmoothness");

        Debug.Log("originalWireSmoothness");
        //Debug.Log(meshMaterial.GetFloat("_WireSmoothness"));

        if (glitchOnSpawn == true)
        {
            StartGlitching();
        }
    }

    void WireframeGlitch()
    {
        float glitchTest = Random.Range(0f, 1f);

        if (glitchTest <= glitchChance)
        {
            //Do Glitch

            GetComponent<Renderer>().material.SetFloat("_WireThickness", Random.Range(0, glitchThicknessIntensity));
            GetComponent<Renderer>().material.SetFloat("_WireSmoothness", Random.Range(0, glitchSmoothnessIntensity));
        }

        //meshMaterial.SetFloat("_WireThickness", originalWireThickness);
        //meshMaterial.SetFloat("_WireSmoothness", originalWireSmoothness);
    }

    public void StartGlitching()
    {
        //for (int i = 0; i < gameObject.GetComponent<Renderer>().materials.Length; i++)
        //{
        //    gameObject.GetComponent<Renderer>().materials[i] = wireframeMaterial;
        //}
        gameObject.GetComponent<Renderer>().material = wireframeMaterial;
        InvokeRepeating("WireframeGlitch", 0, glitchFrequency);
    }
}