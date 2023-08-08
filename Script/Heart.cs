using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    //public GameObject pop;
    public Charactor hp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hp.GetHp(50);
            gameObject.SetActive(false);
            AudioManager.instance.playCoin();
            //Instantiate(pop, transform.position, transform.rotation);
        }
    }
}
