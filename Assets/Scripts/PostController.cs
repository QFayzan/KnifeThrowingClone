using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PostController : MonoBehaviour
{
    // I named the object rotating in the center as post
    public TextMeshProUGUI postHP;   //UI for Displaying HP to the user
    public static int health = 8;    // static int since other scripts affect this value

    // Start is called before the first frame update
    void Start()
    {
        health = 8;      //Called at start since scene reload does not reset values
    }

    // Update is called once per frame
    void Update()
    {
        postHP.text =  health.ToString(); //Assign text box
       if (health < 1)
       {
        Die();   // Die is used as a function since function can be scaled to add particles etc
       }

    }

    public void Die() //Scalable die function that can take sound and particles if needed
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }
    //Basically the Mechanic used here is that once a knife is inside the "Post" it is now a "Fixed Knife"
    //kinematic property is set to true to allow the object to stick in another object and collider 
    //was adjusted to give the thrusted in effect
    void OnCollisionEnter (Collision other)
    {
         if (other.gameObject.tag=="Knife")
       {
        other.rigidbody.isKinematic=true;     //allows knife to stick
        other.transform.parent = this.transform; //merges transform property of knife with "Post"
        other.gameObject.tag = "FixedKnife";   //New tag that will handle the collison effect
        KnifeController.moveForward=false;     //Move forward was used in knife movement must be set false
        health--;                              //Health reduction
        KnifeSpawner.knifeHit++;               //Successful hits Shown
       }
    }
}

