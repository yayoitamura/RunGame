using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class GameManager : MonoBehaviour
{
    private float _hp;

    Slider _slider;
    Image _image;
    public GameObject player;

    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        _image = GameObject.Find("Fill").GetComponent<Image>();
        //player = GameObject.Find("Player").GetComponent<Player>();
        _hp = _slider.maxValue;
    }

    void Update()
    {
        // HP上昇
        _hp -= 0.02f;
        if (_hp < _slider.maxValue / 5)
        {
            _image.color = Color.red;
            if (_hp < _slider.minValue)
            {
                player.GetComponent<Player>().Dead();
            }
        }

        // HPゲージに値を設定
        _slider.value = _hp;
    }
}