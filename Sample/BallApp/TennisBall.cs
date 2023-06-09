﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class TennisBall : Obj {

        Random r1 = new Random(); //乱数インスタンス

        private static int cnt ;

        public static int Cnt { get => cnt; set => cnt = value; }


        //コンストラクタ
        public TennisBall(double xp, double yp) : base(xp, yp, @"pic\tennis_ball.png") {

            int rndX = r1.Next(-15, 15);
            MoveX = (rndX != 0 ? rndX : 1);//乱数で移動量を設定(0が出ないように)

            int rndY = r1.Next(-15, 15);
            MoveY = (rndY != 0 ? rndY : 1);//乱数で移動量を設定(0が出ないように)

            Cnt++;
        }


        public override void Move(PictureBox pbBar, PictureBox pbBall) {

            Rectangle rBar = new Rectangle(pbBar.Location.X, pbBar.Location.Y, pbBar.Width, pbBar.Height);
            Rectangle rBall = new Rectangle(pbBall.Location.X, pbBall.Location.Y, pbBall.Width, pbBall.Height);

            // Console.WriteLine("X座標 = {0},Y座標 = {1}", posX, posY);
            if (PosY > 550 || PosY < 0 || rBar.IntersectsWith(rBall))
            {
                MoveY = -MoveY;
            }
            if (PosX > 750 || PosX < 0)
            {
                MoveX = -MoveX;
            }
            PosX = PosX + MoveX;
            PosY = PosY + MoveY;
        }

        public override void Move(Keys direction) {
            ;
        }

    }
}
