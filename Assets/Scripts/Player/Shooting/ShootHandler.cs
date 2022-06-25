using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHandler : MonoBehaviour
{
    [SerializeField] private KeyCode shootKey;
    private PlayerHandPickUp hand;

    private void Awake()
    {
        hand = GetComponent<PlayerHandPickUp>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            hand.GetCurrentWeapon()?.Shoot();
        }
    }
}
