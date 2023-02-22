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
        Console.Write("- valor final da compra: ");
        double entrada =Convert.ToDouble(Console.ReadLine());

        if(entrada> 10000)
        {
            Console.WriteLine("Valor Estremamente Alto, ainda estamos a analizar se podemos implementar ou não");
            return; 
        }
        var valores = entrada.ToString().Split(",");
        int.TryParse(valores[0], out int reais);
        int.TryParse(valores[1], out int centimos);

        string reaisExtenso = Conversor.ConverterPorExtencao(reais);
        string centimoExtenso = Conversor.ConverterPorExtencao(centimos); 
        Console.WriteLine($"{reaisExtenso} reis e {centimoExtenso} centavos".ToUpper());
    }
}
