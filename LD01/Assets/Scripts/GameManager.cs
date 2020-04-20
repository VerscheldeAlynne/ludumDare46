using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int teller = 0;
    public AudioClip crashSound;
    public AudioClip startGlitchSound;
    public AudioClip fixGlitchSound;
    public List<GameObject> lijstGameObjects;

    int tellerMax = 500;
    int randomMax = 550;
    int clickteller = 0;
    bool crashSoundPlayed = false;
    //   public List<Planten> planten;

    MoneyScript money;

    // Start is called before the first frame update
    void Start()
    {
        //List<GameObject> 
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

        if (FindObjectsOfType<MoneyScript>().Length != 0)
        {
            money = FindObjectsOfType<MoneyScript>()[0];
        }

    }

    void Update()
    {
        
        if (money.getMoney() <= 0 && clickteller >= 2)
        {
            PlayCrashSound();
            Destroy(GameObject.Find("LevelMetTriggers"));
        }
        
        if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast (ray, out hit)){
                GameObject clickedObject = hit.collider.transform.gameObject;
                if (clickedObject.GetComponent<S_GlitchFruit>() != null)
                {
                    Debug.Log ("clicked glitchable object");
                    var script = clickedObject.GetComponent<S_GlitchFruit>();
                    
                    //money.spendMoney (5); gebeurt in het glitchscript

                    ////////
                    clickteller++;

                    if (script.glitching)
                    {
                        script.StopGlitching();
                        var script2 = clickedObject.GetComponent<S_WireframeGlitch>();
                        script2.StopGlitching();

                        PlayGlitchFixSound();
                        money.spendMoney(3);
                    }

                    /*int random = Random.Range(0, 9);

                    //money.spendMoney(++random);

                    if (random >= 8) Destroy(clickedObject);
                    else
                    {
                        var script = clickedObject.GetComponent<S_GlitchFruit>();
                        script.StopGlitching();
                        var script3 = clickedObject.GetComponent<S_WireframeGlitch>();
                        script3.StopGlitching();

                        GetComponent<AudioSource>().Play();
                    }*/
                }


            }
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private void FixedUpdate()
    {
       teller++;

        if (teller >= tellerMax && teller == Random.Range(tellerMax, randomMax))
        { /*
            lijstGameObjects = new List<GameObject>();// hadden we deze lijst al niet in de start functie? 
            lijstGameObjects.Add(GameObject.Find("Schuur"));
            lijstGameObjects.Add(GameObject.Find("Huis"));
            lijstGameObjects.Add(GameObject.Find("Mesthoop"));
            lijstGameObjects.Add(GameObject.Find("Waterput"));
            lijstGameObjects.Add(GameObject.Find("Veld"));
            lijstGameObjects.Add(GameObject.Find("Bomen_Berk"));
            lijstGameObjects.Add(GameObject.Find("Bomen_Den"));
            lijstGameObjects.Add(GameObject.Find("Bomen_Eik"));
            lijstGameObjects.Add(GameObject.Find("Bomen_Spar"));
            */

            //List<GameObject> lijstGameObjects = GetAllObjectsOnlyInScene();
            int random = Random.Range(1, lijstGameObjects.Count);
            GameObject randomObject = lijstGameObjects[random];
            if (randomObject != null)
            {
                makeGlitch(randomObject);
            }
        }

        if (teller >= randomMax) teller = tellerMax;

        if (money.getMoney() < 0 )
        {
            PlayCrashSound();
            Destroy(GameObject.Find("LevelMetTriggers"));

        }
    }
/*
    void OnMouseDown()
    {
       
        clickteller++;

        int random = Random.Range(0, 9);

        money.spendMoney(++random);

        if (random >= 8) Destroy(gameObject);
        else
        {
            var script = gameObject.GetComponent<S_GlitchFruit>();
            script.StopGlitching();
            var script3 = gameObject.GetComponent<S_WireframeGlitch>();
            script3.StopGlitching();

            GetComponent<AudioSource>().Play();
        }

        if (money.getMoney() <= 0 && clickteller >= 2)
        {
            PlayCrashSound();
            Destroy(GameObject.Find("LevelMetTriggers"));
        }
    }
    */

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
            PlayStartGlitchSound();
        }
        Debug.Log("makeGlitch called");
    }

    void PlayCrashSound()
    {
        if (!GetComponent<AudioSource>().isPlaying && !crashSoundPlayed)
        { 
            GetComponent<AudioSource>().clip = crashSound;
            GetComponent<AudioSource>().Play();
            crashSoundPlayed = true;
        }
    }

    void PlayStartGlitchSound()
    {
        GetComponent<AudioSource>().clip = startGlitchSound;
        GetComponent<AudioSource>().Play();
    }

    void PlayGlitchFixSound()
    {
        GetComponent<AudioSource>().clip = fixGlitchSound;
        GetComponent<AudioSource>().Play();
    }

   /* List<GameObject> GetAllObjectsOnlyInScene()
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                objectsInScene.Add(go);
        }

        return objectsInScene;
    }
    */
}
