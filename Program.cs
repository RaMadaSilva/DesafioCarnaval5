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
        double.TryParse(Console.ReadLine(), out double valor);
        string valorExtenso = Conversor.ConverterPorExtencao(valor);
        Console.WriteLine(valorExtenso.ToUpper());
    }
}
