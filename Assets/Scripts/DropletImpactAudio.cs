using UnityEngine;
using System.Collections;

public class DropletImpactAudio : MonoBehaviour
{
	public AudioClip[] waterHits;
	public int playOneIn = 5;
	
	
	private ParticleSystem[] sprinklers;
	private ParticleCollisionEvent[][] collisionEvents;
	
	
	void Awake ()
	{
		sprinklers = GetComponentsInChildren<ParticleSystem>();
	}
	
	
	void Start ()
	{
		collisionEvents = new ParticleCollisionEvent[sprinklers.Length][];
	}
	
	
	void OnParticleCollision(GameObject other)
	{
		if(other.tag == "FireBarrel" || other.tag == "Barrel")
		{
			for(int i = 0; i < collisionEvents.Length; i++)
			{
				collisionEvents[i] = new ParticleCollisionEvent[sprinklers[i].GetSafeCollisionEventSize()];
			}
			
			for(int i = 0; i < collisionEvents.Length; i++)
			{
				sprinklers[i].GetCollisionEvents(gameObject, collisionEvents[i]);
			}
			
			for(int i = 0; i < collisionEvents.Length; i++)
			{
				for(int j = 0; j < collisionEvents[i].Length; j++)
				{
					int chance = Random.Range(1, playOneIn);
					if(chance == playOneIn-1)
					{
						int clipIndex = Random.Range(0, waterHits.Length);
						AudioSource.PlayClipAtPoint(waterHits[clipIndex], transform.position);
					}
				}
			}
		}
	}
}
