using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleControl : MonoBehaviour
{
    //VARIABLES

    [Header("Movement")]
    public float moveSpeed;
    public float turnSpeed;
    public float jumpForce;
    public bool isOnGround = true;
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody rb;
    public AudioClip jumpSound;
    private AudioSource playerAudio; 

    [Header("Shooting")]
    public GameObject projectile;
    public GameObject spawnPoint;
    public float shootDelay;
    public bool canShoot = true; 

    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>(); 
     playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
     //Forward and Backward Movement
     verticalInput = Input.GetAxis("Vertical");
     transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);

     //Clockwise and counterclockwise Rotation
     horizontalInput = Input.GetAxis("Horizontal");
     transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);


     //Jumping
     if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
     {
      isOnGround = false;  
      rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      playerAudio.PlayOneShot(jumpSound, 1.0f);
     }
     //Shooting
     if(Input.GetMouseButtonDown(0))
     {
      StartCoroutine(Shoot());
     }
    }

    IEnumerator Shoot()
    {
     canShoot = false;

     //Shoot a ptrojectile 
     Instantiate(projectile,spawnPoint.transform.position, spawnPoint.transform.rotation);
     //Wait 
     yield return new WaitForSeconds(shootDelay);
     canShoot = true; 
    }

    private void OnCollisionEnter(Collision collision)
    {
     if (collision.gameObject.CompareTag("Ground"))
     {
      isOnGround = true;
     }
    }
}
