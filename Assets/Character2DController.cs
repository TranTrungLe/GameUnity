using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float movementSpeed = 4;
    public float jumpForce = 10;

    private Rigidbody2D rgid;
    // Start is called before the first frame update
    void Start()
    {
        rgid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rgid.velocity.y) < 0.01)
        {
            rgid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
