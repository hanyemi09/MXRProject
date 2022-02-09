using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{

    public GameObject mapToBeControlled;

    float maximumTiltAngle = 20f;
    [SerializeField] float timeToFinish = 2f;
    bool buttonIsPressed = false;

    Transform transformPosition;
    Transform endTransformPosition;

    Vector3 currentAngle;
    Vector3 originalAngle;
    Vector3 targetAngleUp = new Vector3(0f , 0f, -20f);
    Vector3 targetAngleDown = new Vector3(0f, 0f, 20f);
    Vector3 targetAngleLeft = new Vector3(20f, 0f, 0f);
    Vector3 targetAngleRight = new Vector3(-20f, 0f, 0f);

    bool UpButtonPressed = false;
    bool LeftButtonPressed = false;
    bool RightButtonPressed = false;
    bool DownButtonPressed = false;
    float rotateSpeed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        originalAngle = currentAngle = transform.eulerAngles;
        transformPosition = gameObject.transform;
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 Tilt = Input.acceleration;

        Tilt = Quaternion.Euler(90, 0, 0) * Tilt;

        currentAngle = Tilt;


        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2)
            {

                Debug.Log("Repositioning gameObject");
                mapToBeControlled.transform.position = gameObject.transform.position;
                transformPosition = gameObject.transform;
            }
        }

        if (UpButtonPressed)
        {
            currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngleUp.x, Time.deltaTime * rotateSpeed),
            Mathf.LerpAngle(currentAngle.y, targetAngleUp.y, Time.deltaTime * rotateSpeed),
            Mathf.LerpAngle(currentAngle.z, targetAngleUp.z, Time.deltaTime * rotateSpeed));

        }
        else if(DownButtonPressed)
        {
            currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngleDown.x, Time.deltaTime * rotateSpeed),
            Mathf.LerpAngle(currentAngle.y, targetAngleDown.y, Time.deltaTime * rotateSpeed),
            Mathf.LerpAngle(currentAngle.z, targetAngleDown.z, Time.deltaTime * rotateSpeed));

        }
        else if(LeftButtonPressed)
        {
            currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngleLeft.x, Time.deltaTime * rotateSpeed),
            Mathf.LerpAngle(currentAngle.y, targetAngleLeft.y, Time.deltaTime * rotateSpeed),
            Mathf.LerpAngle(currentAngle.z, targetAngleLeft.z, Time.deltaTime * rotateSpeed));

        }
        else if(RightButtonPressed)
        {
            currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngleRight.x, Time.deltaTime * rotateSpeed),
            Mathf.LerpAngle(currentAngle.y, targetAngleRight.y, Time.deltaTime * rotateSpeed),
            Mathf.LerpAngle(currentAngle.z, targetAngleRight.z, Time.deltaTime * rotateSpeed));

        }
        else
        {
            currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, originalAngle.x, Time.deltaTime * rotateSpeed),
            Mathf.LerpAngle(currentAngle.y, originalAngle.y, Time.deltaTime * rotateSpeed),
            Mathf.LerpAngle(currentAngle.z, originalAngle.z, Time.deltaTime * rotateSpeed));

        }
        currentAngle = Tilt;

        transform.eulerAngles = currentAngle;

    }

    public void ButtonUp()
    {
        if (!UpButtonPressed)
            UpButtonPressed = true;
        else
            UpButtonPressed = false;
        // Set all button false
        RightButtonPressed = DownButtonPressed = LeftButtonPressed = false;
    }

  
    public void ButtonLeft()
    {
        if (!RightButtonPressed)
            RightButtonPressed = true;
        else
            RightButtonPressed = false;
        // Set all button false
        UpButtonPressed = DownButtonPressed = LeftButtonPressed = false;

    }

    public void ButtonRight()
    {
        if (!LeftButtonPressed)
            LeftButtonPressed = true;
        else
            LeftButtonPressed = false;
        // Set all button false
        UpButtonPressed = DownButtonPressed = RightButtonPressed = false;

    }

    public void ButtonDown()
    {
        if (!DownButtonPressed)
            DownButtonPressed = true;
        else
            DownButtonPressed = false;
        // Set all button false
        UpButtonPressed = LeftButtonPressed = RightButtonPressed = false;

    }

}
