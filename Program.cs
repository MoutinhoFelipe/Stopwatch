namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seja bem-vindo ao App Stopwatch!");
            Clear(1500);
            Menu();
        }

        static void Menu()
        {
            bool success = false;
            short modo = 0;

            do
            {
                Clear(0);
                Console.WriteLine("Escolha o modo desejado: ");
                Console.WriteLine("1 - Cronômetro");
                Console.WriteLine("2 - Contagem Regressiva");
                Console.WriteLine("0 - Sair");
                success = short.TryParse(Console.ReadLine(), out modo);
            }
            while (!success || (modo != 1 && modo != 2 && modo != 0));

            switch (modo)
            {
                case 1:
                    Cronometro();
                    break;
                case 2:
                    ContagemRegressiva();
                    break;
                case 3:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        static void Cronometro()
        {
            int tempoAtual = 0;

            //Instruções na tela
            Clear(0);
            Console.WriteLine("1 - Cronômetro");
            Thread.Sleep(1500);

            var tempoLimite = ReceberTempoValidadoECalcularSegundos();
            Clear(0);

            while (tempoAtual <= tempoLimite)
            {
                Console.Write($"Cronômetro: {tempoAtual} seg.");
                tempoAtual++;
                Clear();
            }

            Menu();
        }

        static void ContagemRegressiva()
        {
            Clear(0);
            Console.WriteLine("2 - Contagem Regressiva");
            var tempoLimite = ReceberTempoValidadoECalcularSegundos();

            Clear(0);
            while (tempoLimite > 0)
            {
                Console.Write($"Contagem Regressiva: {tempoLimite} seg.");
                tempoLimite--;
                Clear();
            }

            Menu();
        }

        static int ReceberTempoValidadoECalcularSegundos()
        {
            string tempoString;
            char unidadeDeTempo = ' ';
            bool success = false;
            int tempoLimite = 0;
            //Pedirá para digitar o tempo enquanto o formato inserido for inválido.
            do
            {
                Clear(0);
                Console.WriteLine("Digite total de tempo: (Exemplo: 15s ou 10m (s = segundos, m = minutos)");
                //Recebe o tempo e repete o loop em casa de nulo ou vazio
                tempoString = Console.ReadLine().ToLower();
                if (tempoString == null || tempoString == "")
                    continue;

                //Extrai último char da string inserida e armazena como unidade de Tempo
                char.TryParse(tempoString.Substring(tempoString.Length - 1, 1), out unidadeDeTempo);

                //Tenta retirar da string apenas o último char e armazenar como o Tempo inserido
                //Armazena se foi sucesso ou não
                success = int.TryParse(tempoString.Substring(0, tempoString.Length - 1), out tempoLimite);
            }
            //Condições que classificam o valor inserido como válido, caso contrário o usuário deverá inserir novamente
            while (tempoString == null || tempoString.Length == 0 || (unidadeDeTempo != 's' && unidadeDeTempo != 'm') || !success);

            //Caso a unidade seja minuto, tempo total será multiplicado por 60
            if (unidadeDeTempo == 'm')
                tempoLimite = tempoLimite * 60;

            return tempoLimite;
        }

        static void Clear(int sleep = 1000)
        {
            Thread.Sleep(sleep);
            Console.Clear();
        }
    }
}