using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] Main_Character player;
    private Rigidbody2D rb;
    [SerializeField] float force = 5f;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other){
        switch(other.gameObject.tag){
            case "Block":
                Destroy(this.gameObject);
                break;
            case "Player":
                Destroy(this.gameObject);
                //damage Player's health
                player.Damage();
                break;
        }
   
    }
}
