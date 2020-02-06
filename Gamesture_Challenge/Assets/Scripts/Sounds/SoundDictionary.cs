using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
[CreateAssetMenu(menuName = "Create/SoundCollection", fileName = "new_SoundCollection")]
public class SoundDictionary : SerializedScriptableObject {

	public Dictionary<string, Sound> soundCollection;

}
