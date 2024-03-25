using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] Main_Character player;
    [SerializeField] Weapon weapon;
    [SerializeField] float delayBetweenBullets = 0.000001f;
    private float timer = 0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            input.x += -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            input.x += 1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Jump();
        }

        // if (Input.GetMouseButton(0)){ 
        //     weapon.Fire(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        //     // timer += Time.deltaTime;
        //     // // delay between bullets
  
        //     //     // if(Time.time - timeLastShot >= delayBetweenBullets){
        //     //     if(timer >= delayBetweenBullets){
        //     //         // canFire = true;
        //     //         // timeLastShot = Time.time;      
        //     //         weapon.Fire(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //     //         // canFire = false;
        //     //         timer = 0f;
                    
        //     //     }
        // }

        player.Move(input);
    }
}
