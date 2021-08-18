using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float ForceMultiplier = 3f;
    public float maximumVelocity = 3f;
    
    void Start()
    {

    }

    
    void Update()
    { 
      var HorizontalInput = Input.GetAxis("Horizontal");
      if (GetComponent<Rigidbody>().velocity.magnitude <= maximumVelocity){

        GetComponent<Rigidbody>().AddForce(new Vector3(HorizontalInput * ForceMultiplier, 0, 0));
      }

    }
private void OnCollisionEnter(Collision collision)
 {
    if (collision.gameObject.CompareTag("Hazard"))
    {
      GameManager.GameOver();
      Destroy(gameObject);
    }


  }

}
