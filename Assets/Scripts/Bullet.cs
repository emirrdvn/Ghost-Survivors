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

    private void OnTriggerEnter(Collider collision)
    {   
        Debug.Log("Collision detected"+ collision.gameObject.tag);
        
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        
        
        
    }

    
}
