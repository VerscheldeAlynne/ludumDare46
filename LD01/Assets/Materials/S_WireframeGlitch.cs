using System.Collections;
using UnityEngine;

public class S_WireframeGlitch : MonoBehaviour
{
    //How often should the glitch effect happen (higher value means more frequently)
    public float glitchChance = 0.1f;

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
                wireframeMaterial.SetFloat("_WireThickness", Random.Range(0, 800));
                wireframeMaterial.SetFloat("_WireSmoothness", Random.Range(0, 20));
                yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
                wireframeMaterial.SetFloat("_WireThickness", originalWireThickness);
                wireframeMaterial.SetFloat("_WireSmoothness", originalWireSmoothness);
            }

            yield return glitchLoopWait;
        }
    }
}