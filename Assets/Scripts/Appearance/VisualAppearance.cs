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
		public abstract void Process(GameObject go);

		// Flips SpriteRenderer component of gameobject by X axis
		protected void FlipVisual(GameObject go)
		{
			go.GetComponent<SpriteRenderer>().flipX =
				!go.GetComponent<SpriteRenderer>().flipX;

			// If this object in the root (has no relative coords), e.g. Player 
			if (go.transform.root == go.transform)
				return;

			go.transform.localPosition =
			new Vector3(
				-go.transform.localPosition.x,
				go.transform.localPosition.y,
				go.transform.localPosition.z);
		}

		protected enum Facing
		{
			Left,
			Right
		}

	}
}