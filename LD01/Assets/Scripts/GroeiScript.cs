using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroeiScript : MonoBehaviour
{
    public float water;
    public float mest;

    public float verdrooging;
    public Planten[] planten;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        water -= verdrooging * Time.deltaTime;
        mest -= verdrooging * Time.deltaTime;

        //int i=0;
        foreach(Planten plant in planten)
        {
            //plant.groeiSpeed = water + mest;
            
        }

        //Debug.Log(water + mest);

    }

    public void addWater(int i){
        water += i;
    } 

    public void addMest(int i){
        mest += i;
    } 
}
