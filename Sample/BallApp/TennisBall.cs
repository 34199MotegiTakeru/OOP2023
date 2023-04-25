﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class TennisBall : Obj {

        Random r1 = new Random(); //乱数インスタンス


        //コンストラクタ
        public TennisBall(double xp, double yp) : base(xp, yp, @"pic\tennis_ball.png") {

            int rndX = r1.Next(-15, 15);
            MoveX = (rndX != 0 ? rndX : 1);//乱数で移動量を設定(0が出ないように)

            int rndY = r1.Next(-15, 15);
            MoveY = (rndY != 0 ? rndY : 1);//乱数で移動量を設定(0が出ないように)

            //cnt++;
        }

        public override void Move() {
            // Console.WriteLine("X座標 = {0},Y座標 = {1}", posX, posY);
            if (PosY > 550 || PosY < 0)
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
    }
}
