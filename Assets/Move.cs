using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float movementSpeed = 4;
    public float jumpForce = 10;
    

    public Animator animator;

    private Rigidbody2D rgid;
    //private bool IsFlip;
    // Start is called before the first frame update
    void Start()
    {
        rgid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //IsFlip = true;

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;


        

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rgid.velocity.y) < 0.01)
        {
            rgid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
        animator.SetFloat("Speed", Mathf.Abs(movement));


        if (Input.GetButtonDown("Crouch") )
        {
            
            animator.SetBool("IsCrouching", true);
        }
        else if(Input.GetButtonUp("Crouch"))
            {
            
            animator.SetBool("IsCrouching", false);
        }

        Vector3 theScale = transform.localScale;

        if (movement>0 )
        {
            theScale.x = 7;
        } else if(movement <0)
        {
            theScale.x = -7;
        }
        transform.localScale = theScale;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("IsJumping", false);
    }

}
