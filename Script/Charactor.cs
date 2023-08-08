using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Charactor : MonoBehaviour
{
    public int maxHealth;
    public HPbar healthbar;
    private int curHealth;

    void Start() 
    {
       curHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("BulletE")||other.gameObject.CompareTag("Enemy"))
        {
           
           TakeDamage(10);
        }
    }
   
    public void TakeDamage(int damage)
    {
        AudioManager.instance.playHit();
       
        curHealth -= damage;
        
        healthbar.UpdateHealth((float)curHealth/(float)maxHealth);

        if(curHealth == 0)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
     public void GetHp(int hp)
     {
         curHealth += hp;
         if(curHealth >= 100)
         {
            curHealth = maxHealth;
         }
        
        healthbar.UpdateHealth((float)curHealth/(float)maxHealth);
     }

}
