using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] private Text levelCompletedText;
    [SerializeField] private Text spottedText;

    void Awake() {
        Messenger.AddListener(GameEvent.LEVEL_COMPLETED, OnLevelCompleted);
        Messenger.AddListener(GameEvent.PLAYER_SPOTTED, OnPlayerSpotted);
    }
    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.LEVEL_COMPLETED, OnLevelCompleted);
        Messenger.RemoveListener(GameEvent.PLAYER_SPOTTED, OnPlayerSpotted);
    }

    void Start () {
        levelCompletedText.gameObject.SetActive(false);
        spottedText.gameObject.SetActive(false);
    }

    private void OnPlayerSpotted()
    {
        StartCoroutine(PlayerSpotted());
    }

    private IEnumerator PlayerSpotted() {
        spottedText.gameObject.SetActive(true);

        yield return null;//new WaitForSeconds(2);
    }

    private void OnLevelCompleted() {
        StartCoroutine(CompleteLevel());
    }

    private IEnumerator CompleteLevel() {
        levelCompletedText.gameObject.SetActive(true);
        levelCompletedText.text = "Level Complete!";

        yield return new WaitForSeconds(2);
    }

}
