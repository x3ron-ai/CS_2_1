using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProj1
{
    public class TicTacToe
    {
        int[,] field;
        
        public TicTacToe()
        {
            field = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    field[i, j] = 0;
        }
        public bool Click(int[] coords, int value)
        {
            if (this.field[coords[0], coords[1]] == 0)
            {
                this.field[coords[0], coords[1]] = value;
                return true;
            }
            else
            {
                return false;
            }
        }
        public int Scan()
        {
            int resp = 0;
            int[,] field = this.field;
            for (int i = 0; i < 3;i++)
                if (field[i, 0] == field[i, 1] && field[i, 1] == field[i, 2] && field[i, 2] != 0)
                    resp = field[i, 0];

            for (int i = 0; i < 3; i++)
                if (field[0, i] == field[1, i] && field[1,i] == field[2,i] && field[2,i] != 0)
                    resp = field[0, i];
            if (field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2] && field[2, 2] != 0)
                resp = field[0, 0];
            if (field[2, 0] == field[1, 1] && field[1, 1] == field[0, 2] && field[0, 2] != 0)
                resp = field[2, 0];

            bool draw = true;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (field[i, j] == 0)
                        draw = false;
            if (draw) return 3;
            return resp;
        }
    }
}
