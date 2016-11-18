using UnityEngine;

namespace L7
{

	/// <summary>
	/// Be aware this will not prevent a non singleton constructor
	///   such as `T myT = new T();`
	/// To prevent that, add `protected T () {}` to your singleton class.
	/// </summary>
	public abstract class SingletonForMonoInstantiateOnAwake<T> : MonoBehaviour where T : SingletonForMonoInstantiateOnAwake<T> {

		protected static T _instance;

		public static T Instance {
			get {
				return _instance;
			}
		}

		protected virtual void Awake(){
			_instance = (T)this;
		}

		protected virtual void OnDestroy() {
			_instance = null;
		}
	}

}
