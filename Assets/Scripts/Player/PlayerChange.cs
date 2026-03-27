using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public Sprite normalPlayer;
    public Sprite EvilPlayer;

    private SpriteRenderer spriteRenderer;

    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalPlayer;
       
    }

    public void SetDiabolicForm(bool active)
    {
        spriteRenderer.sprite = active ? EvilPlayer : normalPlayer;
    }
}
