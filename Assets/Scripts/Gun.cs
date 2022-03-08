using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Gun : MonoBehaviour
{
    Mouse mouse => Mouse.current;
    Camera cam;
    [SerializeField] public Transform playerTransform;
    [SerializeField] public Transform firepoint;
    [SerializeField] public Bullet bullet;
    public float distance;

    private void Awake()
    {
        cam = Camera.main;
        
    }
    private void Update()
    {
        
        FollowPlayer();   
    }
    void FollowPlayer()
    {
        Vector3 playerScreenPosition = cam.WorldToScreenPoint(playerTransform.position);
        Vector2 directionFromPlayerToMouse = (mouse.position.ReadValue() - (Vector2)playerScreenPosition).normalized;
        transform.position = distance * (Vector3)directionFromPlayerToMouse + playerTransform.position;
        transform.rotation = Quaternion.Euler(Quaternion.LookRotation(transform.forward, directionFromPlayerToMouse).eulerAngles + new Vector3(0,0,90));
    }
    public void Fire(CallbackContext context)
    {
        if (!context.performed) return;
        Instantiate(bullet, firepoint.position, Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0, 0, 90)));

    }

}
