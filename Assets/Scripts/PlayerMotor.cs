using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    private Rigidbody rgbd;
    private Vector3 playerVelocity = Vector3.zero;
    private bool toJump = false;


    [SerializeField]
    private float thrusterSpeed = 1000f;

    [SerializeField]
    private float jumpSpeed = 50f;

    private float currentRotationX = 0;
  

    void Start () {

        rgbd = GetComponent<Rigidbody>();
	}
	
  
	// Update is called once per frame
	void FixedUpdate () {

        PerformMovement();
    }

    public void Move(Vector3 velocity)
    {
        playerVelocity = velocity;
       
    }

    public void Jump(bool canJump)
    {
        toJump = canJump;
    }

    void PerformMovement()
    {
        if (playerVelocity != Vector3.zero)
        {
            Debug.Log("Inside Move");
            rgbd.MovePosition(rgbd.position + playerVelocity * Time.fixedDeltaTime);
        }

        if (toJump)
        {
            rgbd.AddForce(Vector3.up * jumpSpeed);
        }
    }

  
}
