using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarController : MonoBehaviour {

    private MoveLeftInput leftInput;
    private MoveRightInput rightInput;

    public Image leftButton;
    public Image rightButton;
    public float strafeSpeed = 6f;
    public float carPositionLimitX = 18f;

    private Transform playerTransform;
    private Rigidbody2D rgbd;

	// Use this for initialization
	void Start () {

        leftInput = leftButton.GetComponent<MoveLeftInput>();
        rightInput = rightButton.GetComponent<MoveRightInput>();

        rgbd = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        Move();
        float xPosition = Mathf.Clamp(playerTransform.position.x, -carPositionLimitX, carPositionLimitX);
        playerTransform.position = new Vector3(xPosition, playerTransform.position.y);
    }

    void Move()
    {

        if (leftInput.GetLeftInput())
        {
            playerTransform.Translate(Vector3.left * strafeSpeed);
        }
        else if (rightInput.GetRightInput())
        {
            playerTransform.Translate(Vector3.right * strafeSpeed);
        }
    }
}
