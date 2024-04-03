using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    // public Transform bulletPos = transform.position;
    private float timer = 0f;
    [SerializeField] Transform player_transform;
    public float bulletSpeed = 20;
    [SerializeField] float force = 8f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player_transform.position);

        if(distance < 22){        
            timer += Time.deltaTime;
            if(timer >= 1){
                // Debug.Log("FIREEEEEEEEEEE");
                Fire();
                timer = 0;
            }
        }        
    }
    void Fire(){
        GameObject newProjectile = Instantiate(bullet, transform.position , transform.rotation);
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        
        Vector3 direction = player_transform.position - newProjectile.transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        newProjectile.transform.rotation = Quaternion.Euler(0,0,rot);


    }
}
