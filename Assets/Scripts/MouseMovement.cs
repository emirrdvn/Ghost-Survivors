using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSC : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = 90f;
    public float bottomClamp = -90f;

    PauseScript pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        // Hide and lock the cursor
        pauseMenuUI = GameObject.Find("GameManager").GetComponent<PauseScript>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenuUI.isPaused)
        {
            return;
        }
        // Get the mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, bottomClamp, topClamp);
        yRotation += mouseX;

        // Rotation to Player
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
