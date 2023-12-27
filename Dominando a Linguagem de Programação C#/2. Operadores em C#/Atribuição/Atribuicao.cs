using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operadores_em_C_.Atribuição
{
    public class Atribuicao
    {
        public void CombinarOperadores(int n1, int n2)
        {
            int n3 = n1 + n2;

            n3 += 5;

            Console.WriteLine($"Esse é o N3: {n3} que foi somado + 5 ");
        }

        public void ConverterTipos(string s)
        {
            int a = Convert.ToInt32(s);

            Console.WriteLine($"Esse é a String {s} que foi convertida em int {a}");
        }

        public void ConverterSeguro(string s)
        {
            int b = 0;
            int.TryParse(s, out b);

            Console.WriteLine($"Se foi possível converter esse é o resultado A = {s}, caso não tenha sido possível esse é o resultado B = {b}, sendo ambas iguais deu certo, caso B seja 0, deu errado!!");
        }
    }
}
