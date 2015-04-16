using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsGUI : MonoBehaviour 
{
	public WES_LevelSetup levelSetup;
	public Text points;
	public Text energy;

	// Update is called once per frame
	void Update () 
	{
		points.text = "Points: " + levelSetup.points;
		energy.text = "Energy: " + levelSetup.energy;
	}
}
