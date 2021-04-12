using System;
using System.Linq;

namespace Robo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantoSuperiorDireitoX = 0;
            int cantoSuperiorDireitoY = 0;
            int posX, posY;
            bool isIntX;
            bool isIntY;
            string direcao,instrucao;
            Console.WriteLine("Programa do Robo");
            while (true)
            {
                Console.WriteLine("Digite as coordenadas do canto superior direito da área no formato NÚMERO NÚMERO(exemplo: 5 5): ");
                string coordenadas = Console.ReadLine();
                string[] coords = coordenadas.Split(' ');
                Console.WriteLine(coords.Length);
                if (coords.Length > 2)
                {
                    Console.WriteLine("Números demais. Tente novamente.");
                    continue;
                }
                else if (coords.Length < 2)
                {
                    Console.WriteLine("Digite mais que um número, ou está faltando espaço entre os números.");
                    continue;
                }
                isIntX = int.TryParse(coords[0], out cantoSuperiorDireitoX);
                isIntY = int.TryParse(coords[1], out cantoSuperiorDireitoY);
                if (isIntX && isIntY) { break; }
                else { 
                    Console.WriteLine("Digite no formato certo: NÚMERO NÚMERO");
                    continue;
                }
            }
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Digite a posição inicial do robô no formato NÚMERO NÚMERO DIRECAO(N,S,O,E) (exemplo: 1 2 N): ");
                    string posicaoI = Console.ReadLine();
                    string[] subsPosicaoI = posicaoI.Split(' ');
                    if (subsPosicaoI.Length > 3)
                    {
                        Console.WriteLine("Digite no formato certo. Exemplo: 1 2 N");
                        continue;
                    }
                    else if (subsPosicaoI.Length < 3)
                    {
                        Console.WriteLine("Número errado de valores ou formatos errados.");
                        continue;
                    }
                    isIntX = int.TryParse(subsPosicaoI[0], out posX);
                    isIntY = int.TryParse(subsPosicaoI[1], out posY);
                    if (!isIntX || !isIntY)
                    {
                        Console.WriteLine("Os dois primeiros termos devem ser números.");
                        continue;
                    }
                    if (!(subsPosicaoI[2] is string)) { continue; }
                    subsPosicaoI[2]=subsPosicaoI[2].ToUpper();
                    if (subsPosicaoI[2] == "N" || subsPosicaoI[2] == "O" || subsPosicaoI[2] == "L" || subsPosicaoI[2] == "S")
                    {
                        direcao = subsPosicaoI[2];
                        break;
                    }
                    else
                    {
                        Console.WriteLine("O terceiro termo deve ser uma direção do tipo: N O L S");
                        continue;
                    }
                }
                Robot robo = new Robot(posX, posY, direcao);
                while (true)
                {
                    Console.WriteLine("Digite as instruções do robô. Exemplo: EMEMEMEMM Comandos: E(squerda)M(over)D(ireita)");
                    instrucao = Console.ReadLine();
                    bool permitido;
                    permitido = LetraPermitida(instrucao);
                    if (!permitido)
                    {
                        Console.WriteLine("Os únicos comandos aceitos são: E/M/D");
                        continue;
                    }
                    else { break; }
                }
                robo.lerinstrucao(instrucao);
                Console.WriteLine(robo);
                Console.WriteLine("Deseja mover outro robô? Digite SIM caso queira, caso contrário o programa terminará.");
                string teste = Console.ReadLine();
                if (teste == "SIM")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }

        private static bool LetraPermitida(string instrucao)
        {
            string letraspermitidas = "EMD";
            bool permitido = true;
            foreach (char c in instrucao)
            {
                if (!letraspermitidas.Contains(c.ToString()))
                {
                    permitido = false;
                    break;
                }
                else
                {
                    permitido = true;
                }
            }
            return permitido;
        }
    }
}
