using UnityEngine;


namespace L7
{
	public class StaticBatchThis : MonoBehaviour {

		void Start() {
			StopWatchUtil.QuickStart(()=> StaticBatchingUtility.Combine(gameObject),1,"static batch");
		}

	}
}
