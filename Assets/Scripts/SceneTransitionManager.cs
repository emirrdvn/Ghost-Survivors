using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    private bool isSceneLoading = false; // Aynı sahneyi birden fazla kez yüklemeyi engellemek için kontrol

    private void Update()
    {
        // Enter tuşuna basıldığında sahne geçişi
        if (Input.GetKeyDown(KeyCode.Return) && !isSceneLoading)
        {
            LoadNextScene(); // Sahneyi asenkron olarak yükle
        }
    }

    public void LoadNextScene()
    {
        isSceneLoading = true; // Yükleme başladı
        StartCoroutine(LoadSceneAsync("Ingame2")); // İkinci sahneyi yükle
    }

    private System.Collections.IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Yükleme tamamlanana kadar bekle
        while (!asyncLoad.isDone)
        {
            // Gerekirse burada yükleme çubuğu veya animasyon gösterilebilir
            yield return null;
        }

        isSceneLoading = false; // Yükleme tamamlandı
    }
}
