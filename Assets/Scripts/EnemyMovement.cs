using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public float speed = 1.0f;
    public GameObject EffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Eğer player sahnede her zaman "Body" ismiyle varsa, baştan atanabilir
        if (player == null)
        {
            player = GameObject.Find("Body");
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovementFunc();
    }

    void EnemyMovementFunc()
    {
        // Eğer oyuncu bulunamıyorsa sahnede aramaya devam eder
        if (player == null)
        {
            player = GameObject.Find("Body");
        }

        // Hedef pozisyonu al (aynı Y ekseninde kalmak için sadece X ve Z kullanıyoruz)
        Vector3 targetPosition = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z
        );

        // Düşmanı hedef pozisyona hareket ettir
        enemy.transform.position = Vector3.MoveTowards(
            enemy.transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        // Düşmanın yüzünü oyuncuya döndür
        Vector3 direction = targetPosition - enemy.transform.position;

        if (direction != Vector3.zero) // Boş vektör olmadığını kontrol et
        {
            enemy.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected" + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("Collision detected" + other.gameObject.tag);
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            //player.Knockback();
            player.Damage();
            Debug.Log("Player hp =" + player.health);

        }
        if (other.gameObject.tag == "Bullet")
        {
            //EffectPrefab = GameObject.Find("Explosion");



            EffectPrefab = Instantiate(EffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(EffectPrefab, 1f);
            StartCoroutine(DestroyEffectAfterTime(EffectPrefab, 1f));
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }


    private IEnumerator DestroyEffectAfterTime(GameObject bullet, float bulletPreFabLifeTime)
    {
        
        yield return new WaitForSeconds(bulletPreFabLifeTime);
        Destroy(bullet);
    }
}
