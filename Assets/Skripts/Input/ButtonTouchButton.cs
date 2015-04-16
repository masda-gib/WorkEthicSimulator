using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class ButtonTouchButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	// designed to work in a pair with another axis touch button
	// (typically with one having -1 and one having 1 axisValues)
	public string buttonName = "Fire1"; // The name of the axis

	CrossPlatformInputManager.VirtualButton m_Button; // A reference to the virtual axis as it is in the cross platform input
	
	void OnEnable()
	{
	}
	
	public void OnPointerDown(PointerEventData data)
	{
		CrossPlatformInputManager.SetButtonDown (buttonName);
	}
	
	
	public void OnPointerUp(PointerEventData data)
	{
		CrossPlatformInputManager.SetButtonUp (buttonName);
	}
}