using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class SoccerBall {

        //フィールド
        private Image image; //画像データ

        private double posX; //x座標
        private double posY; //y座標

        private double moveX = 7.0; //移動量（ｘ方向）
        private double moveY = 7.0; //移動量（ｙ方向）

        //コンストラクタ
        public SoccerBall() {
            Image = Image.FromFile(@"pic\soccer_ball.png");
            PosX = 0.0;
            PosY = 0.0;
        }
        //プロパティ
        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }
        public Image Image { get => image; set => image = value; }

        //メソッド
        public void Move() {
           // Console.WriteLine("X座標 = {0},Y座標 = {1}", posX, posY);
           if(posY > 550 || posY < 0)
            {
                moveY = -moveY; 
            }
            if (posX > 750 || posX < 0)
            {
                moveX = -moveX;
            }
            posX = posX + moveX;
            posY = posY + moveY;
                
        }
    }
}
