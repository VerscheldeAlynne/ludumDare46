using System.Collections;
using UnityEngine;

public class S_WireframeGlitch : MonoBehaviour
{
    //How often should the glitch effect happen (higher value means more frequently)
    public float glitchChance = 0.1f;
    public float glitchIntensity = 0.1f;
    public float glitchThicknessIntensity = 800;
    public float glitchSmoothnessIntensity = 20;


    Material wireframeMaterial;
    WaitForSeconds glitchLoopWait = new WaitForSeconds(0.1f);

    void Awake()
    {
        wireframeMaterial = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            float glitchTest = Random.Range(0f, 1f);

            if (glitchTest <= glitchChance)
            {
                //Do Glitch
                float originalWireThickness = wireframeMaterial.GetFloat("_WireThickness");
                float originalWireSmoothness = wireframeMaterial.GetFloat("_WireSmoothness");
                wireframeMaterial.SetFloat("_WireThickness", Random.Range(0, glitchThicknessIntensity));
                wireframeMaterial.SetFloat("_WireSmoothness", Random.Range(0, glitchSmoothnessIntensity));
                yield return new WaitForSeconds(Random.Range(0.05f, glitchIntensity));
                wireframeMaterial.SetFloat("_WireThickness", originalWireThickness);
                wireframeMaterial.SetFloat("_WireSmoothness", originalWireSmoothness);
            }

            yield return glitchLoopWait;
        }
    }
}