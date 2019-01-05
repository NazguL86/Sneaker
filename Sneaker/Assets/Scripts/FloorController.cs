using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{

    [SerializeField] private float smooth = 5.0f;
    [SerializeField] private float tiltAngle = 30.0f;

    public Joystick joystick;

    //Put this outside the update function
    //float rotateFactor = 0.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float tiltAroundZ = -Input.GetAxis("Vertical") * tiltAngle;
        float tiltAroundX = -Input.GetAxis("Horizontal") * tiltAngle;
#if UNITY_ANDROID
        tiltAroundX = -joystick.Horizontal * tiltAngle;
        tiltAroundZ = -joystick.Vertical * tiltAngle;
        if (joystick.Horizontal <= .2f && joystick.Horizontal >= -.2f) {
            tiltAroundX = 0;
        }
        if (joystick.Vertical <= .2f && joystick.Vertical >= -.2f) {
            tiltAroundZ = 0;
        }
#endif
        Debug.Log("tiltAroundX = " + tiltAroundX + " tiltAroundZ = " + tiltAroundZ);
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }

    /*private void Update()
    {
        //Put this inside the update function
        float rotateX = Input.GetAxisRaw("Horizontal") * rotateFactor;
        float rotateY = Input.GetAxisRaw("Vertical") * rotateFactor;
        transform.eulerAngles += new Vector3(rotateX, 0, rotateY); //You may need to switch these around depending on your setup
    }*/
}
