using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerInput: MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    private PlayerMotor motor;
    private VirtualJoyStick joystick;
    private ButtonInput buttonInput;

    [SerializeField]
    private Image joystickImg;

    [SerializeField]
    private Image buttonImg;

    [SerializeField]
    private float mouseSensitivity = 3f;

	
	void Start () {
        joystick = joystickImg.GetComponent<VirtualJoyStick>();
        buttonInput = buttonImg.GetComponent<ButtonInput>();
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {

        float xMov = joystick.GetX();
       
        float zMov = joystick.GetZ();
        
        Vector3 moveX = transform.right * xMov;
        Vector3 moveZ = transform.forward * zMov;

        Vector3 velocity = (moveX + moveZ).normalized * speed;
        motor.Move(velocity);
       // motor.Jump(buttonInput.GetButton());


    }
}
