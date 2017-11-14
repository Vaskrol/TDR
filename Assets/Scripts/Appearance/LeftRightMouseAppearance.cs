// LeftRightMouseAppearance.cs. 
// 
// Vpetrov. Петров Василий Александрович. 
// 
// 2017

using UnityEngine;

namespace Assets.Scripts.Appearance
{
	public class LeftRightMouseAppearance : VisualAppearance
	{
		private Facing _facing = Facing.Right;

		public override void Process(GameObject go)
		{
			var mouseAim = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (mouseAim.x < go.transform.position.x && _facing == Facing.Right)
			{
				_facing = Facing.Left;
				FlipVisual(go);
			}
			else if (mouseAim.x > go.transform.position.x && _facing == Facing.Left)
			{
				_facing = Facing.Right;
				FlipVisual(go);
			}
		}
	}
}