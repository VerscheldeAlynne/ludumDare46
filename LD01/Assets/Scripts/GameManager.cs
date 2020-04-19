using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

   public int teller = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        

    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private void FixedUpdate()
    {
        teller++;

        if (teller == Random.Range(0, 100))
        {
            List<GameObject> lijstGameObjects = GetAllObjectsOnlyInScene();
            int random = Random.Range(1, lijstGameObjects.Count);
            GameObject randomObject = lijstGameObjects[random];
            makeGlitch(randomObject);
        }

        if (teller == 100) teller = 0;

    }


    void makeGlitch(GameObject randomObject)
    {

        if (randomObject.GetComponent<S_GlitchFruit>() != null)
        {
            int smallRandom = Random.Range(0, 3);
            switch (smallRandom)
            {
                case 0:
                    var script = randomObject.GetComponent<S_GlitchFruit>();
                    script.StartGlitching();
                    Debug.Log("glitchfruit");
                    break;
                case 1:
                    var script1 = randomObject.GetComponent<S_HologramGlitch>();
                    script1.StartGlitching();
                    Debug.Log("hologramglitch");

                    break;
                case 2:
                    var script2 = randomObject.GetComponent<S_MeshGlitch>();
                    script2.StartGlitching();
                    Debug.Log("meshglitch");

                    break;
                case 3:
                    var script3 = randomObject.GetComponent<S_WireframeGlitch>();
                    script3.StartGlitching();
                    Debug.Log("wireframglitch");

                    break;
            }


        }

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
