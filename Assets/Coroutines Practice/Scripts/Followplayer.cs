using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followplayer : MonoBehaviour

{
    public GameObject Player;
    public Vector3 offset = new Vector3 (8, 7, -7);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = Player.transform.position + offset; 
    } 
}