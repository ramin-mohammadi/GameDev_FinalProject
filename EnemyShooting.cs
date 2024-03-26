using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    // public Transform bulletPos = transform.position;
    private float timer = 0f;
    [SerializeField] Main_Character player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 15){        
            timer += Time.deltaTime;
            if(timer >= 1){
                // Debug.Log("FIREEEEEEEEEEE");
                Fire();
                timer = 0;
            }
        }        
    }
    void Fire(){
        Instantiate(bullet, transform.position , Quaternion.identity);
    }
}
