using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public Transform camTransform;

	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos;
	Quaternion originalRot;
	public bool isShakeEnabled = true;
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
		//originalRot = camTransform.localRotation;
	}

	void Update()
	{
		if (isShakeEnabled)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			//camTransform.localRotation = originalRot  Random.rotationUniform * shakeAmount;

			
		}
		else
		{
			camTransform.localPosition = originalPos;
			//camTransform.localRotation = originalRot;
		}
	}
}
