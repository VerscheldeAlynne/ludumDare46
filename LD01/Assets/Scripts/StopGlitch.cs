using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGlitch : MonoBehaviour
{


    public MoneyScript money;

    private void Start()
    {
        if (FindObjectsOfType<MoneyScript>().Length != 0)
        {
            money = FindObjectsOfType<MoneyScript>()[0];
        }
    }

    void OnMouseDown()
    {

       
       

        int random = Random.Range(0, 9);


        money.spendMoney(random+2);



        if (random >= 8) Destroy(gameObject);
        else
        {


            var script = gameObject.GetComponent<S_GlitchFruit>();
            script.StopGlitching();
            var script3 = gameObject.GetComponent<S_WireframeGlitch>();
            script3.StopGlitching();



        }

        if (money.getMoney()<=0)
        {
            Destroy(GameObject.Find("LevelMetTriggers"));

        }
    }
}
