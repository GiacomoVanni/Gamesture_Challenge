using UnityEngine;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour {

	public float timeBeforeExpiring = 3f;
	public Text thisText;
	
	[Space]
	[SerializeField]
	private float currentTime;
	public bool isTextAlreadyShown = false;
	private UiController uiController;
	
	private void Start() {
		currentTime = timeBeforeExpiring;
		thisText = this.gameObject.GetComponent<Text>();
		
		uiController = FindObjectOfType<UiController>();
		
		uiController.OnTextButtonPressed += delegate {

			if (isTextAlreadyShown == false && thisText != null) {
				thisText.text = "Random Text!";
				isTextAlreadyShown = true;
			}
			
		};
	}

	private void Update() {

		if (isTextAlreadyShown && thisText != null) {

			currentTime -= Time.deltaTime;

			if (currentTime <= 0) {

				thisText.text = "";

				isTextAlreadyShown = false;
				currentTime = timeBeforeExpiring;
			}

		}
	}
}