using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.ConsoleApp
{
    class Robot
    {
        private int posx;
        private int posy;
        private string direcao;

        public Robot(int posx, int posy, string direcao)
        {
            this.Posx = posx;
            this.Posy = posy;
            this.Direcao = direcao;
        }

        public int Posx { get => posx; set => posx = value; }
        public int Posy { get => posy; set => posy = value; }
        public string Direcao { get => direcao; set => direcao = value; }

        public void lerinstrucao(string instrucoes)
        {
            foreach (var instrucao in instrucoes)
            {
                if (instrucao=='M')
                {
                    Mover();
                }
                else if (instrucao=='E')
                {
                    GirarEsquerda();
                }
                else if (instrucao=='D')
                {
                    GirarDireita();
                }
            }
        }

        private void GirarDireita()
        {
            if (this.Direcao == "N")
            {
                this.Direcao = "L";
            }
            else if (this.Direcao == "L")
            {
                this.Direcao = "S";
            }
            else if (this.Direcao == "S")
            {
                this.Direcao = "O";
            }
            else if (this.Direcao == "O")
            {
                this.Direcao = "N";
            }
        }

        private void GirarEsquerda()
        {
            if (this.Direcao == "N")
            {
                this.Direcao = "O";
            }
            else if (this.Direcao == "O")
            {
                this.Direcao = "S";
            }
            else if (this.Direcao == "S")
            {
                this.Direcao = "L";
            }
            else if (this.Direcao == "L")
            {
                this.Direcao = "N";
            }
        }

        private void Mover()
        {
            if (this.Direcao == "N")
            {
                this.Posy++;
            }
            else if (this.Direcao == "S")
            {
                this.Posy--;
            }
            else if (this.Direcao == "L")
            {
                this.Posx++;
            }
            else if (this.Direcao == "O")
            {
                this.Posx--;
            }
        }
        public override string ToString()
        {
            return Posx + " " + Posy + " " + Direcao;
        }
    }

}
