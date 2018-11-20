using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Messenger.Broadcast(GameEvent.LEVEL_COMPLETED);
    }
}
