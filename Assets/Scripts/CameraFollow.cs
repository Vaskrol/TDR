using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject ObjectToFollow;
	private Vector3 _offset;

	void Start()
	{
	
		_offset = transform.position - ObjectToFollow.transform.position;
	}
	
	void LateUpdate()
	{
		transform.position = ObjectToFollow.transform.position + _offset;
	}
	
}
