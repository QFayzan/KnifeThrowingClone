using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    //Entire Code loads the Main scene after 5 seconds
    public float timer = 5f;
    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            SceneManager.LoadScene("Main");
            timer = 5.0f;
        }
    }
}
