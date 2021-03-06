﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    public AudioClip PickupSound;

    void OnTriggerEnter(Collider Col)
    {
        if(Col.GetComponent<PlayerController>() != null)
        {
            if(GameObject.FindWithTag("Gun").GetComponent<Shoot>().AddAmmo())
            {
                GameObject Sound = new GameObject();
                Sound.transform.position = this.transform.position;
                Despawn DSpawn = Sound.AddComponent(typeof(Despawn)) as Despawn;
                DSpawn.DespawnTime = 1f;
                AudioSource AS = Sound.AddComponent(typeof(AudioSource)) as AudioSource;
                AS.spatialBlend = 1f;
                AS.volume = 0.5f;
                AS.clip = PickupSound;
                AS.Play();

                Destroy(this.gameObject);
            }
        }
    }
    
}
