using UnityEngine;

public class FinishTrigger : BaseTrigger 
{
	[SerializeField] private FinishSlider m_FinishSlider = null;
	private int countLegRocked = 2;
	private int counterLeg = 0;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag != "Leg")
		{
            return;
        }
		if (++counterLeg == countLegRocked) //запускает слайдер
			m_FinishSlider.StartTimer();
	}


	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag != "Leg")
		{
            return;
        }
		if (counterLeg-- == countLegRocked)
			m_FinishSlider.StopTimer();
	}
}
