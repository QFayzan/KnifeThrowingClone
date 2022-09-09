using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class KnifeSpawner : MonoBehaviour
{
   
    public TextMeshProUGUI Remaining; //Used to show how many knives remain to the player
    public TextMeshProUGUI Hit;   //Used to display number of successful hits
    public GameObject knifePrefab; //Get the Knife Prefab
    public float knifeDelay = 0.5f;//Add a delay to knife launch
    public bool doSpawn = true;    //Limiting condition for delay Mechanic
    static public int knifeCount = 10;     //Amount of Knives 
    static public int knifeHit = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Values are set at the start since scene reload does NOT reset values
        knifeCount = 10;
        knifeHit = 0;
        knifeDelay = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Hit.text = "Target Hit : " + knifeHit.ToString();          // assign text box
        Remaining.text = "Knives Remaining : " + knifeCount.ToString();//assign text box
        // add a delay between knives spawning
        knifeDelay = knifeDelay + Time.deltaTime;  // delay mechanic so that knives dont rush out
        if (knifeDelay>0.5f)
        {
            doSpawn = true;
        }
        //spawn a knife on space or mouseclick using remaining knife and spawn interval as parameter
         if (Input.GetMouseButton(0) && doSpawn && knifeCount>0 )
        {
            KnifeController.moveForward = true;
            Instantiate(knifePrefab, transform.position, knifePrefab.transform.rotation);
            doSpawn = false;
            knifeDelay = 0;
            knifeCount--;
        }
        //Basically the out of knives lose condition
        if (knifeCount <1)
        {
            SceneManager.LoadScene("GameOver");
        }
        

    }
}
