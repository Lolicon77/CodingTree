using UnityEngine;


namespace L7 {
	public class DontDestroyThis : MonoBehaviour {

		void Awake() {
			DontDestroyOnLoad(gameObject);
		}

	}
}
