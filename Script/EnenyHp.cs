using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenyHp : MonoBehaviour
{
     public int maxHealth;
     private int curHealth;
     float hp;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        hp = maxHealth;
        
    }

    private void OnTriggerEnter2D(Collider2D other)  
     {
        if(other.gameObject.tag == "BulletP")
        {
          Debug.Log("Hit");
           TakeDamage(10);
           AudioManager.instance.playenemyHit();
        }
    }
      public void TakeDamage(int damage)
    {
        
        curHealth -= damage;
        
        hp = maxHealth/curHealth;
        
        if(hp <= 0)
        {
             AudioManager.instance.playDie();
            Destroy(this.gameObject);
        }
    }

   
}
