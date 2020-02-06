using UnityEngine;

public class SingletonStart : MonoBehaviour {

	private SoundManager soundManager;
	private void Awake() {
		
		soundManager = FindObjectOfType<SoundManager>();

		if (soundManager != null) {
			soundManager.OnStart();
		}
	}

	private void Start() {

		if (soundManager != null) {
			soundManager.OnStart();
		}
	}
}