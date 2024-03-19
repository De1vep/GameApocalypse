using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTest : MonoBehaviour
{
	[SerializeField] Animator ani;
	private float horizontal;
	private float vertical;
	// Update is called once per frame
	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
		{
			ani.SetFloat("xVelocity", horizontal);
			ani.SetFloat("yVelocity", vertical);
			ani.SetBool("isFacingSide", true);
		}
		else if (Input.GetButton("Horizontal"))
		{		
			ani.SetFloat("xVelocity", horizontal);
			ani.SetBool("isFacingSide", true);
		}
		else if (Input.GetButton("Vertical"))
		{
			ani.SetFloat("yVelocity", vertical);
			ani.SetBool("isFacingSide", false);
		}
	}
}
