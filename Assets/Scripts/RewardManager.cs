using System;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
	public event Action<int> CoinsAwarded;

	public void DistributeReward(int[] sectorCoinsReward, float rotationAngle)
	{
		float rot = rotationAngle + 16;
		if (rot > 360f)
		{
			rot -= 360f;
		}

		int sectorIndex = Mathf.FloorToInt(rot / (360f / sectorCoinsReward.Length));
		int coinsAwarded = sectorCoinsReward[sectorIndex];
		Debug.Log("Sector index: " + sectorIndex + " Reward: " + coinsAwarded + " coins");

		CoinsAwarded?.Invoke(coinsAwarded);
	}
}