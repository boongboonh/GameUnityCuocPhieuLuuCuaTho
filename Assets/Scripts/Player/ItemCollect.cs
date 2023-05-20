using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
  
    //âm thanh
    public AudioSource collect_carrot_audio;


    [SerializeField] private int carrot = 0;
    [SerializeField] private Text carrotPoint;
    [SerializeField] private Text carrotPointEndWin;
    [SerializeField] private Text carrotPointEndLose;
    [SerializeField] private Text carrotBullet;
    [SerializeField] private Text temptCarrotScore;



    private void OnTriggerEnter2D(Collider2D collision)
    {

        int numbercr = int.Parse(carrotBullet.text);

        //kiểm tra va chạm với vật phẩm nếu true => xóa vật phẩm && +1
        if (collision.gameObject.CompareTag("carrot"))
        {



            Destroy(collision.gameObject);
            carrot++;


            carrotPoint.text = "Carrot: " + carrot;

            //hiển thị trong menu game win
            carrotPointEndWin.text = carrot.ToString()+"/20";

            //hiển thị trong menu game lose
            carrotPointEndLose.text = carrot.ToString() +"/20";

            //hiển thị số đạn
            carrotBullet.text = (numbercr+1).ToString();

            //lưu số carrot tạm để sử dụng tính toán
            temptCarrotScore.text = carrot.ToString();

            //âm thanh
            collect_carrot_audio.Play();
        }

        
    }


}
