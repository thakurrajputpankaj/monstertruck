using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Swipe : MonoBehaviour {

	private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
	private Vector2 startTouch, swipeDelta;
	private bool isDragging = false;

	   
	void Update () {
		tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

		if (Input.GetMouseButtonDown (0)) {
			tap = true;
			isDragging = true;
			startTouch = Input.mousePosition;
		} else if (Input.GetMouseButtonUp (0)) {
			isDragging = false;
			Reset ();
		}
		 //Mobile Inputs
		if (Input.touches.Length > 0) {
			if (Input.touches [0].phase == TouchPhase.Began) {
				tap = true;
				isDragging = true;
				startTouch = Input.touches [0].position;
			}else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled){
				isDragging = false;
				Reset ();
			}
		} 
		// Calculate Distance
		swipeDelta = Vector2.zero; 
		if (isDragging) {
			if (Input.touches.Length > 0) {
				tap = true;
				swipeDelta = Input.touches [0].position - startTouch;
			} else if(Input.GetMouseButton(0)){
				swipeDelta = (Vector2)Input.mousePosition - startTouch;

			}
		}

		//Did we cross the desdzone
		if (swipeDelta.magnitude > 125) {
			float x = swipeDelta.x;
			float y = swipeDelta.y;
			if (Mathf.Abs (x) > Mathf.Abs (y)) {
				if (x < 0) {
					swipeLeft = true;
				} else {
					swipeRight = true;
				}
			} else {
				if (y < 0) {
					swipeDown = true;
				} else {
					swipeUp = true;
				}
			}
		}
	}

	void Reset(){
		startTouch = swipeDelta = Vector2.zero;
		isDragging = false;
	}

	public Vector2 SwipeDelta{ get { return SwipeDelta; } }
	public bool SwipeLeft { get { return swipeLeft; } }
	public bool Tap { get { return tap; } }
	public bool SwipeRight { get { return swipeRight; } }
	public bool SwipeUp { get { return swipeUp; } }
	public bool SwipeDown { get { return swipeDown; } }
}
