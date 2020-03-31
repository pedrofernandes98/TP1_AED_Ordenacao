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

        public double[] tpOrdenacaoBolhaCrescente { get; set; }
        public double[] tpOrdenacaoSelecaoCrescente { get; set; }
        public double[] tpOrdenacaoInsercaoCrescente { get; set; }
        public double[] tpMergeSortCrescente { get; set; }
        public double[] tpQuickSortCrescente { get; set; }

        public double[] tpOrdenacaoBolhaDeCrescente { get; set; }
        public double[] tpOrdenacaoSelecaoDeCrescente { get; set; }
        public double[] tpOrdenacaoInsercaoDeCrescente { get; set; }
        public double[] tpMergeSortDeCrescente { get; set; }
        public double[] tpQuickSortDeCrescente { get; set; }


        //tm = Tempo Médio

        public double tmOrdenacaoBolha;
        public double tmOrdenacaoSelecao;
        public double tmOrdenacaoInsercao;
        public double tmMergeSort;
        public double tmQuickSort;

        public double tmOrdenacaoBolhaCrescente;
        public double tmOrdenacaoSelecaoCrescente;
        public double tmOrdenacaoInsercaoCrescente;
        public double tmMergeSortCrescente;
        public double tmQuickSortCrescente;

        public double tmOrdenacaoBolhaDeCrescente;
        public double tmOrdenacaoSelecaoDeCrescente;
        public double tmOrdenacaoInsercaoDeCrescente;
        public double tmMergeSortDeCrescente;
        public double tmQuickSortDeCrescente;



        //public int custo { get; set; }


        public Resultados()
        {
            tpOrdenacaoBolha = new double[5];
            tpOrdenacaoSelecao = new double[5];
            tpOrdenacaoInsercao = new double[5];
            tpMergeSort = new double[5];
            tpQuickSort = new double[5];

            tpOrdenacaoBolhaCrescente = new double[5];
            tpOrdenacaoSelecaoCrescente = new double[5];
            tpOrdenacaoInsercaoCrescente = new double[5];
            tpMergeSortCrescente = new double[5];
            tpQuickSortCrescente = new double[5];

            tpOrdenacaoBolhaDeCrescente = new double[5];
            tpOrdenacaoSelecaoDeCrescente = new double[5];
            tpOrdenacaoInsercaoDeCrescente = new double[5];
            tpMergeSortDeCrescente = new double[5];
            tpQuickSortDeCrescente = new double[5];
        }

        public void CalculaMedia()
        {
            tmOrdenacaoBolha = tpOrdenacaoBolha.Sum() / (tpOrdenacaoBolha.Length * 1.0) ;
            tmOrdenacaoSelecao = tpOrdenacaoSelecao.Sum() / (tpOrdenacaoSelecao.Length * 1.0);
            tmOrdenacaoInsercao = tpOrdenacaoInsercao.Sum() / (tpOrdenacaoInsercao.Length * 1.0);
            tmMergeSort = tpMergeSort.Sum() / (tpMergeSort.Length * 1.0);
            tmQuickSort = tpQuickSort.Sum() / (tpQuickSort.Length * 1.0);

            double somaBolha = 0;
            for(int i = 0; i < 5; i++)
            {
                somaBolha += tpOrdenacaoBolhaCrescente[i];
            }
            double somaInsercao = 0;
            for (int i = 0; i < 5; i++)
            {
                somaInsercao += tpOrdenacaoInsercaoCrescente[i];
            }

            tmOrdenacaoBolhaCrescente = somaBolha / (tpOrdenacaoBolhaCrescente.Length * 1.0);
            tmOrdenacaoSelecaoCrescente = tpOrdenacaoSelecaoCrescente.Sum() / (tpOrdenacaoSelecaoCrescente.Length * 1.0);
            tmOrdenacaoInsercaoCrescente = somaInsercao / (tpOrdenacaoInsercaoCrescente.Length * 1.0);
            tmMergeSortCrescente = tpMergeSortCrescente.Sum() / (tpMergeSortCrescente.Length * 1.0);
            tmQuickSortCrescente = tpQuickSortCrescente.Sum() / (tpQuickSortCrescente.Length * 1.0);

            //somaBolha = Math.Round(tpOrdenacaoBolhaDeCrescente.Sum(), 8);

            somaBolha = 0;
            for (int i = 0; i < 5; i++)
            {
                somaBolha += tpOrdenacaoBolhaDeCrescente[i];
            }

            tmOrdenacaoBolhaDeCrescente = somaBolha / (tpOrdenacaoBolhaDeCrescente.Length * 1.0);
            tmOrdenacaoSelecaoDeCrescente = tpOrdenacaoSelecaoDeCrescente.Sum() / (tpOrdenacaoSelecaoDeCrescente.Length * 1.0);
            tmOrdenacaoInsercaoDeCrescente = tpOrdenacaoInsercaoDeCrescente.Sum() / (tpOrdenacaoInsercaoDeCrescente.Length * 1.0);
            tmMergeSortDeCrescente = tpMergeSortDeCrescente.Sum() / (tpMergeSortDeCrescente.Length * 1.0);
            tmQuickSortDeCrescente = tpQuickSortDeCrescente.Sum() / (tpQuickSortDeCrescente.Length * 1.0);


        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            const string separador = ";";
            InicializaPrograma();
            StreamWriter meuArquivo = new StreamWriter(@"analiseVetorAleatorio.csv");
            StreamWriter meuArquivoCrescente = new StreamWriter(@"analiseVetorCrescente.csv");
            StreamWriter meuArquivoDeCrescente = new StreamWriter(@"analiseVetorDecrescente.csv");
            string linha = "";
            //int[] vetorAleatorio;
            int[] leituras = new int[5];
            VetoresTeste meuVetor;
            //var watch; 

            int cont = 1;
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

                    AlgoritmoOrdenacao.OrdenacaoBolha(meuVetor.VetorCrescente);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpOrdenacaoBolhaCrescente[i] = elapsedMs;

                    //DECRESCENTE

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.OrdenacaoBolha(meuVetor.VetorDescrescente);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpOrdenacaoBolhaDeCrescente[i] = elapsedMs;


                    //-----------------------------Selecao-----------
                    meuVetor = new VetoresTeste(N);

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.OrdenacaoSelecao(meuVetor.VetorAleatorio);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpOrdenacaoSelecao[i] = elapsedMs;

                    //CRESCENTE

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.OrdenacaoSelecao(meuVetor.VetorCrescente);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpOrdenacaoSelecaoCrescente[i] = elapsedMs;

                    //DECRESCENTE

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.OrdenacaoSelecao(meuVetor.VetorDescrescente);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpOrdenacaoSelecaoDeCrescente[i] = elapsedMs;

                    //-----------------------------Insercao-----------
                    meuVetor = new VetoresTeste(N);

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.OrdenacaoInsercao(meuVetor.VetorAleatorio);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpOrdenacaoInsercao[i] = elapsedMs;

                    //CRESCENTE

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.OrdenacaoInsercao(meuVetor.VetorCrescente);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpOrdenacaoInsercaoCrescente[i] = elapsedMs;

                    //DECRESCENTE

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.OrdenacaoInsercao(meuVetor.VetorDescrescente);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpOrdenacaoInsercaoDeCrescente[i] = elapsedMs;


                    //-----------------------------MergeSort-----------
                    meuVetor = new VetoresTeste(N);

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.MergeSort(meuVetor.VetorAleatorio);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpMergeSort[i] = elapsedMs;

                    //CRESCENTE

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.MergeSort(meuVetor.VetorCrescente);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpMergeSortCrescente[i] = elapsedMs;

                    //DECRESCENTE

                    watch = System.Diagnostics.Stopwatch.StartNew();

                    AlgoritmoOrdenacao.MergeSort(meuVetor.VetorDescrescente);

                    watch.Stop();
                    //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                    elapsedMs = watch.ElapsedTicks / 10000000.0;
                    MeusResultados.tpMergeSortDeCrescente[i] = elapsedMs;

                    if(N <= 8000) { 

                        //-----------------------------QuickSort-----------
                        meuVetor = new VetoresTeste(N);

                        watch = System.Diagnostics.Stopwatch.StartNew();

                        AlgoritmoOrdenacao.QuickSort(meuVetor.VetorAleatorio);

                        watch.Stop();
                        //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                        elapsedMs = watch.ElapsedTicks / 10000000.0;
                        MeusResultados.tpQuickSort[i] = elapsedMs;

                        //CRESCENTE

                        watch = System.Diagnostics.Stopwatch.StartNew();

                        AlgoritmoOrdenacao.QuickSort(meuVetor.VetorCrescente);

                        watch.Stop();
                        //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                        elapsedMs = watch.ElapsedTicks / 10000000.0;
                        MeusResultados.tpQuickSortCrescente[i] = elapsedMs;

                        //DECRESCENTE

                        watch = System.Diagnostics.Stopwatch.StartNew();

                        AlgoritmoOrdenacao.QuickSort(meuVetor.VetorDescrescente);

                        watch.Stop();
                        //elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                        elapsedMs = watch.ElapsedTicks / 10000000.0;
                        MeusResultados.tpQuickSortDeCrescente[i] = elapsedMs;

                    }

                }

                MeusResultados.CalculaMedia();

                linha = N + separador + MeusResultados.tmOrdenacaoBolha + separador + MeusResultados.tmOrdenacaoSelecao + separador + MeusResultados.tmOrdenacaoInsercao + separador + MeusResultados.tmMergeSort + separador + MeusResultados.tmQuickSort + separador;
                //Console.WriteLine(linha);
                meuArquivo.WriteLine(linha);

                linha = N + separador + String.Format("{0:N8}", MeusResultados.tmOrdenacaoBolhaCrescente) + separador + MeusResultados.tmOrdenacaoSelecaoCrescente + separador + String.Format("{0:N8}", MeusResultados.tmOrdenacaoInsercaoCrescente) + separador + MeusResultados.tmMergeSortCrescente + separador + MeusResultados.tmQuickSortCrescente + separador;
                //Console.WriteLine(linha);
                meuArquivoCrescente.WriteLine(linha);

                linha = N + separador + String.Format("{0:N8}", MeusResultados.tmOrdenacaoBolhaDeCrescente) + separador + MeusResultados.tmOrdenacaoSelecaoDeCrescente + separador + MeusResultados.tmOrdenacaoInsercaoDeCrescente + separador + MeusResultados.tmMergeSortDeCrescente + separador + MeusResultados.tmQuickSortDeCrescente + separador;
                //Console.WriteLine(linha);
                meuArquivoDeCrescente.WriteLine(linha);


                //Proximo Incremeto

                


                //N = (auxiliar * auxiliar) * 1000;

                Console.WriteLine("Gravei N = " + N);

                ++cont;

                int auxiliar = N / 1000;

                N = Convert.ToInt32(Math.Pow(2, cont)) * 1000;
                //N += 1000;

            } while (N <= 128000);


            meuArquivo.Close();
            meuArquivoCrescente.Close();
            meuArquivoDeCrescente.Close();





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
