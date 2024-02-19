using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVarience = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    [HideInInspector] public bool isFiring;
     Coroutine firingCoroutine;
    AudioScript audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioScript>();
    }
     
    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    
    void Update()
    {
        Fire();
    }

    void Fire()
    {   
        if(isFiring && firingCoroutine == null)
        {
        firingCoroutine = StartCoroutine(FireContinuously());

        }
        else if(!isFiring && firingCoroutine != null){
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }

    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab,transform.position,
            Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance,projectileLifeTime);

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVarience,
            baseFiringRate +firingRateVarience);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile,minimumFiringRate,float.MaxValue);

            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(timeToNextProjectile);
        }

    }
}
