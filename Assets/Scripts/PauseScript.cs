using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenuUI; // Duraklama menüsü paneli
    public bool isPaused = false; // Oyunun duraklama durumu
    private bool isAxisInUse = false; // Tuşun basılı olup olmadığını kontrol eder

    private void Update()
    {
        float cancelInput = Input.GetAxis("Cancel"); // Escape tuşu

        // Tuşa ilk kez basıldığında işlem yap
        if (cancelInput > 0 && !isAxisInUse)
        {
            TogglePauseMenu(); // Menü durumunu değiştir
            isAxisInUse = true; // Tuş kullanıldı olarak işaretle
        }

        // Tuş bırakıldığında yeniden kullanılabilir hale getir
        if (cancelInput == 0)
        {
            isAxisInUse = false; // Tuş serbest bırakıldı
        }
        /*if (cancelInput > 0.1f) // Eşik değeri
        {
            if (!isAxisInUse) // Tuşa basıldığında bir kez işlem yapılması
            {
                pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
                Time.timeScale = pauseMenuUI.activeSelf ? 0.01f : 1f;
                isAxisInUse = true; // Tuş işleme alındı
            }
        }
        else
        {
            isAxisInUse = false; // Tuş bırakıldığında işlem tekrar mümkün hale gelir
        }*/
    }

    private void TogglePauseMenu()
    {
        isPaused = !isPaused; // Durumu tersine çevir

        if (isPaused)
        {
            PauseGame(); // Oyunu duraklat
        }
        else
        {
            ResumeGame(); // Oyunu devam ettir
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Menüyü gizle
        isPaused = false; // Duraklama durumunu kapat
        Time.timeScale = 1f; // Oyunu normale döndür
        Cursor.lockState = CursorLockMode.Locked; // İmleci kilitle
        Cursor.visible = false; // İmleci görünmez yap
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); // Menüyü göster
        Time.timeScale = 0.01f; // Oyunu durdur
        Cursor.lockState = CursorLockMode.None; // İmleci serbest bırak
        Cursor.visible = true; // İmleci görünür yap
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Zamanı sıfırla
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
//UnityEngine.SceneManagement.SceneManager.LoadScene(0);