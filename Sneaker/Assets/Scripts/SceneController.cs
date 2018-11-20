using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector3 enemyPosition;
    private GameObject _enemy;
	
	// Update is called once per frame
	void Update () {
        // Handled via editor
        /*if (_enemy == null) {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = enemyPosition;
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }*/
	}
}
