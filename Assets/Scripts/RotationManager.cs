using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    bool rotateDirection = true; //true = positive z axis fales = -ve z axis
    //private float rotateSpeed = 30.0f;
    private bool doRotate = true;
    private float rotateTime = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Invokes Rotate Function that will take random direction which is invoked in random direction function
        InvokeRepeating("Rotate",Random.Range(0.0f,5.0f),rotateTime);
        InvokeRepeating("RandomDirection",Random.Range(3f,5.0f),Random.Range(4.0f,8.0f));
    }
    void Update()
    {
        if (doRotate == true)
        {
            Rotate();
        }
        
    }
    void Rotate()
    {
        if (rotateDirection==true)
        {
            transform.Rotate(Vector3.forward,200.0f*Time.deltaTime,Space.Self);
        }
        else
        {
             transform.Rotate(Vector3.back,200.0f*Time.deltaTime,Space.Self);
        }
        //transform.Rotate(new Vector3(0,0,Random.Range(1,-1)),200.0f*Time.deltaTime,Space.Self);  
    }
    void RandomDirection()
    {
        rotateDirection = !rotateDirection;
    }
   
}
