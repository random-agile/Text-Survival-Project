using UnityEngine;

public class RotationLock : MonoBehaviour
{
    void Update()
    {
	    var rotation = Quaternion.LookRotation(Vector3.up , Vector3.forward);
	    transform.rotation = rotation;
    }
}
