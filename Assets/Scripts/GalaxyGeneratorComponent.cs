using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GalaxyGeneratorComponent : MonoBehaviour {
	public ParticleSystem galaxyParticleSystem;

	public bool useSeed;
	public int seed;
	public int numberOfStars;
	public float galaxySize;
	public int numberOfArms;
	public float swirlAmount;
	public void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			int? seedToUse = useSeed ? (int?)seed : null;

			GalaxyGeneration galGen = new GalaxyGeneration(galaxyParticleSystem, seed: seedToUse, galaxySize: galaxySize, starCount: numberOfStars, numberOfArms: numberOfArms,rotationFactor: swirlAmount);

			galGen.Generate();
		}
	}


}
