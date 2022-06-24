using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHandler : MonoBehaviour
{
    [SerializeField] private KeyCode shootKey;
    private PlayerHandPickup hand;

    private void Awake()
    {
        hand = GetComponent<PlayerHandPickup>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            hand.GetCurrentWeapon()?.Shoot();
        }
    }
}
