using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float scaleTarget = 64;
    private float transparency;
    private float scale;
    private Animator anim;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject sixShotExplosion;

    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        StartCoroutine(TriggerMine());
    }

    IEnumerator TriggerMine()
    {
        float value = 0;

        while(value < 1) 
        {
            value += speed * Time.deltaTime;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Mathf.Lerp(0, 1, value));
            transform.localScale = new Vector2( Mathf.Lerp(0, scaleTarget, value), Mathf.Lerp(0, scaleTarget, value));
            yield return null;
        }

        GameObject bomb = Instantiate(sixShotExplosion);
        anim.SetTrigger("Boom");
        bomb.transform.position = transform.position;

    }

    public void Exploded()
    {
        Destroy(gameObject, 0.1f);
    }
}
