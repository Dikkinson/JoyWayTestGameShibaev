using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDamageHandler : MonoBehaviour
{
    private IgnitableObject ignitibleObject;
    private WetObject wetObject;
    private DummyHealthHandler dummyHealthHandler;
    private bool isIgnitable;
    private bool isWettable;
    private void Awake()
    {
        dummyHealthHandler = GetComponent<DummyHealthHandler>();
        ignitibleObject = GetComponent<IgnitableObject>();
        isIgnitable = ignitibleObject != null;
        wetObject = GetComponent<WetObject>();
        isWettable = wetObject != null;
    }
    public void TakeDamage(MissileBase damageSource)
    {
        switch (damageSource.missileType)
        {
            case MissileType.Fire:
                if (isIgnitable == false) break;

                FireMissile fireMissile = damageSource as FireMissile;
                if (isWettable == true)
                {
                    if (wetObject.IsWet == true)
                    {
                        wetObject.WetValue -= fireMissile.dryValuePerParticle;
                    }else
                    {
                        ignitibleObject.TakeFireDamage(fireMissile.damagePerFireParticle);
                    }
                }
                break;
            case MissileType.Bullet:
                float damageBooster = 1f;
                if (isIgnitable)
                    if (ignitibleObject.IsBurning)
                        damageBooster = 1.5f;
                if (isWettable)
                    if (wetObject.IsWet)
                        damageBooster = 0.5f;
                dummyHealthHandler.TakeDamage((damageSource as PistolMissile).damage * damageBooster);
                break;
            case MissileType.Water:
                if (isWettable == false) break;
                WaterMissile waterMissile = damageSource as WaterMissile;
                if (isIgnitable == true) ignitibleObject.StopBurning();
                wetObject.WetValue += waterMissile.wetAmount;
                break;
            default:
                break;
        }
    }
    public void Restore()
    {

    }
}
