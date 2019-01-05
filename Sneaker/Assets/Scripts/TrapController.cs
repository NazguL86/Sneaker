using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collided with " + col);
        if (col.gameObject.tag == "Player")
        {
            Messenger.Broadcast(GameEvent.PLAYER_DIED);
            Destroy(col.gameObject);
        }
    }
}
