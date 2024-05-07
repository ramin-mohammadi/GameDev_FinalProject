using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Main_Character : MonoBehaviour
{
    public static Main_Character singleton;


     [Header("Stats")]
    [SerializeField] float speed = 15f; // for rigid body was 15
    [SerializeField] float jumpForce = 100;
    [SerializeField] int health = 10;


    [Header("Physics")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] float jumpOffset = -.5f;
    [SerializeField] float jumpRadius = .25f;

  
    [SerializeField] private GameObject body;

    [Header("Tracked Data")]
    [SerializeField] Vector3 homePosition = Vector3.zero;
    // [SerializeField] TextMeshProUGUI text_player_health;
    [SerializeField] StatusPips statusPips;

 
    Rigidbody2D rb;
    public AudioSource audio_sfx;
    public AudioSource audio_music;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();

        if(singleton == null){
            singleton = this;
        }
        else{
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // text_player_health.text = "Health: " + health.ToString();
    }



    // Update is called once per frame
    void Update()
    {
    }


    public void Move(Vector3 direction)
    {
        Vector3 currentVelocity = new Vector3(0, rb.velocity.y, 0);

        rb.velocity = currentVelocity + (direction * speed);
        if(rb.velocity.x < 0){
            body.transform.localScale = new Vector3(-1,1,1);
        }else if(rb.velocity.x > 0){
            body.transform.localScale = new Vector3(1,1,1);
        }

        // rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        // transform.position += direction * Time.deltaTime * speed;
        // rb.AddForce(direction * speed);
    }

    public void Jump()
    {
        if(Physics2D.OverlapCircleAll(transform.position + new Vector3(0,jumpOffset,0),jumpRadius,groundMask).Length > 0){
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
        // rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }

    public void Damage()
    {
        health -= 1;
        // text_player_health.text = "Health: " + health.ToString();
        statusPips.RemoveHeart();

        if(health <= 0){
            Debug.Log("Player has no more health, game ends");
            // GetComponent<AudioSource>().Play();                
            // Time.timeScale = 0;

            StartCoroutine(WaitRoutine(2f));

            IEnumerator WaitRoutine(float duration)
            {         
                audio_music.Pause();               
                audio_sfx.Play();                
                Time.timeScale = 0;
                yield return new WaitForSecondsRealtime(duration);  
                Time.timeScale=1;                
                SceneManager.LoadScene("StartMenu");
            }
                // Time.timeScale = 1;

        }        
    }

    void OnTriggerEnter2D(Collider2D other){
        switch(other.gameObject.tag){
            case "EnemyBullet":
                //damage Player's health
                if(health > 0)
                    Damage();
                break;
        }
   
    }

}
