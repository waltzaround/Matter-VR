using UnityEngine;
using System.Collections;

public class IguanaCharacter : MonoBehaviour {
	Animator iguanaAnimator;
	
	void Start () {
		iguanaAnimator = GetComponent<Animator> ();
	}
	
	public void Attack(){
		iguanaAnimator.SetTrigger("Attack");
	}
	
	public void Hit(){
		iguanaAnimator.SetTrigger("Hit");
	}
	
	public void Eat(){
		iguanaAnimator.SetTrigger("Eat");
	}

	public void Death(){
		iguanaAnimator.SetTrigger("Death");
	}

	public void Rebirth(){
		iguanaAnimator.SetTrigger("Rebirth");
	}


	
	public void Move(float v,float h){
		iguanaAnimator.SetFloat ("Forward", v);
		iguanaAnimator.SetFloat ("Turn", h);
	}
}
