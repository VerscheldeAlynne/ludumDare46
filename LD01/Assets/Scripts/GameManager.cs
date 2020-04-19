using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

   public int teller = 0;
   public GameObject[] gltichObjects;
   
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start GLitch");
        makeGlitch(gltichObjects[0]);

    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private void FixedUpdate()
    {
        teller++;

        if (teller == Random.Range(0, 100))
        {
            /*
            List<GameObject> lijstGameObjects = GetAllObjectsOnlyInScene();
            int random = Random.Range(1, lijstGameObjects.Count);
            GameObject randomObject = lijstGameObjects[random];
            makeGlitch(randomObject);
            */
            makeGlitch(gltichObjects[0]);
        }

        if (teller == 100) teller = 0;

    }


    void makeGlitch(GameObject randomObject)
    {
        Debug.Log("Start GLitch");

       // if (randomObject.GetComponent<S_GlitchFruit>() != null)
        //{
            int smallRandom = Random.Range(0, 1);
            Debug.Log(smallRandom);
            
            switch (smallRandom)
            {
                
                case 0:
                    var script1 = randomObject.GetComponent<S_WireframeGlitch>();
                    script1.StartGlitching();
                    Debug.Log("meshglitch");
                    break;
                case 1:
                    var script2 = randomObject.GetComponent<S_HologramGlitch>();
                    script2.StartGlitching();
                    Debug.Log("hologramglitch");
                    break;
                case 2:
                    var script3 = randomObject.GetComponent<S_GlitchFruit>();
                    script3.StartGlitching();
                    Debug.Log("glitchfruit");
                    break;
                default:
                    break;
            }


       // }

    }

    List<GameObject> GetAllObjectsOnlyInScene()
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                objectsInScene.Add(go);
        }

        return objectsInScene;
    }

}
