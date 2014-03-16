using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GalaxyGeneration {

	private ParticleSystem galaxyParticles;
	private int starCount;
	private int? seed;
	private float size;
	private int numberOfArms;
	private float armSeperationAngle;
	private float armOffsetMax;
	public GalaxyGeneration(ParticleSystem particleSystem,
		int? seed = null,
		float size = 1,
		int starCount = 10000,
		int numberOfArms = 5,
		float armOffsetMax = 0.5f) {

		// Set fields according to parameters
		this.seed = seed;
		this.galaxyParticles = particleSystem;
		this.starCount = starCount;
		this.size = size;
		this.numberOfArms = numberOfArms;		
		this.armOffsetMax = armOffsetMax;

		// Calculate helpers
		this.armSeperationAngle = 2 * Mathf.PI / numberOfArms;
	}

	public void Generate() {
		if (seed.HasValue) {
			Random.seed = this.seed.Value;
		}
		galaxyParticles.Clear();// Remove all particles from galaxyParticles
		for (int i = 0; i < this.starCount; i++) {	// for loop for stars
			float distance = Random.value * size;	// random distance between 0 and size
			float angle = Random.value * 2 * Mathf.PI; // random angle
			float armOffset = Random.value * armOffsetMax;	// arm offset angle so it spreads out
			armOffset = armOffset - armOffsetMax / 2;
			armOffset = armOffset * (1/ distance);
			angle = ((int)(angle / armSeperationAngle)) * armSeperationAngle + armOffset;

			//Calculate position using cos and sin
			Vector3 position = new Vector3(Mathf.Cos(angle) * distance, Mathf.Sin(angle) * distance);


			// emit a particle at the position
			galaxyParticles.Emit(position, Vector3.zero, 0.1f, float.PositiveInfinity, Color.white);
		}
	}
}
