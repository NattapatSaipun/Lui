using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public float fireRate = 0;
    public float damage = 10;
    public LayerMask whatToHit;
    public GameObject pointFire;

    public Transform BulletTrailPrefab;
    float timeToSpawnEffect = 0;
    public float effectSpaenRate = 10;
   

    float timeToFire = 0;
    public Transform firePoint;


    // Start is called before the first frame update
    void Awake()
    {
        firePoint = pointFire.transform;
        if (firePoint == null)
        {
            Debug.LogError("No firePoint? WHAT?");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fireRate == 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
               Shoot();
            }
        }
        else{
            if(Input.GetMouseButton(0)&&Time.time > timeToFire)
            {
                timeToFire = Time.time + 1/fireRate;
                Shoot();
            }
        }
    }
    void Shoot()
    {
      Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x , Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
      Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
      RaycastHit2D hit = Physics2D.Raycast(firePointPosition,mousePosition-firePointPosition,100,whatToHit);
      if(Time.time >= timeToSpawnEffect)
      {
         Effect ();
         timeToSpawnEffect = Time.time +1/effectSpaenRate;
      }

      Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100);
      if(hit.collider != null)
      {
        Debug.DrawLine(firePointPosition,hit.point,Color.red);
       // Debug.Log("We hit" + hit.collider.name + "and did" + damage + "damage.");
      }
    }
    void Effect()
    {
        Instantiate(BulletTrailPrefab, firePoint.position,firePoint.rotation);
    }
}
