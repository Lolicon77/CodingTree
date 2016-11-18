namespace UnityEngine{
	
	
	public static class TransformExtensionMethods {

		/// <summary>
		/// 深度查找子节点，可以找到隐藏物体
		/// Transform中的API只能查找第一层节点,使用该方法可以深度查找
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="name"></param>
		/// <returns>第一个名称为name的Transform</returns>
		public static Transform FindRecursion(this Transform transform, string name)
		{
			Transform result = null;
			foreach (Transform child in transform)
			{
				if (child.name == name)
				{
					result = child;
					break;
				}
				result = child.FindRecursion(name);
				if (result) {
					break;
				}
			}
			return result;
		}


		public static void SetPositionX(this Transform transform, float x) {
			transform.position = new Vector3(x, transform.position.y, transform.position.z);
		}


		public static void SetPositionY(this Transform transform, float y) {
			transform.position = new Vector3(transform.position.x, y, transform.position.z);
		}


		public static void SetPositionZ(this Transform transform, float z) {
			transform.position = new Vector3(transform.position.x, transform.position.y, z);
		}


		public static void SetLocalPositionX(this Transform transform, float x) {
			transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
		}


		public static void SetLocalPositionY(this Transform transform, float y) {
			transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
		}


		public static void SetLocalPositionZ(this Transform transform, float z) {
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
		}


		public static void SetLocalEulerAngleX(this Transform transform, float x) {
			transform.localEulerAngles = new Vector3(x, transform.localEulerAngles.y, transform.localEulerAngles.z);
		}


		public static void SetLocalEulerAngleY(this Transform transform, float y) {
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, y, transform.localEulerAngles.z);
		}


		public static void SetLocalEulerAngleZ(this Transform transform, float z) {
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, z);
		}


		public static void SetEulerAngleX(this Transform transform, float x) {
			transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, transform.eulerAngles.z);
		}


		public static void SetEulerAngleY(this Transform transform, float y) {
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, y, transform.eulerAngles.z);
		}


		public static void SetEulerAngleZ(this Transform transform, float z) {
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, z);
		}


		public static void SetUniformLocalScale(this Transform transform, float uniformScale) {
			transform.localScale = Vector3.one * uniformScale;
		}


		public static Vector2 ScreenPos(this Transform transform) {
			Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
			return (new Vector2(screenPos.x, screenPos.y));
		}


		public static Vector2 ScreenPosRate(this Transform transform) {
			Vector2 screenPos = transform.ScreenPos();
			Vector2 rate = new Vector2(screenPos.x / (float)Screen.width, screenPos.y / (float)Screen.height);
			return rate;
		}



		public static void SetRectAnchors(this RectTransform rect, float x = 0.5f, float y = 1f) {
			rect.anchorMax = new Vector2(x, y);
			rect.anchorMin = new Vector2(x, y);
		}


		public static void SetRectAnchors(this RectTransform rect, Vector2 anchor) {
			rect.anchorMax = anchor;
			rect.anchorMin = anchor;
			rect.pivot = anchor;
		}


		public static void SetRectAnchors(this RectTransform rect, Vector2 min, Vector2 max, Vector2 pivot) {
			rect.anchorMin = min;
			rect.anchorMax = max;
			rect.pivot = pivot;
		}


		public static void SetParentAndResetArgs(this Transform transform, Transform parent) {
			transform.SetParent(parent);
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
		}
		
		public static void SmoothSetLocalEulerAngleX(this Transform transform, float angle, float interpolation) {
			transform.localEulerAngles = new Vector3( Mathf.LerpAngle(transform.localEulerAngles.x, angle, interpolation), transform.localEulerAngles.y,transform.localEulerAngles.z);
		}
		
		public static void SmoothSetLocalEulerAngleY(this Transform transform, float angle, float interpolation) {
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.LerpAngle(transform.localEulerAngles.y, angle, interpolation), transform.localEulerAngles.z);
		}
		
		public static void SmoothSetLocalEulerAngleZ(this Transform transform, float angle, float interpolation) {
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, Mathf.LerpAngle(transform.localEulerAngles.z, angle, interpolation));
		}


		public static void SmoothSetLocalEulerAngle(this Transform transform, Vector3 eularAngle, float interpolation) {
			transform.SmoothSetLocalEulerAngleX(eularAngle.x, interpolation);
			transform.SmoothSetLocalEulerAngleY(eularAngle.y, interpolation);
			transform.SmoothSetLocalEulerAngleZ(eularAngle.z, interpolation);	
		}


	}	
}

