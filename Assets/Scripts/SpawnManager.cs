using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Üretilecek düşman prefab'i
    public Transform enemyParent;  // Düşmanların toplanacağı parent nesne
    public float spawnInterval = 1.0f; // Düşmanların üretim aralığı
    private bool isSpawning = true; // Düşman üretimi devam ediyor mu?
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (isSpawning)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    // Update is called once per frame
    void SpawnEnemy()
    {
        // Düşmanı oluştur ve parent nesnesinin altına yerleştir
        GameObject newEnemy = Instantiate(enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        newEnemy.transform.parent = enemyParent;
    }
    void Update()
    {
        
    }
    Vector3 GetRandomSpawnPosition()
    {
        // Düşmanın üretileceği rastgele bir pozisyon belirleyin (örnek)
        float xPos = Random.Range(-43f, 43f);
        float zPos = Random.Range(-43f, 43f);
        return new Vector3(xPos, 2, zPos);
    }
    public void StopSpawning()
    {
        Debug.Log("StopSpawning");
        isSpawning = false;
    }
}
