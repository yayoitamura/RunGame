using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public GameObject particlePrefab;

    void Start () { }

    void Update () { }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            ParticleSystem particle = Instantiate (particlePrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem> ();
            particle.Play ();
            Destroy (gameObject);
            ParticleSystem.MainModule mainModule = particle.main;
            Destroy (particle.gameObject, mainModule.duration);
        }
    }
}