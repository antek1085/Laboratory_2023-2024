using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimationPlantControler : MonoBehaviour
{
    private readonly int firstPhase = Animator.StringToHash("FirstPhase");
    private readonly int secondPhase = Animator.StringToHash("SecondPhase");
    private readonly int thirdPhase = Animator.StringToHash("ThirdPhase");
    
    private Animator _animator;

    private float timer;

    [SerializeField] private GameObject itemToSpawn;
    private BoxCollider _boxCollider;
    private int timerInt;

    [Header("Timers/Need to change in code switch statement")] 
    [SerializeField] int firstPhaseTimer;
    [SerializeField] int secondPhaseTimer;
    [SerializeField] int thirdPhaseTimer;

    private void Awake()
    {
       _animator = GetComponent<Animator>();
       _boxCollider = this.GetComponent<BoxCollider>();
       _boxCollider.isTrigger = false;
    }

    void Update()
    {
        if (timerInt == firstPhaseTimer || timerInt == secondPhaseTimer || timerInt == thirdPhaseTimer)
        {
            SwitchAnimation();
        }

        if (timer < thirdPhaseTimer + 10)
        {
            timer += Time.deltaTime;
            timerInt = (int)timer;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            Instantiate(itemToSpawn, this.transform);
            timer = 0;
            _animator.SetBool(thirdPhase, false);
            _boxCollider.isTrigger = false;
        }
    }

    void SwitchAnimation()
    {
        switch (timerInt)
        {
            case < 5:
                _animator.GetBool(firstPhase);
                _animator.SetBool(firstPhase, true);
                break;
            case >= 5 and < 10:
                _animator.SetBool(firstPhase, false);
                _animator.GetBool(secondPhase);
                _animator.SetBool(secondPhase, true);
                break;
            case >= 10:
                _animator.SetBool(secondPhase, false);
                _animator.GetBool(thirdPhase);
                _animator.SetBool(thirdPhase, true);
                _boxCollider.isTrigger = true;
                break;
        }
    }
}
