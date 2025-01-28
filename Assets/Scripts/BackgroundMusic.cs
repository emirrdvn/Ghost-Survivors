using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    /*[SerializeField] private AudioMixer masterMixer;
    [SerializeField]
    private Slider soundSlider;
    // Start is called before the first frame update
    
    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 0.5f));
    }

    public void SetVolume(float _value)
    {
        if(_value <1)
        {
            _value = 0.001f;
        }
        RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value/100) * 20);

    }
    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }
    public void RefreshSlider(float _value)
    {
        soundSlider.value = _value;
    }
    private static BackgroundMusic instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/


    /*[SerializeField] private AudioMixer masterMixer; // Master AudioMixer
    [SerializeField] private Slider soundSlider; // Ses kaydırma çubuğu

    private static BackgroundMusic instance;

    private void Awake()
    {
        // Singleton yapısı
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Sahne geçişlerinde yok olmasın
        }
        else
        {
            Destroy(gameObject); // Zaten varsa, yok et
        }
    }

    private void Start()
    {
        // Kaydedilen ses seviyesini yükle
        InitializeVolume();
    }

    private void InitializeVolume()
    {
        if (soundSlider != null)
        {
            // Kaydedilen ses seviyesini al
            float savedVolume = PlayerPrefs.GetFloat("SavedMasterVolume", 0.5f);
            SetVolume(savedVolume); // Ses seviyesini uygula
            RefreshSlider(savedVolume); // Slider'ı güncelle

            // Slider'ın olaylarını bağla
            soundSlider.onValueChanged.AddListener(SetVolumeFromSlider);
        }
        else
        {
            Debug.LogWarning("SoundSlider bağlı değil!");
        }
    }

    public void SetVolume(float value)
    {
        if (value < 0.01f)
        {
            value = 0.001f; // Minimum ses seviyesi
        }

        PlayerPrefs.SetFloat("SavedMasterVolume", value); // Kaydet
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(value / 100) * 20); // Ses seviyesini uygula
        RefreshSlider(value); // Slider'ı güncelle
    }

    public void SetVolumeFromSlider(float value)
    {
        SetVolume(value); // Slider'dan gelen değeri uygula
    }

    private void RefreshSlider(float value)
    {
        if (soundSlider != null)
        {
            soundSlider.value = value; // Slider değerini güncelle
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        // Sahne değişimlerinde slider'ı yeniden başlat
        InitializeVolume();
    }

    private void OnDestroy()
    {
        // Slider olaylarını temizle
        if (soundSlider != null)
        {
            soundSlider.onValueChanged.RemoveAllListeners();
        }
    }*/

    [SerializeField] private AudioMixer masterMixer; // Master AudioMixer
    [SerializeField] private string sliderTag = "SoundSlider"; // Slider'ı bulmak için kullanılacak tag
    private Slider soundSlider; // Dinamik olarak atanacak slider referansı

    private static BackgroundMusic instance;

    private void Awake()
    {
        // Singleton yapısı
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Sahne geçişlerinde yok olmasın
        }
        else
        {
            Destroy(gameObject); // Zaten varsa, yok et
        }
    }

    private void OnEnable()
    {
        // Sahne yüklendikten sonra işlemi dinle
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Sahne yüklendiğinde yapılan işlemi bırak
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        // İlk başlatmada ses seviyesini yükle
        float savedVolume = PlayerPrefs.GetFloat("SavedMasterVolume", 0.5f);
        SetVolume(savedVolume);
    }

    private void InitializeSlider()
    {
        // Sahnedeki slider'ı bul
        GameObject sliderObject = GameObject.FindGameObjectWithTag(sliderTag);
        if (sliderObject != null)
        {
            soundSlider = sliderObject.GetComponent<Slider>();
            if (soundSlider != null)
            {
                float savedVolume = PlayerPrefs.GetFloat("SavedMasterVolume", 0.5f);
                soundSlider.value = savedVolume; // Slider değerini ayarla
                soundSlider.onValueChanged.RemoveAllListeners(); // Eski dinleyicileri kaldır
                soundSlider.onValueChanged.AddListener(SetVolumeFromSlider); // Yeni dinleyiciyi ekle
            }
        }
        else
        {
            Debug.LogWarning($"'{sliderTag}' tag'ine sahip bir Slider bulunamadı! Lütfen sahnede bir Slider'a bu tag'i ekleyin.");
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Yeni sahne yüklendiğinde slider referansını yenile
        InitializeSlider();
    }

    public void SetVolume(float value)
    {
        if (value < 0.01f)
        {
            value = 0.001f; // Minimum ses seviyesi
        }

        PlayerPrefs.SetFloat("SavedMasterVolume", value); // Kaydedilen değeri güncelle
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(value / 100) * 20); // Ses seviyesini ayarla

        if (soundSlider != null)
        {
            soundSlider.value = value; // Slider'ı güncelle
        }
    }

    public void SetVolumeFromSlider(float value)
    {
        SetVolume(value); // Slider'dan gelen değeri uygula
    }
    
    
}
