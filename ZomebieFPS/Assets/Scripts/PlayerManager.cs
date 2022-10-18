using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health = 100;
    public Text healthNumber;
    public GameManager gameManager;
    public void Hit(float damage)
    {
        health -= damage;
        healthNumber.text = "Health: " + health.ToString();  
        if(health <= 0)
        {
            gameManager.EndGame();
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
