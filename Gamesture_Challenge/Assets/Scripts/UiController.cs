using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class UiController : MonoBehaviour {

	#region Public Variables

	public string buttonClick = "ButtonClick";
	public AudioSource audioSourceForRandomSounds;
	#endregion
	#region Private Variables

	public GameObject TextPrefab;
		
	private Animator popupAnimator;	
	private Text closeButtonText;
	private bool isPopUpActive = false;
	
	[SerializeField]
	private Text RandomText;

	public event Action OnTextButtonPressed;
	
	#endregion
	
	public void HandlePopUp(GameObject button) {

		//Memory optimization
		
		if (popupAnimator == null) {
			popupAnimator = button.gameObject.GetComponent<Animator>();
		}
		if (closeButtonText == null) {
			closeButtonText = button.GetComponentInChildren<Text>();
		}
		
		
		if (isPopUpActive == false) {
			popupAnimator.SetTrigger("Popped");
			closeButtonText.text = "Close Popup!";
			isPopUpActive = true;
		}
		else {
			popupAnimator.SetTrigger("Closed");
			closeButtonText.text = "Open Popup!";
			isPopUpActive = false;
		}
		
		SoundManager.Instance.PlayClip(buttonClick);
	}


	public void GenerateRandomText() {

		if (RandomText == null && TextPrefab != null) {
			var textPrefab = Instantiate(TextPrefab, this.transform);
			RandomText = textPrefab.GetComponent<Text>();
		}

		if (RandomText != null) {

			StartCoroutine(EventDrawCall());	

		}
		
		SoundManager.Instance.PlayClip(buttonClick);

	}

	public void PlayRandomSound() {

		SoundManager.Instance.PlayClip(buttonClick);

		if (audioSourceForRandomSounds != null) {
			StartCoroutine(StartSoundAfterButton());
		}

	}

	private IEnumerator EventDrawCall() {
		yield return  new WaitForSeconds(0.01f);
		OnTextButtonPressed?.Invoke();
	}

	private IEnumerator StartSoundAfterButton() {
		yield return  new WaitForSeconds(0.3f);
		SoundManager.Instance.PlayRandomClip(audioSourceForRandomSounds);
	}
}