using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public int HP = 3; //health points
	public float damageImpactSpeed; //speed/force threshold for determining whether a hit is registered or not. birds will need this in their code.
	public GameObject gameObj;
	public Sprite damagedSprite;

	private int currentHP;
	private float damageImpactSpeed2;
	private Collider2D objCollider2D;
	private Rigidbody2D objRigidbody2D;
	private SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer = GetComponent <SpriteRenderer> ();
		currentHP = HP; //this is needed because different materials have different health points
		damageImpactSpeed2 = damageImpactSpeed * damageImpactSpeed; //speed/force threshold
		objCollider2D = GetComponent<Collider2D>();
		objRigidbody2D = GetComponent<Rigidbody2D>();
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeed2) //if velocity of collision is LESS THAN speed/force threshold, don't register the hit
		{
			return;
		}
		spriteRenderer.sprite = damagedSprite; 
		currentHP--;
		Debug.Log("Hit");

		if (currentHP <= 0)
		{
			Death();
		}
	}
	void Death()
	{
		spriteRenderer.enabled = false; 
		objCollider2D.enabled = false;
		objRigidbody2D.isKinematic = true;
		Debug.Log("Dead");
	}
}
