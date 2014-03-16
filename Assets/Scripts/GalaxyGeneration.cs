using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GalaxyGeneration {

	private ParticleSystem galaxyParticles;
	private int starCount;
	private int? seed;
	private float galaxySize;
	private int numberOfArms;
	private float armSeperationAngle;
	private float armOffsetMax;
	private float rotationFactor;
	private float randomOffsetXY;
	public GalaxyGeneration(ParticleSystem particleSystem,
		int? seed = null,
		float galaxySize = 1,
		int starCount = 10000,
		int numberOfArms = 5,
		float armOffsetMax = 1f,
		float rotationFactor = 5f,
		float randomOffsetXY = 0.02f) {

		// Set fields according to parameters
		this.seed = seed;
		this.galaxyParticles = particleSystem;
		this.starCount = starCount;
		this.galaxySize = galaxySize;
		this.numberOfArms = numberOfArms;
		this.armOffsetMax = armOffsetMax;
		this.rotationFactor = rotationFactor;
		this.randomOffsetXY = randomOffsetXY;
		// Calculate helpers
		this.armSeperationAngle = 2 * Mathf.PI / this.numberOfArms;
	}

	public void Generate() {
		if (seed.HasValue) {
			Random.seed = this.seed.Value;
		}
		galaxyParticles.Clear();// Remove all particles from galaxyParticles
		for (int i = 0; i < this.starCount; i++) {	// for loop for stars
			float distance = Random.value;	// random distance between 0 and size
			float angle = Random.value * 2 * Mathf.PI; // random angle

			// Calculate arm offset
			float armOffset = Random.value * this.armOffsetMax;	// arm offset angle so it spreads out
			armOffset = armOffset - armOffsetMax / 2;
			armOffset = armOffset * (1 / distance);

			float squaredArmOffset = Mathf.Pow(armOffset, 2);
			if (armOffset < 0)
				squaredArmOffset = squaredArmOffset * -1;
			armOffset = squaredArmOffset;

			// Calculate additional rotation so outer stars are rotated more
			float rotation = distance * rotationFactor;

			//Calculate final angle
			angle = ((int)(angle / this.armSeperationAngle)) * this.armSeperationAngle + armOffset + rotation;


			//Calculate position using cos and sin

			float starX = Mathf.Cos(angle) * distance;
			float starY = Mathf.Sin(angle) * distance;
			float randomOffsetX = Random.value * randomOffsetXY;
			float randomOffsetY = Random.value * randomOffsetXY;

			starX += randomOffsetX;
			starY += randomOffsetY;



			Vector3 position = this.galaxySize * new Vector3(starX, starY);


			// emit a particle at the position
			galaxyParticles.Emit(position, Vector3.zero, 0.05f * galaxySize, float.PositiveInfinity, Color.white);
		}
	}
}
