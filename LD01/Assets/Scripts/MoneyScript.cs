using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{

    public int money;
    public TextMesh moneyText;
    public Transform Gem;
    // Start is called before the first frame update
    void Start()
    {
        money = 0;  
        Debug.Log("money= " + money);
        UpdateText();
           
    }

    public int getMoney()
    {
        return money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateText()
    {
        moneyText.text = money.ToString();  
    }

    public void addMoney(int aantal){
        money += aantal;
        AnimateMoney();
        UpdateText();
        //Debug.Log("money= " + money); 
        //playsound
    }

    public void spendMoney(int aantal)
    {
        //if (money - aantal >= 0)
        //{
            money -= aantal;
            UpdateText();
            //playsound
       // }else{
            //play no money sound
        //}
        //Debug.Log("money= " + money); 
    }

    private void AnimateMoney()
    {
       //Do something

    }
}
