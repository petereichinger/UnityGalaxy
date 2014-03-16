using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GalaxyGeneration {

	private ParticleSystem galaxyParticles;
	private int starCount;
	private int? seed;
	private float size;
	public GalaxyGeneration(ParticleSystem particleSystem, int starCount, float size, int? seed = null) {
		this.seed = seed;
		this.galaxyParticles = particleSystem;
		this.starCount = starCount;
		this.size = size;
	}

	public void Generate() {
		if (seed.HasValue) {
			Random.seed = this.seed.Value;
		}
		galaxyParticles.Clear();// Remove all particles from galaxyParticles
		for (int i = 0; i < this.starCount; i++) {
			float distance = Random.value * size;
			float angle = Random.value * 2 * Mathf.PI;

			Vector3 position = new Vector3(Mathf.Cos(angle) * distance, Mathf.Sin(angle) * distance);

			galaxyParticles.Emit(position, Vector3.zero, 0.1f, float.PositiveInfinity, Color.white);
		}
	}
}
