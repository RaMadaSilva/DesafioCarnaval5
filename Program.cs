using System.Globalization;

namespace DesafioCarnaval5;
class Program
{
    #region comentario desafio
    /*
    Escreva um programa que informa o valor por extenso, por exemplo:
    - Valor final da compra: 328,90
    - Output do programa: TREZENTOS E VINTE E OITO REAIS E NOVENTA CENTAVOS
     */
    #endregion

    static void Main(string[] args)
    {
        try
        {
            Console.Write("- valor final da compra: ", CultureInfo.InvariantCulture);
            double entrada = Convert.ToDouble(Console.ReadLine());

            if (entrada > 10000)
            {
                Console.WriteLine("Valor Estremamente Alto, ainda estamos a analizar se podemos implementar ou não");
                return;
            }
            int reais = (int)Math.Floor(entrada);
            int centavos = (int)(entrada - reais)*100; 

            string reaisExtenso = Conversor.ConverterPorExtencao(reais);
            string centimoExtenso = Conversor.ConverterPorExtencao(centavos);
            Console.WriteLine($"{reaisExtenso} reis e {centimoExtenso} centavos".ToUpper());
        }
        catch(FormatException fe)
        {
            Console.WriteLine("erro de formato: " + fe.Message);
        }catch(Exception ex)
        {
            Console.WriteLine("falha interna: "+ ex.Message);
        }
        
    }
}
