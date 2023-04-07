using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public abstract class Game
    {
        public enum Type { KEO, BUA, BAO };

        /* Nhận tham số là người chơi chọn gì, trả ra kết quả của máy chọn.
         * 
         * Tham số đầu tiên là máy chọn gì?
         * 
         * Tham số thứ hai là kết quả của trận đấu thắng hay thua?
         * 
         * 0 là hoà, 1 là người chơi thắng, -1 là người chơi thua
         */
        public abstract Tuple<int, int> Next(int player);

        public static int CheckResultGame(int playerChoosed, int machineChoosed)
        {

            int ret = 1;
            if (playerChoosed == (int)Type.KEO && machineChoosed == (int)Type.BUA ||
                playerChoosed == (int)Type.BUA && machineChoosed == (int)Type.BAO ||
                playerChoosed == (int)Type.BAO && machineChoosed == (int)Type.KEO)
            {
                ret = -1;
            }
            else if (playerChoosed == (int)Type.KEO && machineChoosed == (int)Type.KEO ||
                playerChoosed == (int)Type.BUA && machineChoosed == (int)Type.BUA ||
                playerChoosed == (int)Type.BAO && machineChoosed == (int)Type.BAO)
            {
                ret = 0;
            }
            else
            {
                ret = 1;
            }
            return ret;
        }

    }

    public class DummyMode : Game
    {

        public override Tuple<int, int> Next(int playerChoosed)
        {
            var machineChoosed = new Random().Next(0, 3);
            var status = CheckResultGame(playerChoosed, machineChoosed);

            return Tuple.Create(machineChoosed, status);
        }
    }

    public class AlwaysWinMode : Game
    {
        public override Tuple<int, int> Next(int playerChoosed)
        {
            int machineChoosed;
            if (playerChoosed == (int)Type.BAO)
            {
                machineChoosed = (int)Type.KEO;
            }
            else if (playerChoosed == (int)Type.KEO)
            {
                machineChoosed = (int)Type.BUA;
            }
            else
            {
                machineChoosed = (int)Type.BAO;
            }

            return Tuple.Create(machineChoosed, -1);
        }
    }

    public class SmartMode : Game
    {
        public override Tuple<int, int> Next(int playerChoosed)
        {
            int machineChoosed;
            int status;
            int rd = new Random().Next(0, 100);
            if (rd <= 40)
            {
                if (playerChoosed == (int)Type.BAO)
                {
                    machineChoosed = (int)Type.BUA;
                }
                else if (playerChoosed == (int)Type.KEO)
                {
                    machineChoosed = (int)Type.BAO;
                }
                else
                {
                    machineChoosed = (int)Type.KEO;
                }
                status = 1;
            }
            else if (rd >= 40 && rd <= 60)
            {
                machineChoosed = playerChoosed;
                status = 0;
            }
            else
            {
                (machineChoosed, status) = new AlwaysWinMode().Next(rd);
            }

            return Tuple.Create(machineChoosed, status);
        }
    }
}
