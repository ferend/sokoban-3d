using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 3f;
    public Transform movePoint;
    public LayerMask stopMovement;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position,movePoint.position) <= .05f)
        {
            
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, stopMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
                    
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3( 0f, Input.GetAxisRaw("Vertical"),  0f), .2f, stopMovement))
                {
                    movePoint.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));
                }
                    
            }
        }

        
    }
}
