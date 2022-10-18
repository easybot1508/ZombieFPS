using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float maxDistance = 100f;
    public float damage = 25f;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Frame 1
        // ban dau` cho trang thai' cua? isShooting la false sau do khi phuong thuc Shoot() duoc goi. bang` cach' nhan' chuot. 
        //thi` trang. thai cua? isShooting tron method Shoot() se thanh` true
        //next Frame thi` hien. isShooting dang la true neu isShooting la true thi` se~ chay. dieu kien if ben duoi'
        //lam` cho isShooting tro lai trang thai false sau do chung ta lai. goi. ham` shoot de thuc. hien lan` nua~
        //va` se~ lap. di lap. lai khi chung ta nhan chuot.
        if (playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        playerAnimator.SetBool("isShooting", true); 
        RaycastHit hit;
        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, maxDistance))
        {
            Debug.Log("hit");
            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            if(enemyManager != null)
            {
                enemyManager.Hit(damage);   
            }
        }
    }
}
