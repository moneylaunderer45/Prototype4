using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foodspawning : MonoBehaviour
{
    public GameObject chocolate;
    public GameObject cookiechocolate;
    public GameObject lollipop;

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Space))
     {
      Instantiate(chocolate, transform.position, transform.rotation);  
     }

     if (Input.GetKeyDown(KeyCode.LeftShift))
     {
      Instantiate(cookiechocolate, transform.position, transform.rotation);
     }

     if (Input.GetKeyDown(KeyCode.KeypadEnter))
     {
      Instantiate(lollipop, transform.position, transform.rotation);
     }
    } 
}
