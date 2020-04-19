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

    Material wireframeMaterial;
    WaitForSeconds glitchLoopWait = new WaitForSeconds(0.1f);


    void Start()
    {
        wireframeMaterial = GetComponent<Renderer>().material;

        if (glitchOnSpawn == true)
        {
            InvokeRepeating("GlitchFruit", 0, glitchFrequency);
        }
    }

    // Start is called before the first frame update
    void WireframeGlitch()
    {
        float glitchTest = Random.Range(0f, 1f);

        if (glitchTest <= glitchChance)
        {
            //Do Glitch
            float originalWireThickness = wireframeMaterial.GetFloat("_WireThickness");
            float originalWireSmoothness = wireframeMaterial.GetFloat("_WireSmoothness");

            wireframeMaterial.SetFloat("_WireThickness", Random.Range(0, glitchThicknessIntensity));
            wireframeMaterial.SetFloat("_WireSmoothness", Random.Range(0, glitchSmoothnessIntensity));


            wireframeMaterial.SetFloat("_WireThickness", originalWireThickness);
            wireframeMaterial.SetFloat("_WireSmoothness", originalWireSmoothness);
        }
    }

   public  void StartGlitching()
    {
        InvokeRepeating("MeshGlitch", 0, glitchFrequency);
    }
}