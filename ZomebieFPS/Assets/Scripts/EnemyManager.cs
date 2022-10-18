using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    //tim` den vi. tri; cua? player
    public GameObject player;
    public Animator enemyAnimator;
    public float damage = 20f;
    public float health = 100f;
    public GameManager gameManager;
    public void Hit(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            gameManager.enemiesAlive--;
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //tim` kiem nguoi` choi thong qua the? co ten Player
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        //lien tuc lay vi tri' cua? player khi player di qua no
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        //magnitude: tra? ve` do dai` cua? vector
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            enemyAnimator.SetBool("isRunning", true);
        }
        else
        {
            enemyAnimator.SetBool("isRunning", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            player.GetComponent<PlayerManager>().Hit(damage);
        }
    }
}
