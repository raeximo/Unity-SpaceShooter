    using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour
{   
    [SerializeField] bool isPlayer;
   [SerializeField] int health = 50;

   [SerializeField] int score = 50;
   [SerializeField] ParticleSystem hitEffect;
    
    [SerializeField] bool applyCamerShake;
    CameraShake cameraShake;

    [SerializeField] bool applyDamageClip;
    AudioScript audioPlayer;

    ScoreKeeper scoreKeeper;

    LevelManager levelManager;

    

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioScript>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }
   void OnTriggerEnter2D(Collider2D other) 
   {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            PlayDamageClip();

            damageDealer.Hit();
        }
   }
   public int GetHealth()
   {
        return health;
   }
    void TakeDamage(int damage)
    {
         health -= damage;
        
       if(health <= 0)
       {
        Die();

       }
      

    }
    void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
        else{
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, quaternion.identity);
            Destroy(instance.gameObject,instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    
    void ShakeCamera()
    {
        if(cameraShake!=null && applyCamerShake)
        {
            cameraShake.play();
        }
    }

    void PlayDamageClip()
    {
        if(applyDamageClip)
        {
            audioPlayer.PlayDamageClip();
        }
    }
}
