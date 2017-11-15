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
		public override void Process(GameObject go)
		{
			var mouseAim = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (mouseAim.x < go.transform.position.x && CurrentFacing == Facing.Right)
			{
				CurrentFacing = Facing.Left;
				FlipVisual(go);
			}
			else if (mouseAim.x > go.transform.position.x && CurrentFacing == Facing.Left)
			{
				CurrentFacing = Facing.Right;
				FlipVisual(go);
			}
		}
	}
}