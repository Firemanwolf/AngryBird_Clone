using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public int HP = 3;
	public float damageImpactSpeed; //speed threshold for registering hit
	public GameObject gameObj;
	//public Sprite damagedSprite;

	private int currentHP;
	private float damageImpactSpeed2;
	private Collider2D objCollider2D;
	private Rigidbody2D objRigidbody2D;
	//private SpriteRenderer spriteRenderer;


	void Start()
	{
		//spriteRenderer = GetComponent <SpriteRenderer> ();
		currentHP = HP; //because different materials have different hitpoints
		damageImpactSpeed2 = damageImpactSpeed * damageImpactSpeed;
		objCollider2D = GetComponent<Collider2D>();
		objRigidbody2D = GetComponent<Rigidbody2D>();
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeed2)
		{
			return;
		}
		//spriteRenderer.sprite = damagedSprite;
		currentHP --;
		Debug.Log("Hit");

		if (currentHP <= 0)
		{
			Death();
		}
	}
	void Death()
	{
		//spriteRenderer.enabled = false;
		objCollider2D.enabled = false;
		objRigidbody2D.isKinematic = true;
		Debug.Log("Dead");
	}
}
