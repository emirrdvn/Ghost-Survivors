using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void LoadGame()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Single);
        CleanupOldObjects();
    }
    private void CleanupOldObjects()
    {
        GameObject[] oldObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in oldObjects)
        {
            if (obj.CompareTag("DontKeep")) // Sadece özel tag'lı objeleri kaldır
            {
                Destroy(obj);
            }
        }
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
