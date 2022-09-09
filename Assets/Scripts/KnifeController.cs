using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    private float speed = 4000f ;    //fast speed for the instant effect
    public static bool moveForward = true; //used in movement function is public static since effected by other scripts
    // Update is called once per frame
    private Rigidbody rb;  //Rigibody is called to take kinematic property
    private Collider c;   //Collider has to be disabled to prevent a drifting knife hitting new one
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //take components in start
        c = GetComponent<Collider>();   //take components in start
    }
    void Update()
    {
        if(moveForward == true) //Move forward stops movement if object collides for maximum effect placed in update
        {
            MoveObject();
        }
    }
     void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag=="FixedKnife") //checks if they hit an already hit knife
       {
        rb.AddForce(Vector3.down * 2* speed *Time.deltaTime );// launches them away from the board
        moveForward = false;             //stops going further
        rb.detectCollisions = false;     // collider is stopped to prevent interference with remaining
        c.enabled = false;               // had to do this twice since first still worked sometime
        Debug.Log("knife Hit");          // debugging remnant 
        Destroy(this.gameObject, 0.2f);  //basically a missed knife flies for 0.2 and then disappears
       }
    }
    void MoveObject()
    {
        rb.AddForce(Vector3.up * speed *Time.deltaTime ); //constant force applied upward while move is set to true
    }

}
