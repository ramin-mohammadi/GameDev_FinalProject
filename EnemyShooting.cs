using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    // public GameObject bullet;
    private float timer = 0f;
    public float bulletSpeed = 20;
    [SerializeField] float force = 8f;

    public AudioSource audio_sfx;
    // Start is called before the first frame update
    void Start()
    {
    //    AudioSource[] audio_list = GetComponents<AudioSource>();
    //    audio_sfx = audio_list[0];

    }

    // Update is called once per frame
    void Update()
    {
        // float distance = Vector2.Distance(transform.position, player_transform.position);
        float distance = Vector2.Distance(transform.position, Main_Character.singleton.transform.position);


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
        // GameObject newProjectile = Instantiate(bullet, transform.position , transform.rotation);
        GameObject newProjectile = ObjectPooler.singleton.SpawnFromPool("EnemyBullet", transform.position, transform.rotation);
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        
        Vector3 direction = Main_Character.singleton.transform.position - newProjectile.transform.position;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        newProjectile.transform.rotation = Quaternion.Euler(0,0,rot);

        audio_sfx.Play();


    }
}
