using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] public GameObject Bullet;
    [SerializeField] public Transform firepoint;
    private float fireTime;
    public float fireRate;
    private void Start()
    {
        fireTime = Time.timeSinceLevelLoad + fireRate;
    }
    private void Update()
    {
        if(Time.timeSinceLevelLoad >= fireTime)
        {
            Fire();
            fireTime = Time.timeSinceLevelLoad + fireRate;
        }
    }
    void Fire()
    {
        Instantiate(Bullet, firepoint.position, Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0, 0, 90)));
    }
}
