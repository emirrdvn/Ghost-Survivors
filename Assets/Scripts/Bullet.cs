using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("Bullet collided with " + collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Gun")
        {
            return;
        }
        else
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        
        
        
    }

    
}
