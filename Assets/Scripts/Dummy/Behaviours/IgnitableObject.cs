using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnitableObject : MonoBehaviour
{
    [SerializeField] private bool canCatchFire;
    [SerializeField] private Color burningObjectColor;
    [SerializeField] private BurningParticleController flameParticle;
    [SerializeField] private float damagePerSecondBurning = 5f;
    [SerializeField] private float burnDuration = 10f;
    
    private DummyView dummyView;
    private DummyHealthHandler dummyHealthHandler;

    private const float TIME_BETWEEN_FIRE_TICK = 1f;
    private float nextTimeFireTick;
    private float burnEndTime;

    private bool _isBurning = false;

    public bool IsBurning 
    {
        get => _isBurning;
        private set
        {
            _isBurning = value;
            if (_isBurning)
            {
                dummyView.ChangeColor(burningObjectColor);
                flameParticle.PlayFireParticle(burnDuration);
            }
            else
            {
                flameParticle.StopBurningParticle();
                dummyView.ResetColor();
            }
        }
    }

    private void Awake()
    {
        dummyHealthHandler = GetComponent<DummyHealthHandler>();
        dummyView = GetComponent<DummyView>();
    }

    public void TakeFireDamage(float baseDamage)
    {
        dummyHealthHandler.TakeDamage(baseDamage);
        if (canCatchFire == true)
        {
            burnEndTime = Time.time + burnDuration;
            IsBurning = true;
        }
    }

    public void StopBurning()
    {
        IsBurning = false;
    }

    private void Update()
    {
        if (IsBurning && Time.time >= nextTimeFireTick)
        {
            if (Time.time <= burnEndTime)
            {
                nextTimeFireTick = Time.time + TIME_BETWEEN_FIRE_TICK;
                dummyHealthHandler.TakeDamage(damagePerSecondBurning);
            }
            else
            {
                StopBurning();
            }
        }
    }
}
