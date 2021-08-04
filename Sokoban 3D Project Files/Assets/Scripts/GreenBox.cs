using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBox : MonoBehaviour
{
    public Rigidbody rb;
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Collided with player");
            
        }

        if (collision.collider.tag == "GreenArea")
        {
            Debug.Log("Collided with  area");
            rb.constraints = RigidbodyConstraints.FreezeAll;
            FindObjectOfType<LevelGoal>().CollisionDetected();
        }

        if (collision.collider.tag == "Pit")
        {
            Debug.Log("Fallen to Pit");
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            gameObject.transform.localScale = new Vector3(1, 2, 1);
        }



    }
}