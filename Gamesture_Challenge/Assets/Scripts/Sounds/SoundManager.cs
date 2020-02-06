using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	[Space] public LevelSounds[] levelSounds;

	public bool debugMode;
    
	private string currentSceneName;

	[ReadOnly, ShowIf("debugMode")] public SoundDictionary currentSoundDictionary;

	[ReadOnly,ShowInInspector, ShowIf("debugMode")]
	private SoundLocator locator;

	#region Singleton Implementation
	
	private static SoundManager instance = null;

	public static SoundManager Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<SoundManager>();
				if (instance == null) {
					var gameObj = new GameObject(nameof(SoundManager));
					instance = gameObj.AddComponent<SoundManager>();
					DontDestroyOnLoad(gameObj);
				}
			}
			return instance;
		}
	}

	private void Start() {
		
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else {
			Destroy(gameObject);
		}

	}
	#endregion

	public void PlayClip(string soundName) {
        
		if (locator == null) return;
		
		
		var sound = currentSoundDictionary.soundCollection[soundName];
        
		foreach (var hotspot in locator.soundHotspots) {

			if (hotspot.audioName == soundName) {
				hotspot.audioSource.clip = sound.clip;
				if (sound.haveToLoop) {
					hotspot.audioSource.loop = true;
				}

				if (sound.haveSpecificVolume) {
					hotspot.audioSource.volume = sound.volume;
				}                
				hotspot.audioSource.Play();
			}
		}
	}

	public void PlayRandomClip(AudioSource source) {
		
		if (locator == null) return;

		int randomValue = Random.Range(0, currentSoundDictionary.soundCollection.Count);
		
		var stringNames = new List<string>();

		foreach (KeyValuePair<string, Sound> sound in currentSoundDictionary.soundCollection) {
			stringNames.Add(sound.Key);
		}

		Sound soundToPlay = currentSoundDictionary.soundCollection[stringNames[randomValue]];
		
		source.clip = soundToPlay.clip;
		source.Play();

	}
	public void OnStart() {

		locator = FindObjectOfType<SoundLocator>();
		currentSceneName = SceneManager.GetActiveScene().name;
		foreach (var levelSound in levelSounds) {
			if (levelSound.sceneName == currentSceneName) {
				currentSoundDictionary = levelSound.soundDictionary;
			}
		}
	}
}

[System.Serializable]
public struct LevelSounds {
	
	public string sceneName;
	public SoundDictionary soundDictionary;

}