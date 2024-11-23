using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       EnemyMovementFunc();
    }

    void EnemyMovementFunc(){
         player = GameObject.Find("Body");

        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(
        player.transform.position.x,
        transform.position.y,
        player.transform.position.z
    ), speed * Time.deltaTime);
    }

   /* private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AAAAAAAA");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collision detected"+ other.gameObject.tag);
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            //player.Knockback();
            player.Damage();
            Debug.Log("Player hp ="+ player.health);
            
        }
    }*/
}
