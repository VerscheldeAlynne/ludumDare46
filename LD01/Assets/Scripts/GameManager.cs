using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int teller = 0;
    public List<GameObject> lijstGameObjects;
 //   public List<Planten> planten;



    // Start is called before the first frame update
    void Start()
    {//List<GameObject> 
        lijstGameObjects = new List<GameObject>();
        lijstGameObjects.Add(GameObject.Find("Schuur"));
        lijstGameObjects.Add(GameObject.Find("Huis"));
        lijstGameObjects.Add(GameObject.Find("Mesthoop"));
        lijstGameObjects.Add(GameObject.Find("Waterput"));
        lijstGameObjects.Add(GameObject.Find("Veld"));

   /*     planten = new List<Planten>();

        for (int i = 0; i < planten.Count; i++)
        {
            planten[i].transform.gameObject.SetActive(false);
        }
        */

        for (int i = 0; i < lijstGameObjects.Count; i++)
        {
            lijstGameObjects[i].AddComponent<S_GlitchFruit>();
            //lijstGameObjects[i].AddComponent<S_HologramGlitch>();
            //lijstGameObjects[i].AddComponent<S_MeshGlitch>();
            lijstGameObjects[i].AddComponent<S_WireframeGlitch>();


        }



    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private void FixedUpdate()
    {
        teller++;

        if (teller >= 50 && teller == Random.Range(50, 150))
        {

            lijstGameObjects = new List<GameObject>();
            lijstGameObjects.Add(GameObject.Find("Schuur"));
            lijstGameObjects.Add(GameObject.Find("Huis"));
            lijstGameObjects.Add(GameObject.Find("Mesthoop"));
            lijstGameObjects.Add(GameObject.Find("Waterput"));
            lijstGameObjects.Add(GameObject.Find("Veld"));



            //List<GameObject> lijstGameObjects = GetAllObjectsOnlyInScene();
            int random = Random.Range(1, lijstGameObjects.Count);
            GameObject randomObject = lijstGameObjects[random];
            makeGlitch(randomObject);
        }

        if (teller == 150) teller = 50;

    }


    void makeGlitch(GameObject randomObject)
    {

        if (randomObject.GetComponent<S_GlitchFruit>() != null)
        {
            int smallRandom = Random.Range(0, 1);
            switch (smallRandom)
            {
                case 0:
                    var script = randomObject.GetComponent<S_GlitchFruit>();
                    script.StartGlitching();
                    Debug.Log("glitchfruit");
                    break;
                case 1:
                    var script3 = randomObject.GetComponent<S_WireframeGlitch>();
                    script3.StartGlitching();
                    Debug.Log("wireframeglitch");

                    break;
                //case 2:
                //    var script2 = randomObject.GetComponent<S_MeshGlitch>();
                //    script2.StartGlitching();
                //    Debug.Log("meshglitch");

                //    break;
                //case 3:
                //    var script3 = randomObject.GetComponent<S_WireframeGlitch>();
                //    script3.StartGlitching();
                //    Debug.Log("wireframeglitch");

                //    break;
            }
            Debug.Log("Glitch should have happened");
        }
        Debug.Log("makeGlitch called");

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
