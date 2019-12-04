using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	public float speed = 3f;
	Rigidbody2D myRB;
	bool facingRight;
	Animator anim;

	// Use this for initialization
	void Start () {
		myRB = this.gameObject.GetComponent<Rigidbody2D> ();
		anim = this.GetComponent<Animator> ();
		facingRight = false;
	}


	void FixedUpdate ()
	{
		float move = Input.GetAxisRaw ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs(move));
		myRB.velocity = new Vector2 (move * speed, myRB.velocity.y);
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}
	// Update is called once per frame
	void Update () {
		
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
