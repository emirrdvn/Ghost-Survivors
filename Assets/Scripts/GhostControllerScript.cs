using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControllerScript : MonoBehaviour
{
   /* public Transform player; // Player'in Transform referansı

    public Transform ghost;
    private Animator Anim;
    private CharacterController Ctrl;
    private Vector3 MoveDirection = Vector3.zero;
    // Cache hash values
    private static readonly int IdleState = Animator.StringToHash("Base Layer.idle");
    private static readonly int MoveState = Animator.StringToHash("Base Layer.move");
    private static readonly int SurprisedState = Animator.StringToHash("Base Layer.surprised");
    private static readonly int AttackState = Animator.StringToHash("Base Layer.attack_shift");
    private static readonly int DissolveState = Animator.StringToHash("Base Layer.dissolve");
    private static readonly int AttackTag = Animator.StringToHash("Attack");
    private float Dissolve_value = 1;
    private bool DissolveFlg = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        ghost = GameObject.Find("Enemy").transform;
        Anim = this.GetComponent<Animator>();
        Ctrl = this.GetComponent<CharacterController>();
    }

   
    void Update()
    {
        if (player != null && ghost != null)
        {
            float distance = Vector3.Distance(player.position, ghost.position); // Mesafeyi hesapla

            // Mesafeyi konsola yazdır
            Debug.Log($"Player ile nesne arasındaki mesafe: {distance}");

            // Belirli bir mesafeye göre kontrol
            if (distance < 2f)
            {
                // 
                Anim.SetTrigger("NearPlayer");
                
            }
        }
    }*/
    public Transform player; // Player'in Transform referansı
    public Transform ghost ;// Hayaletin Transform referansı
    private Animator Anim;
    private bool isPlayerNearby = false; // Oyuncunun yakında olup olmadığını kontrol eden bayrak
    private float detectionRange = 5f;  // Algılama mesafesi

    private static readonly int NearPlayerTrigger = Animator.StringToHash("NearPlayer"); // Trigger hash değeri

    void Start()
    {
        player = GameObject.Find("Player").transform;
        ghost = this.transform;
        Anim = this.GetComponent<Animator>();
        Anim.ResetTrigger("NearPlayer");
        Anim.ResetTrigger("Move");
        
    }

    void Update()
    {
        if (player != null && ghost != null)
        {
            float distance = Vector3.Distance(player.position, ghost.position); // Mesafeyi hesapla


            // Mesafeyi konsola yazdır
            Debug.Log($"Player ile nesne arasındaki mesafe: {distance}");

            // Mesafeye göre durumu kontrol et
            if (distance < detectionRange)
            {
                if (!isPlayerNearby) // Oyuncu mesafeye yeni girmişse tetikleme yap
                {
                    isPlayerNearby = true;
                    Anim.SetTrigger(NearPlayerTrigger); // Animasyonu tetikle
                }
            }
            else
            {
                if (isPlayerNearby) // Oyuncu mesafeden çıktıysa bayrağı sıfırla
                {
                    isPlayerNearby = false;
                    Anim.ResetTrigger(NearPlayerTrigger); // Trigger'ı sıfırla
                }
            }
        }
    }

}
