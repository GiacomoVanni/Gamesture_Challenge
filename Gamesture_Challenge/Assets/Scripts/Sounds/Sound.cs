using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Create/Sound", fileName = "new_Sound")]
public class Sound : ScriptableObject {

	public AudioClip clip;
	public bool haveToLoop, haveSpecificVolume;
	
	[Space,ShowIf("haveSpecificVolume"),Range(0,1)]
	public float volume;
}