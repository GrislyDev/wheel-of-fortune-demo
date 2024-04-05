using UnityEngine;
using System;

public class Roulette : MonoBehaviour
{
	public bool IsWheelOfFortuneEnabled => _isWheelOfFortuneEnabled;

	[SerializeField] private float _minRotatePower;
	[SerializeField] private float _maxRotatePower;
	[SerializeField, Range(0,10)] private float _stopPower;
	[SerializeField] private int[] _sectorCoinsReward;
	[SerializeField] private RewardManager _rewardManager;

	private Rigidbody2D _rbody;
	private bool _isWheelOfFortuneEnabled;
	

	#region UNITY_ENGINE
	private void Start()
	{
		_rbody = GetComponent<Rigidbody2D>();
	}
	private void FixedUpdate()
	{
		CheckWheelOfFortuneState();
		CheckReward();
		StopWheelIfNeeded();
	}
	#endregion
	#region PUBLIC_METHODS
	public void Spin()
	{
		if (!_isWheelOfFortuneEnabled)
		{
			_rbody.AddTorque(UnityEngine.Random.Range(-_minRotatePower,-_maxRotatePower));
			_rbody.angularDrag = _stopPower;
		}
	}
	#endregion
	#region PRIVATE_METHODS
	private void CheckReward()
	{
		if (_isWheelOfFortuneEnabled && _rbody.angularVelocity == 0)
		{
			_rewardManager.DistributeReward(_sectorCoinsReward, transform.eulerAngles.z);
			_isWheelOfFortuneEnabled = false;
			
		}
	}
	private void StopWheelIfNeeded()
	{
		if (_rbody.angularVelocity > -5f)
			_rbody.angularVelocity = 0;
	}
	private void CheckWheelOfFortuneState()
	{
		if (_rbody.angularVelocity < 0)
			_isWheelOfFortuneEnabled = true;
	}
	#endregion
}
