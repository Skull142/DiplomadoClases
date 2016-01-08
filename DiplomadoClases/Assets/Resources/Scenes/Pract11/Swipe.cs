using UnityEngine;
using System.Collections;

public class Swipe : MonoBehaviour {

	public float minSwipeDistY;
	public float minSwipeDistX;
	//
	private Vector2 startPos;
	private Animator animator;

	void Start()
	{
		this.animator = this.GetComponent<Animator>();
	}

	void Update()
	{
		#if !UNITY_STANDALONE
			this.CheckSwipe();
		#endif
		#if UNITY_STANDALONE
			this.CheckArrow();
		#endif
		this.transform.position = new Vector3(0, this.transform.position.y, 0f);
		this.transform.eulerAngles = new Vector3(0, 180f, 0f);
	}
	private void CheckArrow()
	{
		Vector2 arrow = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if(arrow.x > 0)				this.Right();
		else if	(arrow.x < 0)		this.Left();
		//
		if(arrow.y > 0)	this.Up();
		else if	(arrow.y < 0)		this.Down();
	}
	private void CheckSwipe()
	{
		if (Input.touchCount > 0) 
		{
			Touch touch = Input.touches[0];
			switch (touch.phase) 
			{
				case TouchPhase.Began:
					startPos = touch.position;
				break;
				case TouchPhase.Ended:
					float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
					float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
					if (swipeDistVertical > minSwipeDistY) 
					{
						float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
						if (swipeValue > 0)//up swipe
							Up();
						else if (swipeValue < 0)//down swipe
							Down();
					}
					if (swipeDistHorizontal > minSwipeDistX) 
					{
						float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
						if (swipeValue > 0)//right swipe
							Right ();
						else if (swipeValue < 0)//left swipe
							Left ();
					}
				break;
			}
		}
	}
	private void Up()
	{
		this.animator.SetTrigger("UP");
	}
	private void Down()
	{
		this.animator.SetTrigger("DOWN");
	}
	private void Right()
	{
		//this.animator.SetTrigger("RIGHT");
		print("Right");
	}
	private void Left()
	{
		//this.animator.SetTrigger("LEFT");
		print("Left");
	}
}
