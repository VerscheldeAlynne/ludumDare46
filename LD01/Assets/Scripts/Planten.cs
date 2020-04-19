using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planten : MonoBehaviour
{
    public MoneyScript moneyScript;

    public float groeiSpeed;
    public bool harvestAble;
    public List<int> timings;
    public List<GameObject> planten;
    private float plantTimer;
    private bool growing;
    private int change;

    //List<GameObject> planten;


    // Start is called before the first frame update
    void Start()
    {
        //moneyScript =  (MoneyScript) GameObject.FindObjectOfType(typeof(MoneyScript));
        //planten = new List<GameObject>();
        //timings = new List<int>();
        //foreach (Transform child in transform) planten.Add(child.gameObject);

        //hide alle planten bij de start
        for (int i = 0; i < planten.Count; i++)
        {
            planten[i].transform.gameObject.SetActive(false);
        }

        Quaternion rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
        transform.rotation = rotation;
        growing = true;
        change = 0;
        harvestAble = false;
        plantTimer = timings[0]; //toon eerste plantje
        //Debug.Log("antal planten " + planten.Count);
        //Debug.Log("antal timings " + timings.Count);
        plantTimer = Random.Range(timings[0], timings[3]);
        
    }

    // Update is called once per frame
    void Update()
    {
      

        if (growing)
        {           
            plantTimer += groeiSpeed * Time.deltaTime;
            //Debug.Log ("Timer " + plantTimer);

            if (plantTimer > timings[0] && change == 0)
            {
                ToonNiuewePlant(0);
            }if (plantTimer>  timings[1] && change == 1)
            {
                ToonNiuewePlant(1);
            }if (plantTimer> timings[2] && change == 2)
            {
                ToonNiuewePlant(2);
            }if (plantTimer> timings[3] && change == 3)
            {
                ToonNiuewePlant(3);
                harvestAble = true;
                //Harvest();//for debugging moet nog checekn met boer collider
            }
        }
        
    }

    void ToonNiuewePlant (int plantNr)
    {
            planten[plantNr].transform.gameObject.SetActive(false);
            planten[plantNr+1].transform.gameObject.SetActive(true);
            change ++;
        //if(planten[0].transform.gameObject.activeSelf == true){
            
            //gameObject.transform.GetChild(0).gameObject.SetActive(false);
            //gameObject.transform.GetChild(1).gameObject.SetActive(true);
        //}
        //planten[plantNr+1].transform.gameObject.SetActive(true);
    }

    public void Harvest()
    {
        moneyScript.addMoney(1);//TODO Get MONEY!!!  invoegen in gamamanger of zo iets
        harvestAble = false;
        planten[4].transform.gameObject.SetActive(false);
        //planten[0].transform.gameObject.SetActive(true);
        //play sound
        //toon "glitch Ruby"
         // 
        change = 0;
        plantTimer = 0;
        growing = false;
    }

    /*public void Sterf()
    {
        planten[4].transform.gameObject.SetActive(false);
        planten[0].transform.gameObject.SetActive(true);
        plantTimer = 0; // start timer van 0, eerste timing gedeelte is de stervende plant
        change = 0;

    }*/

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Player")
        {
            if (plantTimer< timings[0]){
                giveWater();
                
            }
            
            if(harvestAble)
            {
                Harvest();
                Debug.Log (this);
            }    
        }

        
    }

    private void giveWater()
    {   
        growing = true;
        planten[0].transform.gameObject.SetActive(true);
    }
}
