using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] private Text levelCompletedText;
    [SerializeField] private Text spottedText;
    [SerializeField] private Text diedText;
    [SerializeField] private Text timeText;

    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip spottedClip;
    [SerializeField] private AudioClip successClip;

    public float timer;
    public bool timerStarted = false;

    void Awake() {
        Messenger.AddListener(GameEvent.LEVEL_COMPLETED, OnLevelCompleted);
        Messenger.AddListener(GameEvent.PLAYER_SPOTTED, OnPlayerSpotted);
        Messenger.AddListener(GameEvent.PLAYER_DIED, OnLevelFailed);
        //Messenger.AddListener(GameEvent.GAME_COMPLETE, On);
    }
    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.LEVEL_COMPLETED, OnLevelCompleted);
        Messenger.RemoveListener(GameEvent.PLAYER_SPOTTED, OnPlayerSpotted);
        Messenger.RemoveListener(GameEvent.PLAYER_DIED, OnLevelFailed);
        //Messenger.RemoveListener(GameEvent.GAME_COMPLETE, OnLevelFailed);
    }

    void Start () {
        levelCompletedText.gameObject.SetActive(false);
        spottedText.gameObject.SetActive(false);
        diedText.gameObject.SetActive(false);

        timeText.text = "Time: ";
        timer = 0;
        timerStarted = true;
    }

    void Update()
    {
        if (timerStarted) {
            timer += Time.deltaTime;
            timeText.text = "Time: "+string.Format("{0:N2}", timer)+"s";
        }
    }

    private void OnPlayerSpotted() {
        StartCoroutine(PlayerSpotted());
    }

    private IEnumerator PlayerSpotted() {
        Managers.Audio.PlaySound(spottedClip);
        spottedText.gameObject.SetActive(true);

        yield return null;//new WaitForSeconds(2);
    }

    private void OnLevelCompleted() {
        StartCoroutine(CompleteLevel());
    }

    private IEnumerator CompleteLevel() {
        Managers.Audio.PlaySound(successClip);
        levelCompletedText.gameObject.SetActive(true);
        timerStarted = false;
        levelCompletedText.text = "Level Completed in "+ string.Format("{0:N2}", timer)+"s !";

        yield return new WaitForSeconds(4);

        Managers.Mission.RestartCurrent();
    }

    private void OnLevelFailed()
    {
        StartCoroutine(FailLevel());
    }

    private IEnumerator FailLevel()
    {
        Managers.Audio.PlaySound(deathClip);
        diedText.gameObject.SetActive(true);
        diedText.text = "YOU DIED";
        timerStarted = false;

        yield return new WaitForSeconds(6);

        Managers.Mission.RestartCurrent();
    }

    private IEnumerator StartTimer() {
        timeText.text += 1;
        yield return StartTimer();
    }

}
