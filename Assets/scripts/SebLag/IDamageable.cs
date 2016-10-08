using UnityEngine;

public interface IDamageable {

	void TakeHit (float damage, Vector3 hitPoint, Vector3 hitDirection, Player damager);

	void TakeDamage (float damage,Player damager);

}