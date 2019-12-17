using UnityEngine;
using System.Collections.Generic;

// In this example, we have a particle system emitting green particles; we then emit and override some properties every 2 seconds.
public class ParticleSystemController : MonoBehaviour
{
	public ParticleSystem system;

// TODO - confirm this works?
    void OnParticleCollision(GameObject other) {
		Debug.Log("on particle collision!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

		/*
        Rigidbody body = other.GetComponent<Rigidbody>();
        if (body) {
            Vector3 direction = other.transform.position - transform.position;
            direction = direction.normalized;
            body.AddForce(direction * 5);
        }
		*/
    }

    // these lists are used to contain the particles which match
    // the trigger conditions each frame.
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

    void OnParticleTrigger()
    {
        // get the particles which matched the trigger conditions this frame
        int numEnter = system.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        int numExit = system.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

        // iterate through the particles which entered the trigger and make them red
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.startColor = new Color32(255, 0, 0, 255);
            enter[i] = p;
        }

        // iterate through the particles which exited the trigger and make them green
        for (int i = 0; i < numExit; i++)
        {
            ParticleSystem.Particle p = exit[i];
            p.startColor = new Color32(0, 255, 0, 255);
            exit[i] = p;
        }

        // re-assign the modified particles back into the particle system
        system.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        system.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    }

    void Start()
    {
        // A simple particle material with no texture.
       //  Material particleMaterial = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));

        var mainModule = system.main;

			mainModule.loop = false;
			mainModule.playOnAwake = false;

system.Stop();

/*

Material particleMaterial = new Material(Shader.Find("benoculus/Reflective Transparent"));


        // Create a green particle system.
        var go = new GameObject("Particle System");
        go.transform.Rotate(-90, 0, 0); // Rotate so the system emits upwards.
        system = go.AddComponent<ParticleSystem>();
        go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
        var mainModule = system.main;
        mainModule.startColor = Color.green;
        mainModule.startSize = 0.5f;

        // Every 2 secs we will emit. */
       //  InvokeRepeating("Play", 4.0f, 2.0f);

    }


public void Play()
{
	var emissionModule = system.emission;
	emissionModule.enabled = true;

	system.Emit(1);

	// system.Play();

	// Debug.Log("play @ controlParticleSystem");
} 

void Stop()
{
	var emissionModule = system.emission;
	emissionModule.enabled = false;
}



    void DoEmit()
    {
		/*
        // Any parameters we assign in emitParams will override the current system's when we call Emit.
        // Here we will override the start color and size.
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.startColor = Color.red;
        emitParams.startSize = 0.2f;
        system.Emit(emitParams, 10);
        system.Play(); // Continue normal emissions
		*/
    }
}