using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour
{
    public int movespeed;

private void Start() {
    AudioManager.instance.playelazert();
}
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * movespeed);
        Destroy(gameObject,1);
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ground")||other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
