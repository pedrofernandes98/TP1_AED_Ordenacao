using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Ordenacao
{
    class Resultados
    {
        public int N { get; set; }
        public double[] tpOrdenacaoBolha { get; set; } //tp = Tempo de Processamento
        public double[] tpOrdenacaoSelecao { get; set; }
        public double[] tpOrdenacaoInsercao { get; set; }
        public double[] tpMergeSort { get; set; }
        public double[] tpQuickSort { get; set; }

        //tm = Tempo Médio

        public double tmOrdenacaoBolha;
        public double tmOrdenacaoSelecao;
        public double tmOrdenacaoInsercao;
        public double tmMergeSort;
        public double tmQuickSort;



        //public int custo { get; set; }


        public Resultados()
        {
            tpOrdenacaoBolha = new double[5];
            tpOrdenacaoSelecao = new double[5];
            tpOrdenacaoInsercao = new double[5];
            tpMergeSort = new double[5];
            tpQuickSort = new double[5];
        }

        public void CalculaMedia()
        {
            tmOrdenacaoBolha = tpOrdenacaoBolha.Sum() / (tpOrdenacaoBolha.Length * 1.0) ;
            tmOrdenacaoSelecao = tpOrdenacaoSelecao.Sum() / (tpOrdenacaoSelecao.Length * 1.0);
            tmOrdenacaoInsercao = tpOrdenacaoInsercao.Sum() / (tpOrdenacaoInsercao.Length * 1.0);
            tmMergeSort = tpMergeSort.Sum() / (tpMergeSort.Length * 1.0);
            tmQuickSort = tpQuickSort.Sum() / (tpQuickSort.Length * 1.0);
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            const string separador = ";";
            InicializaPrograma();
            StreamWriter meuArquivo = new StreamWriter(@"analiseVetorAleatorio.csv");
            string linha = "";
            //int[] vetorAleatorio;
            int[] leituras = new int[5];
            VetoresTeste meuVetor;
            //var watch; 

            int N = 2000;

            do
            {
                linha = "";
                Resultados MeusResultados = new Resultados();
                //vetorAleatorio = Database.retornaVetorDadosComTamanho(N);
                meuVetor = new VetoresTeste(N);

                for(int i = 0; i < 5; i++)
                {
                    //------------------------------Bolha------------------------

                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.OrdenacaoBolha(meuVetor.VetorAleatorio);

                    watch.Stop();
                    //double elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    double elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpOrdenacaoBolha[i] = elapsedMs;

                    //CRESCENTE

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.OrdenacaoSelecao(meuVetor.VetorCrescente);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpOrdenacaoSelecao[i] = elapsedMs;

                    //DECRESCENTE

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.OrdenacaoSelecao(meuVetor.VetorDescrescente);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpOrdenacaoSelecao[i] = elapsedMs;


                    //-----------------------------Selecao-----------

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.OrdenacaoSelecao(vetorAleatorio);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpOrdenacaoSelecao[i] = elapsedMs;

                    //-----------------------------Insercao-----------

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.OrdenacaoInsercao(vetorAleatorio);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpOrdenacaoInsercao[i] = elapsedMs;

                    //-----------------------------MergeSort-----------

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.MergeSort(vetorAleatorio);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpMergeSort[i] = elapsedMs;

                    //-----------------------------QuickSort-----------

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.QuickSort(vetorAleatorio);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpQuickSort[i] = elapsedMs;


                }

                MeusResultados.CalculaMedia();

                linha = N + separador + MeusResultados.tmOrdenacaoBolha + separador + MeusResultados.tmOrdenacaoSelecao + separador + MeusResultados.tmOrdenacaoInsercao + separador + MeusResultados.tmMergeSort + separador + MeusResultados.tmQuickSort + separador;
                meuArquivo.WriteLine(linha);
                //Proximo Incremeto
                //int auxiliar = N / 1000;
                //N = (auxiliar * auxiliar) * 1000;

                Console.WriteLine("Gravei N = " + N);
                N += 1000;

            } while (N <= 10000);


            meuArquivo.Close();





            Console.WriteLine("Termineeeeei! :D");
            Console.ReadKey();
        }

        static void InicializaPrograma()
        {
            Database.lerTxt();
            Database.preencheVetorDados();
        }

        static void testes()
        {
            int[] vetor = Database.retornaVetorDadosComTamanho(10);
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} |", vetor[i]);
            }

            //AlgoritmoOrdenacao teste = new AlgoritmoOrdenacao();

            int[] vetorOrdenado = AlgoritmoOrdenacao.OrdenacaoBolha(vetor);
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} |", vetorOrdenado[i]);
            }

            vetor = Database.retornaVetorDadosComTamanho(10);
            vetorOrdenado = AlgoritmoOrdenacao.OrdenacaoSelecao(vetor);
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} |", vetorOrdenado[i]);
            }

            vetor = Database.retornaVetorDadosComTamanho(10);
            vetorOrdenado = AlgoritmoOrdenacao.OrdenacaoInsercao(vetor);
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} |", vetorOrdenado[i]);
            }

            vetor = Database.retornaVetorDadosComTamanho(10);
            vetorOrdenado = AlgoritmoOrdenacao.MergeSort(vetor);
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} |", vetorOrdenado[i]);
            }


            vetor = Database.retornaVetorDadosComTamanho(10);
            vetorOrdenado = AlgoritmoOrdenacao.QuickSort(vetor);
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} |", vetorOrdenado[i]);
            }
        }
    }
}
