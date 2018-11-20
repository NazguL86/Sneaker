using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelAI : MonoBehaviour {

    enum Type { Type1, Type2 };

    [SerializeField] private float speed;
    [SerializeField] private Type type;

    public float obstacleRange = 1.0f;
    public float rotationTime = 5f;

    private bool isAlive;
    Vector3 rotationAxis = Vector3.down;

    // Use this for initialization
    void Start () {
        isAlive = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (isAlive == false) {
            Debug.Log("You're dead!");
            return;
        }

        switch (type) {
            case Type.Type1:
                if (rotationTime <= 0) {
                    rotationTime = 5;
                    rotationAxis = rotationAxis == Vector3.down ? Vector3.up : Vector3.down;
                }
                transform.Rotate(rotationAxis, Time.deltaTime * speed);
                rotationTime -= Time.deltaTime;
                break;
            case Type.Type2:
                transform.Translate(0, 0, speed * Time.deltaTime);
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                if (Physics.SphereCast(ray, 0.75f, out hit)) {
                    GameObject hitObject = hit.transform.gameObject;
                    if (hit.distance < obstacleRange) {
                        transform.Rotate(0, 180, 0);
                    }
                }
                break;
            default:
                Debug.Log("Incorrect type passed into");
                break;
        }
	}
}
