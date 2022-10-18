using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] public int enemiesAlive = 0;
    [SerializeField]public int round = 0;

    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    public Text roundNumber;
    public GameObject endGame;
    public Text roundsSuvived;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive == 0)
        {
            round++;
            NextWave(round);
            roundNumber.text = "Round: " + round.ToString();
        }
    }

    public void NextWave(int round)
    {
        for(var x =0; x < round; x++)
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();
            enemiesAlive++;
        }
        
    }
    public void Restar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void BackMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        endGame.SetActive(true);
        roundsSuvived.text = round.ToString();
    }
}
