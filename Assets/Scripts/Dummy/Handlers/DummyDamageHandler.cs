using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDamageHandler : MonoBehaviour
{
    private IgnitableObject ignitibleObject;
    private WetObject wetObject;
    private DummyHealthHandler dummyHealthHandler;

    private void Awake()
    {
        dummyHealthHandler = GetComponent<DummyHealthHandler>();
        ignitibleObject = GetComponent<IgnitableObject>();
        wetObject = GetComponent<WetObject>();
    }

    public void TakeDamage(MissileBase damageSource)
    {
        switch (damageSource.missileType)
        {
            case MissileType.Fire:
                if (ignitibleObject == null) break;

                FireMissile fireMissile = damageSource as FireMissile;
                if (wetObject?.IsWet == true)
                {
                    wetObject.WetValue -= fireMissile.dryValuePerParticle;
                    break;
                }

                ignitibleObject.TakeFireDamage(fireMissile.damagePerFireParticle);
                break;
            case MissileType.Bullet:
                float damageBooster = 1f;
                if (ignitibleObject?.IsBurning == true)
                    damageBooster = 1.5f;
                if (wetObject?.IsWet == true)
                    damageBooster = 0.5f;
                dummyHealthHandler.TakeDamage((damageSource as PistolMissile).damage * damageBooster);
                break;
            case MissileType.Water:
                if (wetObject == null) break;

                WaterMissile waterMissile = damageSource as WaterMissile;

                ignitibleObject?.StopBurning();
                wetObject.WetValue += waterMissile.wetAmount;
                break;
            default:
                break;
        }
    }
}
