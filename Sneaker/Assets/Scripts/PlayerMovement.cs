using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rigidbody;
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float force = 20.0f;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
    }

	void FixedUpdate () {
        //rigidbody.AddForce(Vector3.down * force);
        //rigidbody.velocity = Vector3.down * speed;
    }
}
