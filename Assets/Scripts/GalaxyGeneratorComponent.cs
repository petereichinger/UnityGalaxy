﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
///  Component that starts the galaxy generation.
/// </summary>
public class GalaxyGeneratorComponent : MonoBehaviour {
	public MeshRenderer galaxyRenderer;

	public bool useSeed;
	public int seed;
	public int numberOfStars;
	public int galaxyResolution;
	public int numberOfArms;
	public float swirlAmount;
	public Gradient starColorGradient;
	public void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			int? seedToUse = useSeed ? (int?)seed : null;

			GalaxyGeneration galGen = new GalaxyGeneration(galaxyRenderer.material, seed: seedToUse, galaxySize: galaxyResolution, starCount: numberOfStars, numberOfArms: numberOfArms, rotationFactor: swirlAmount, colorGradient: starColorGradient);

			galGen.Generate();
		}
	}


}
