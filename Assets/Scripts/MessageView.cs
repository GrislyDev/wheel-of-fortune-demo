using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageView : MonoBehaviour
{
	[SerializeField] private AwardMessage _awardMessage;
	[SerializeField] private Transform _parentTransform;
	[SerializeField] private RewardManager _rewardManager;

	private void OnEnable()
	{
		_rewardManager.CoinsAwarded += CoinsAwardedHandler;
	}

	private void CoinsAwardedHandler(int coins)
	{
		var msg = Instantiate(_awardMessage, _parentTransform);
		msg.ShowAwardMessage(coins);
	}

	private void OnDisable()
	{
		_rewardManager.CoinsAwarded -= CoinsAwardedHandler;
	}
}
