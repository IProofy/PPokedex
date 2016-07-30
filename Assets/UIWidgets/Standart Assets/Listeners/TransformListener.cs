using UnityEngine;
using UnityEngine.Events;

namespace UIWidgets
{
	/// <summary>
	/// Transform listener.
	/// </summary>
	[ExecuteInEditMode]
	public class TransformListener : MonoBehaviour
	{
		/// <summary>
		/// The OnResize event.
		/// </summary>
		public UnityEvent OnTransformChanged = new UnityEvent();

		protected virtual void Update()
		{
			if (transform.hasChanged)
			{
				OnTransformChanged.Invoke();
				transform.hasChanged = false;
			}
		}

		protected virtual void OnEnable()
		{
			OnTransformChanged.Invoke();
		}

		protected virtual void OnDisable()
		{
			OnTransformChanged.Invoke();
		}
	}
}