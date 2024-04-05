using System.Collections;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
	[SerializeField] private GameObject _arrowPoint;
	[SerializeField] private GameObject _roulette;

	private bool _isArrowRotating;

	private void FixedUpdate()
	{
		if (_roulette.GetComponent<Roulette>().IsWheelOfFortuneEnabled && (_roulette.transform.eulerAngles.z + 9) % 20 < 5 && !_isArrowRotating)
			StartCoroutine(ArrowPointCoroutine());
	}

	private IEnumerator ArrowPointCoroutine()
	{
		_isArrowRotating = true;

		var angularVelocity = _roulette.GetComponent<Rigidbody2D>().angularVelocity;
		int arrowRotateRange = Mathf.Max(Mathf.RoundToInt(Mathf.Abs(angularVelocity / 100)), 4);
		int rotateStep = 3;
		float rotateTime = 0.25f;

		for (int i = 0; i < arrowRotateRange; i++)
		{
			_arrowPoint.transform.Rotate(0, 0, rotateStep);
			yield return new WaitForSeconds(rotateTime / arrowRotateRange);
		}

		for (int i = 0; i < arrowRotateRange; i++)
		{
			_arrowPoint.transform.Rotate(0, 0, -rotateStep);
			yield return new WaitForSeconds(rotateTime / arrowRotateRange);
		}

		_isArrowRotating = false;
	}
}
