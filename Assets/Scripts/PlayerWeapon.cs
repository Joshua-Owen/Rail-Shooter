using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 10.0f;

    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }


    void OnFire(InputValue fireButton)
    {
        isFiring = fireButton.isPressed;
    }

    void ProcessFiring()
    {
        foreach (GameObject l in lasers)
        {
            ParticleSystem.EmissionModule laser = l.GetComponent<ParticleSystem>().emission;
            laser.enabled = isFiring;
        }

    }
    void MoveCrosshair()
    {
        crosshair.transform.position = Input.mousePosition;
    }
    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);

    }

    void AimLasers()
    {
        foreach (GameObject l in lasers)
        {
            Vector3 fireDirection = targetPoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            l.transform.rotation = rotationToTarget;
        }
    }
}
