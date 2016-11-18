using System;
using UnityEngine;
using System.Collections;


namespace L7 {
	public class UpdatePerInterval : MonoBehaviour {


		private float interval;
		private Action onUpdatePerInterval;


		private float timer;


		public static void AddUpdatePerIntervalComponent(GameObject go, float interval, Action onUpdatePerInterval) {
			var component = go.AddComponent<UpdatePerInterval>();
			component.interval = interval;
			component.onUpdatePerInterval = onUpdatePerInterval;
		}


		void Start() {
			timer = Time.time;
		}


		void Update() {
			if (Time.time - timer > interval) {
				timer = Time.time;
				onUpdatePerInterval();
			}
		}
	}
}
