using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGlitch : MonoBehaviour
{

    void OnMouseDown()
    {


        int random = Random.Range(0, 9);

        if (random >= 8) Destroy(gameObject);
        else
        {


            var script = gameObject.GetComponent<S_GlitchFruit>();
            script.StopGlitching();
            var script3 = gameObject.GetComponent<S_WireframeGlitch>();
            script3.StopGlitching();



        }
    }
}
