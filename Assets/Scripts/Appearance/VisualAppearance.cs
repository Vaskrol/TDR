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
			go.GetComponent<SpriteRenderer>().flipX =
				!go.GetComponent<SpriteRenderer>().flipX;

			// If this object in the root (has no relative coords), e.g. Player 
			if (go.transform.root == go.transform)
				return;

			var newPos = Vector3.Scale(go.transform.localPosition, new Vector3(-1, 1f, 1f));
			go.transform.localPosition = newPos;
		}

		public enum Facing
		{
			Left,
			Right
		}

	}
}