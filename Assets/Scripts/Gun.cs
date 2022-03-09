using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Gun : MonoBehaviour
{
    [SerializeField] public Transform firepoint;
    [SerializeField] public Bullet bullet;
    public void Fire(CallbackContext context)
    {
        if (!context.performed) return;
        Instantiate(bullet, firepoint.position, Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0, 0, 90)));
    }

}
