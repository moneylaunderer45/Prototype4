using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBall;
    
    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Q))
     {
      Shoot(5);
     }
     if (Input.GetKeyDown(KeyCode.E))
     {
      Shoot(Random.Range(10,100) );
     }
    }
    public void Shoot(int numberOfBalls)
    {
     for(int i = 0; i < numberOfBalls; i++)
     {
      Instantiate(cannonBall, transform.position, transform.rotation);
     }
    }

    IEnumerator SteadyShot(int numberOfBalls, float delay)
    {
     for (int i = 0; i < numberOfBalls; i++)
     {
      Instantiate(cannonBall, transform.position, transform.rotation);
      yield return new WaitForSeconds(delay);
     }
    }
}
