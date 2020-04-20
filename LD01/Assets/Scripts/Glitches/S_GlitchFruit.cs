using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GlitchFruit : MonoBehaviour
{

    [Tooltip("Maximum distance a vertex can stray from its original point")]
    public float glitchDistance = 0.2f;
    [Tooltip("Time delta in seconds to attempt glitch")]
    public float glitchFrequency = 0.5f;
    [Tooltip("Chence to glitch on chance")]
    public float glitchChance = 0.5f;
    [Tooltip("Start glitching on spawn")]
    public bool glitchOnSpawn = false;

    public GameObject meshRed;
    public GameObject meshBlue;
    public Material red;
    public Material blue;

    Material wireframeMaterialRed;
    Material wireframeMaterialBlue;

    MoneyScript moneyScript;

    Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectsOfType<MoneyScript>().Length != 0)
        {
            moneyScript = FindObjectsOfType<MoneyScript>()[0];
        }

        Color red = new Color(1f, 0, 0);
        Color blue = new Color(0, 0, 1);

        wireframeMaterialRed = new Material(Shader.Find("FX/Hologram Shader"));
        wireframeMaterialBlue = new Material(Shader.Find("FX/Hologram Shader"));

        meshRed = new GameObject();
        meshRed.transform.localPosition = gameObject.transform.localPosition;
        meshRed.transform.localRotation = gameObject.transform.localRotation;
        meshRed.transform.localScale    = gameObject.transform.localScale;
        meshRed.AddComponent<MeshFilter>();
        meshRed.AddComponent<MeshRenderer>();
        meshRed.GetComponent<MeshFilter>().mesh = gameObject.GetComponent<MeshFilter>().mesh;
        meshRed.GetComponent<Renderer>().material = wireframeMaterialRed;
        meshRed.GetComponent<Renderer>().material.SetColor("_Color", red);
        meshRed.GetComponent<Renderer>().material.SetFloat("_GlowIntensity", 0.9f);

        meshBlue = new GameObject();
        meshBlue.transform.localPosition = gameObject.transform.localPosition;
        meshBlue.transform.localRotation = gameObject.transform.localRotation;
        meshBlue.transform.localScale    = gameObject.transform.localScale;
        meshBlue.AddComponent<MeshFilter>();
        meshBlue.AddComponent<MeshRenderer>();
        meshBlue.GetComponent<MeshFilter>().mesh = gameObject.GetComponent<MeshFilter>().mesh;
        meshBlue.GetComponent<Renderer>().material = wireframeMaterialBlue;
        meshBlue.GetComponent<Renderer>().material.SetColor("_Color", blue);
        meshBlue.GetComponent<Renderer>().material.SetFloat("_GlowIntensity", 0.9f);

        meshRed.GetComponents<MeshRenderer>()[0].enabled = false;
        meshBlue.GetComponents<MeshRenderer>()[0].enabled = false;

        if (glitchOnSpawn == true)
        {
            InvokeRepeating("GlitchFruit", 0, glitchFrequency);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void GlitchFruit()
    {
        float glitchTest = Random.Range(0f, 1f);

        if (glitchTest <= glitchChance)
        {
            gameObject.GetComponents<MeshRenderer>()[0].enabled = false;
            meshRed.GetComponents<MeshRenderer>()[0].enabled = true;
            meshBlue.GetComponents<MeshRenderer>()[0].enabled = true;

            Vector3 newLocationMeshRed = new Vector3(Random.Range(glitchDistance * -1, glitchDistance), Random.Range(glitchDistance * -1, glitchDistance), Random.Range(glitchDistance * -1, glitchDistance));
            Vector3 newLocationMeshBlue = new Vector3(Random.Range(glitchDistance * -1, glitchDistance), Random.Range(glitchDistance * -1, glitchDistance), Random.Range(glitchDistance * -1, glitchDistance));
            meshRed.transform.localPosition += (newLocationMeshRed);
            meshBlue.transform.localPosition += (newLocationMeshBlue);
        }
        else
        {
            gameObject.GetComponents<MeshRenderer>()[0].enabled = true;
            meshRed.GetComponents<MeshRenderer>()[0].enabled = false;
            meshBlue.GetComponents<MeshRenderer>()[0].enabled = false;
            meshRed.transform.localPosition = (gameObject.transform.localPosition);
            meshBlue.transform.localPosition = (gameObject.transform.localPosition);

        }
    }

    public void StartGlitching()
    {
        InvokeRepeating("GlitchFruit", 0, glitchFrequency);
        InvokeRepeating("TakeMoneyAway", 5, 5);
    }

    public void TakeMoneyAway()
    {
        moneyScript.spendMoney(1);
    }

    public void StopGlitching()
    {
        gameObject.GetComponents<MeshRenderer>()[0].enabled = true;
        meshRed.GetComponents<MeshRenderer>()[0].enabled = false;
        meshBlue.GetComponents<MeshRenderer>()[0].enabled = false;
        meshRed.transform.localPosition = (gameObject.transform.localPosition);
        meshBlue.transform.localPosition = (gameObject.transform.localPosition);

        CancelInvoke("GlitchFruit");
        CancelInvoke("TakeMoneyAway");

    }
}
