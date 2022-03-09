using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowTargetRotate : MonoBehaviour
{
    public Transform targetTransform;
    public Transform selfTransform;
    public bool isPlayer;

    public float offset;

    Mouse mouse => Mouse.current;
    Camera cam;
    private void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        FollowTarget();
    }
    void FollowTarget()
    {
        if (isPlayer) { FollowPlayer(); return; }
        Vector2 directionFromSelfToTarget = (targetTransform.position - selfTransform.position).normalized;
        transform.position = offset * (Vector3)directionFromSelfToTarget + selfTransform.position;
        transform.rotation = Quaternion.Euler(Quaternion.LookRotation(transform.forward, directionFromSelfToTarget).eulerAngles + new Vector3(0, 0, 90));
    }
    void FollowPlayer()
    {
        if (transform.localScale.y > transform.localScale.x)
        { offset = transform.localScale.y / 2f + 0.5f; }
        else { offset = transform.localScale.x / 2f + 0.5f; }
        Vector3 playerScreenPosition = cam.WorldToScreenPoint(selfTransform.position);
        Vector2 directionFromPlayerToMouse = (mouse.position.ReadValue() - (Vector2)playerScreenPosition).normalized;
        transform.position = offset * (Vector3)directionFromPlayerToMouse + selfTransform.position;
        transform.rotation = Quaternion.Euler(Quaternion.LookRotation(transform.forward, directionFromPlayerToMouse).eulerAngles + new Vector3(0, 0, 90));
    }
}
