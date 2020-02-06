using System.Collections.Generic;
using UnityEngine;

public class SoundLocator : MonoBehaviour {	
	[Space,Header("Sounds")]
	public List<SoundHotspot> soundHotspots = new List<SoundHotspot>();

}
[System.Serializable]
public class SoundHotspot {

	public string audioName;
	public AudioSource audioSource;

}