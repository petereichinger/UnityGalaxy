using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GalaxyGeneratorComponent : MonoBehaviour {
	public ParticleSystem galaxyParticleSystem;
	public int numberOfStars;
	public bool useSeed;
	public int seed;
	public float size;
	public void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			int? seedToUse = useSeed ? (int?)seed : null;

			GalaxyGeneration galGen = new GalaxyGeneration(galaxyParticleSystem, numberOfStars, size, seedToUse);

			galGen.Generate();
		}
	}


}
