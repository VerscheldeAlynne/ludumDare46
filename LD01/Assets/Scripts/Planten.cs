using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planten : MonoBehaviour
{

    public int groeiSpeed;
    public List<int> timings;
    public List<GameObject> planten;
    private int plantTimer;
    public bool growing;

    //List<GameObject> planten;


    // Start is called before the first frame update
    void Start()
    {
        //planten = new List<GameObject>();
        //timings = new List<int>();
        //foreach (Transform child in transform) planten.Add(child.gameObject);
        Quaternion rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
        transform.rotation = rotation;
        growing = true;
        plantTimer = timings[0]; //toon eerste plantje
        //Debug.Log("antal planten " + planten.Count);
        //Debug.Log("antal timings " + timings.Count);
        plantTimer = Random.Range(timings[0], timings[1]);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (growing)
        { 
            plantTimer += groeiSpeed;

            if (plantTimer == timings[0])
            {
                ToonNiuewePlant(0);
            }else if (plantTimer == timings[1])
            {
                ToonNiuewePlant(1);
            }else if (plantTimer == timings[2])
            {
                ToonNiuewePlant(2);
            }else if (plantTimer == timings[3])
            {
                ToonNiuewePlant(3);
            }else if (plantTimer == timings[4])
            {
                Sterf();
            }



        }
        
    }

    void ToonNiuewePlant (int plantNr)
    {
        //if(planten[0].transform.gameObject.activeSelf == true){
            planten[plantNr].transform.gameObject.SetActive(false);
            planten[plantNr+1].transform.gameObject.SetActive(true);
            //gameObject.transform.GetChild(0).gameObject.SetActive(false);
            //gameObject.transform.GetChild(1).gameObject.SetActive(true);
        //}
        //planten[plantNr+1].transform.gameObject.SetActive(true);
    }

    public void Harvest()
    {
        //TODO Get MONEY!!!  invoegen in gamamanger of zo iets
        //play sound
        //toon "glitch Ruby"
        plantTimer = 0; // 

    }

    public void Sterf()
    {
        planten[4].transform.gameObject.SetActive(false);
        planten[0].transform.gameObject.SetActive(true);
        plantTimer = 0; // start timer van 0, eerste timing gedeelte is de stervende plant

    }
}
