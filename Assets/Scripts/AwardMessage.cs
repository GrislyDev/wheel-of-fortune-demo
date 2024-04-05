using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AwardMessage : MonoBehaviour
{
	[SerializeField] private Text _awardText;
	private RectTransform _rectTransform;

	public void ShowAwardMessage(int award)
	{
		_rectTransform = GetComponent<RectTransform>();
		_rectTransform.localScale = Vector3.zero;

		_awardText.text = $"You won {award} coins!";
		StartCoroutine(TransformScaleCoroutine());
		Destroy(gameObject, 1.5f);
	}

	private IEnumerator TransformScaleCoroutine()
	{
		var delay = new WaitForSeconds(0.004f);
		var scale = Vector3.zero;
		var scaleStep = new Vector3(0.02f, 0.02f, 0.02f);

		for (int i = 0; i < 50; i++)
		{
			scale += scaleStep;
			_rectTransform.localScale = scale;
			yield return delay;
		}
	}
}
