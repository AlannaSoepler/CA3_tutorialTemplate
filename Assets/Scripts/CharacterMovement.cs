using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //variables go here
    public float speed = 5;
    
    public float jumpPower = 4;
    Rigidbody rb;
    CapsuleCollider col;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
 
    }

    // Update is called once per frame
    void Update()
    {
        //get input values from controllers
        float Horizontal = Input.GetAxis("Horizontal") * speed;
        float Vertical = Input.GetAxis("Vertical") * speed;
        Horizontal *= Time.deltaTime;
        Vertical *= Time.deltaTime;
        
        //translate our character
        transform.Translate(Horizontal, 0, Vertical);
        
        //test if character can jump
        //Debug.Log("hi:"+ isGrounded());

        if (isGrounded() && Input.GetButtonDown("Jump")) 
        {
            //add upward force to the rigidbody
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        } 

        if (Input.GetKeyDown("escape"))
        {
                Cursor.lockState = CursorLockMode.None;
        }
    }
    
    private bool isGrounded()
    {
        //Test that we are grounded by drawing an invisible raycast line
        //if this hits a solid object we are grounded
        return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.2f);
    }

}

