using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;
    private int score;
    private bool gameOver;
    private bool restart;


    IEnumerator SpawnWaves() {

        while(true) {
            yield return new WaitForSeconds(startWait);

            for (int i = 0; i < hazardCount; i++) {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver) {
                restartText.text = "Press 'R' for restart";
                restart = true;
                break;
            }
        }

    }

    private void Start() {

        StartCoroutine(SpawnWaves());
        score = 0;
        UpdateScore();
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";

    }

    public void AddScore(int newScoreValue) {

        score += newScoreValue;
        UpdateScore();

    }

    void UpdateScore() {

        scoreText.text = "Score: " + score;

    }

    public void GameOver() {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    private void Update() {
        
        if(restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }

    }

}
