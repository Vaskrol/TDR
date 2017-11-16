// IVisualAppearance.cs. 
// 
// Vpetrov. Петров Василий Александрович. 
// 
// 2017

using UnityEngine;

namespace Assets.Scripts.Appearance
{
	public abstract class VisualAppearance
	{
		public Facing CurrentFacing = Facing.Right;

		public abstract void Process(GameObject go);

		// Flips SpriteRenderer component of gameobject by X axis
		protected void FlipVisual(GameObject go)
		{
			// Flip horizontally
			go.transform.localScale = Vector3.Scale(go.transform.localScale, new Vector3(-1, 1f, 1f));

			if (go.transform.root == go.transform)
				return;

			// Invert child objects local X position 
			go.transform.localPosition = Vector3.Scale(go.transform.localPosition, new Vector3(-1, 1f, 1f));
		}

		public enum Facing
		{
			Left,
			Right
		}

	}
}