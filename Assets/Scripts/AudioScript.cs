using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
   [Header("shooter")]
   [SerializeField] AudioClip shootingClip;
   [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

   [Header("damage")]
   [SerializeField] AudioClip damageClip;

   [SerializeField] [Range(0f,1f)] float damageVolume;

   public void PlayDamageClip()
   {
    if(damageClip != null)
    {
                AudioSource.PlayClipAtPoint(damageClip,Camera.main.transform.position,damageVolume);

    }
   }




   public void PlayShootingClip()
   {
    if (shootingClip != null)
    {
        AudioSource.PlayClipAtPoint(shootingClip,Camera.main.transform.position,shootingVolume);

    }
   }

    

}
