using UnityEngine;
using System.Collections;

public class LivingEntity : MonoBehaviour, IDamageable {

	public float startingHealth;
	public float health { get; protected set; }
	protected bool dead;

	public event System.Action OnDeath;
	public Animator animator;

	protected virtual void Start() {
		health = startingHealth;
		animator = GetComponent<Animator> ();
	}

	public virtual void TakeHit(float damage, Vector3 hitPoint, Vector3 hitDirection, Player damager) {
		// Do some stuff here with hit var
		TakeDamage (damage , damager);
		damager.hits++;

	}

	public virtual void TakeDamage(float damage,Player damager) {
		health -= damage;
		
		if (health <= 0 && !dead) {
			Die();
			damager.kills++;
			damager.points += 10;
			animator.SetTrigger("Die");

		}
	}

	[ContextMenu("Self Destruct")]
	public virtual void Die() {
		dead = true;
		if (OnDeath != null) {
			OnDeath();
		}
		Destroy( GetComponent<Enemy> ());
		Destroy( GetComponent<CapsuleCollider> ());
		Destroy( GetComponent<NavMeshAgent> ());
		Invoke ("delayedDestroy",8);

	}

	public void delayedDestroy(){
		GameObject.Destroy (gameObject);
	}
}
