

using System.Net.NetworkInformation;
using System.Text;

namespace DesafioCarnaval5;
public class Conversor
{
    private static readonly Dictionary<int, string> primeiraOrdem = new Dictionary<int, string>{
        {0, "zero"}, {1, "um"}, {2, "Dois"}, {3, "três"}, {4, "quatro"}, {5, "cinco"},
        {6, "seis"}, {7, "sete"}, {8, "oito"}, {9, "nove"},{10, "dez"}, {11, "onze"}, {12, "doze"},
        {13, "treze"}, {14, "catorze"}, {15, "quinze"},{16, "dezesseis"}, {17, "dezessete"},
        {18, "dezoito"}, {19, "dezenove"}};
    private static readonly Dictionary<int, string> segundaOrdem = new Dictionary<int, string>{
        {20, "vinte"}, {30, "trinta"},{40, "quarenta"}, {50, "cinquenta"}, {60, "secenta"},
        {70, "setenta"}, {80, "oitenta"}, {90, "noventa"}};
    private static readonly Dictionary<int, string> terceiraOrdem = new Dictionary<int, string>{
        {100, "cem"}, {200, "duzentos"}, {300, "trezentos"}, {400, "quatrocentos"}, {500, "quinhentos"},
        {600, "seicentos"}, {700, "setecentos"}, {800, "oitocentos"}, {900, "novecentos"}};
    private static readonly Dictionary<int, string> quartaOrdem = new Dictionary<int, string>{
        {1000, "mil"}, {2000, "dois mil"}, {3000, "tres mil"}, {4000, "quatro mil"}, {5000, "cinco mil"},
        {6000, "seis mil"}, {7000, "sete mil"}, {8000, "oito mil"}, {9000, "nove mil"}, {10000, "dez mil"}};


    public static string ConverterPorExtencao(int valor)
    {
        string valUnite = string.Empty;
        StringBuilder sb = new StringBuilder();

        int sobra = 0;

        int valorMilhar = valor / 1000;
        int restoMilhar = valor % 1000;

        int valorCentena = 0;
        int restoCentena = 0;

        int valorDesena = 0;
        int restoDezena = 0;

        //Trabalhando com Milhar
        if (valorMilhar >= 0 && valorMilhar <= 10)
        {
            if (valorMilhar != 0 && restoMilhar % 100 == 0)
            {
                foreach (var item in quartaOrdem.Keys)
                {
                    if (valor == item)
                        return sb.Append($"{quartaOrdem[item]}").ToString();
                }
            }
            else
            {
                sobra = restoMilhar;
                valorCentena = (int)(sobra / 100);
                restoCentena = (int)(sobra % 100);

                if (valorCentena != 0 && restoCentena % 100 == 0)
                {
                    foreach (var item in terceiraOrdem.Keys)
                    {
                        if (valorCentena * 100 == item)
                        {
                            var mil = valorMilhar == 0 ? string.Empty : (quartaOrdem[valorMilhar * 1000]);
                            var cent = (valorCentena == 0) ? string.Empty : (terceiraOrdem[valorCentena * 100]);
                            return sb.Append($"{mil} e {cent}").ToString();
                        }

                    }
                }
                else
                {
                    sobra = restoCentena;
                    if (sobra > 19)
                    {
                        valorDesena = (int)(sobra / 10);
                        restoDezena = (int)(sobra % 10);

                        if (valorDesena != 0 && restoDezena % 10 == 0)
                        {
                            foreach (var item in segundaOrdem.Keys)
                            {
                                if (sobra == item)
                                {
                                    var mil = valorMilhar == 0 ? string.Empty : (quartaOrdem[valorMilhar * 1000]);
                                    var cent = (valorCentena == 0) ? string.Empty : (terceiraOrdem[valorCentena * 100]);
                                    return sb.Append($"{mil} e {cent} e {segundaOrdem[item]}").ToString();
                                }

                            }
                        }
                        else
                        {
                            sobra = restoDezena;
                            foreach (var item in primeiraOrdem.Keys)
                            {

                                if (sobra == item)
                                {
                                    valUnite = primeiraOrdem[item].ToString();
                                    var mil = (valorMilhar == 0) ? string.Empty : quartaOrdem[valorMilhar * 1000];
                                    var cent = (valorCentena == 0) ? string.Empty : terceiraOrdem[valorCentena * 100] + " e ";
                                    var dezn = (valorDesena == 0) ? string.Empty : segundaOrdem[valorDesena * 10] + " e ";
                                    return sb.Append($"{mil} {cent}  {dezn} {valUnite}").ToString().Trim();

                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in primeiraOrdem.Keys)
                        {

                            if (sobra == item)
                            {
                                valUnite = primeiraOrdem[item].ToString();
                                var mil = (valorMilhar == 0) ? string.Empty : quartaOrdem[valorMilhar * 1000];
                                var cent = (valorCentena == 0) ? string.Empty : terceiraOrdem[valorCentena * 100] + " e ";
                                var dezn = (valorDesena == 0) ? string.Empty : segundaOrdem[valorDesena * 10] + " e ";
                                return sb.Append($"{mil} {cent}  {dezn} {valUnite}").ToString().Trim();

                            }
                        }

                    }

                }
            }
        }

        return string.Empty;
    }
}

