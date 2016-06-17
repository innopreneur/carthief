using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private LayerMask touchLayer;

    [SerializeField]
    private float lerpFactor;

    [SerializeField]
    private float pullLimit;

    [SerializeField]
    private float thrustFactor;

    Transform playerTransform;

    private Vector2 targetPos = Vector2.zero;
    private Vector2 originalPos = Vector2.zero;

    private Rigidbody2D rgbd;
    private bool isAngleSet = false;
    private bool isPulled = false;
    
    private CircleCollider2D circleCollider;
    
    [SerializeField]
    private GameObject thrusterAngle;

    private bool isThrusterAngleActive;
    private float targetRot;

    [SerializeField]
    private float thrusterAngleFactor;
    private float hitPositionX;
    private float hitPositionY;
    

    // Use this for initialization
    void Awake () {

        playerTransform = GetComponent<Transform>();
        targetPos = playerTransform.position;
        originalPos = playerTransform.position;

        rgbd = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        thrusterAngle.SetActive(false);
        isThrusterAngleActive = false;
    }

	
    void Start()
    {
        circleCollider.isTrigger = true;
        targetRot = playerTransform.rotation.z;
}

	// Update is called once per frame
	void Update () {

#if UNITY_EDITOR

        //check if touch is stationary or moving
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
        {

            //disable the physics effects for ball
            rgbd.isKinematic = true;
            rgbd.gravityScale = 0;


            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, touchLayer);

            //does the Ray hit player?
            if (hit) {
                if (hit.collider.tag == "Player")
                {
                    if (isAngleSet)
                    {
                        Debug.Log("Angle Set");

                       
                        
                        thrusterAngle.SetActive(false);

                        //pull player for thrust
                        PullPlayer(hit.point);
                        playerTransform.position = Vector2.Lerp(playerTransform.position, targetPos, Time.deltaTime * lerpFactor);
                    }
                    else
                    {
                        Debug.Log("Angle Not Set");
                        SetThrusterAngle(hit.point);
                    }
                }
                

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (!isAngleSet)
            {
                isAngleSet = true;
            }
            else
            {
                isPulled = true;
            }
        }

#endif

            /*      //check if player touched the screen
                  if (Input.touchCount > 0)
                  {
                      Touch touch = Input.touches[0];

                      //check if touch is stationary or moving
                      if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                      {
                          RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero, touchLayer);

                          //does the Ray hit player?
                          if (hit && hit.collider.tag == "Player")
                          {
                              PullPlayer(hit.point);
                          }
                      }
                  }

                  playerTransform.position = Vector2.Lerp(playerTransform.position, targetPos, Time.deltaTime * lerpFactor);
                 */
    }

    void FixedUpdate()
    {
#if UNITY_EDITOR

       
            if (isPulled)
            {
               
                rgbd.isKinematic = false;
                circleCollider.isTrigger = false;
                Debug.Log("Thrust - " + playerTransform.up * CalculateThrust() * thrustFactor);
                //apply thrust to ball based on calculations
                rgbd.AddForce(playerTransform.right * CalculateThrust() * thrustFactor);
                rgbd.gravityScale = 1;
                isAngleSet = false;
            }
            
        
       
#endif
    }

    //pull player back to jump
    void PullPlayer(Vector2 point)
    {
        targetPos = new Vector2(point.x, point.y);
    }

    //calculate thrust to be applied to ball
    float CalculateThrust()
    {
        return originalPos.y - playerTransform.position.y;
    }

    void SetThrusterAngle(Vector2 hitPoint)
    {
        //if thruster angle object is not active, activate it
        if (!isThrusterAngleActive)
        {
            thrusterAngle.SetActive(true);
            isThrusterAngleActive = true;
        }

        if (hitPositionX <= hitPoint.x && hitPositionY <= hitPoint.y)
        {
            targetRot = -(playerTransform.rotation.z + hitPoint.x * thrusterAngleFactor);
        }
        else if (hitPositionX > hitPoint.x && hitPositionY > hitPoint.y)
        {
            targetRot = playerTransform.rotation.z - hitPoint.x * thrusterAngleFactor;
        }

        Debug.Log("TargetRotation " + targetRot);

        playerTransform.Rotate(new Vector3(0, 0, targetRot));
        hitPositionX = hitPoint.x;
        hitPositionY = hitPoint.y;
    }
}
