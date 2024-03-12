using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Character : MonoBehaviour
{
     [Header("Stats")]
    [SerializeField] float speed = 1f;
    [SerializeField] float jumpForce = 10;
    [SerializeField] int health = 3;


    [Header("Physics")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] float jumpOffset = -.5f;
    [SerializeField] float jumpRadius = .25f;

  
    [SerializeField] private GameObject body;

    [Header("Tracked Data")]
    [SerializeField] Vector3 homePosition = Vector3.zero;

    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {
   
    }


    public void Move(Vector3 direction)
    {
        Vector3 currentVelocity = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = (currentVelocity) + (direction * speed);
        if(rb.velocity.x < 0){
            body.transform.localScale = new Vector3(-1,1,1);
        }else if(rb.velocity.x > 0){
            body.transform.localScale = new Vector3(1,1,1);
        }
        //rb.MovePosition(transform.position + (direction * speed * Time.deltaTime))
    }

      public void Jump()
    {
        // if(Physics2D.OverlapCircleAll(transform.position + new Vector3(0,jumpOffset,0),jumpRadius,groundMask).Length > 0){
        //     rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        // }
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }

}
