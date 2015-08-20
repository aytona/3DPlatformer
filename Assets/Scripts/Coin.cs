using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    [SerializeField]
    private float rotateSpeed = 1.0f;

	// Use this for initialization
	void Start () {
        StartCoroutine(Spin());
	}

    private IEnumerator Spin()
    {
        while (true)
        {
            transform.Rotate(transform.up, rotateSpeed * 360 * Time.deltaTime);
            yield return 0;
        }
    }
}
