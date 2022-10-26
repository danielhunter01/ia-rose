using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using Microsoft.Speech.Recognition;
using System.Diagnostics;
using System.IO;

namespace IA
{
    class Program
    {
        private static SpeechSynthesizer voz = null;
        private static SpeechRecognitionEngine engine = null;
        public static double nro1 = 0;
        public static double nro2 = 0;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Blue;
            
            Console.Clear();
            /*
            double hora = 0;
            string periodo = "";
            hora = double.Parse(DateTime.Now.ToString("HH"));
            if (hora >= 12 && hora < 06)
            {
                periodo = "Boa tarde";
            }
            else
            {
                if (hora >= 00 && hora < 12)
                {
                    periodo = "Bom dia";
                }
                else
                {
                    periodo = "boa noite";
                }
            }
            System.IO.Directory.CreateDirectory("c:/dados");
            System.IO.File.Create("c:/dados/daniel.txt");
            */
            

            Console.Write("Carregando Systemas da Rose..");
            bool existe = System.IO.Directory.Exists("c:/dados");
            if (!existe)
            {
                System.IO.Directory.CreateDirectory("c:/dados");
                if (System.IO.Directory.Exists("c:/dados"))
                {

                    System.IO.File.Create("c:/dados/daniel.txt");
                    Console.Write("\nPasta dados Criada..");


                }

            }
            else
            {
                Console.Write("\nPasta dados carregada..");

            }

            voz = new SpeechSynthesizer();

            foreach (InstalledVoice voice in voz.GetInstalledVoices())
            {
                string nome = voice.VoiceInfo.Name;
                Console.WriteLine("\n"+voice.VoiceInfo.Name);
                if (nome == "VE_Brazilian_Portuguese_Luciana_22kHz")

                {
                    voz.SelectVoice(nome);
                    Console.WriteLine("\na voz selecionada foi: " + nome);
                }

            }


            voz.Volume = 100;
            voz.Rate = 1;

            engine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("pt-BR")); //instancia de reconhecimento
            engine.SetInputToDefaultAudioDevice(); // entrada de audio padrão

            string[] grama = { "Olá", "bom dia", "boa noite", "boa tarde", "Rose", "como você está", "qual é o seu nome" };// gramatica do programa

            Choices c_gramatica = new Choices(grama);

            GrammarBuilder gb_gramatica = new GrammarBuilder();

            gb_gramatica.Append(c_gramatica);

            Grammar g_gramatica = new Grammar(gb_gramatica);

            g_gramatica.Name = "grama";

            //"um","dois","três","quatro","cinco","seis","sete","oito","nove"

            string[] comandosSist = {"Operação soma","Operação divisão","Operação subtração","Operação multiplicação", "Que horas são", "Que dia é hoje","Encerrar Rose", "Abrir google", "Fechar google", "me conte uma piada", "leia meu texto", "calculadora",
             "O primeiro é um",                                                                                                                                                                                                                                                                                           "O segundo é um",
             "O primeiro é dois",                                                                                                                                                                                                                                                                                         "O segundo é dois",
             "O primeiro é três",                                                                                                                                                                                                                                                                                         "O segundo é três",
             "O primeiro é quatro",                                                                                                                                                                                                                                                                                       "O segundo é quatro",
             "O primeiro é cinco",                                                                                                                                                                                                                                                                                        "O segundo é cinco",
             "O primeiro é seis",                                                                                                                                                                                                                                                                                         "O segundo é seis",
             "O primeiro é sete",                                                                                                                                                                                                                                                                                         "O segundo é sete",
             "O primeiro é oito",                                                                                                                                                                                                                                                                                         "O segundo é oito",
             "O primeiro é nove",                                                                                                                                                                                                                                                                                         "O segundo é nove",
             "O primeiro é dez",                                                                                                                                                                                                                                                                                          "O segundo é dez",
             "O primeiro é onze",                                                                                                                                                                                                                                                                                         "O segundo é onze",
             "O primeiro é doze",                                                                                                                                                                                                                                                                                         "O segundo é doze",
             "O primeiro é treze",                                                                                                                                                                                                                                                                                        "O segundo é treze",
             "O primeiro é quatorze",                                                                                                                                                                                                                                                                                     "O segundo é quatorze",
             "O primeiro é quinze",                                                                                                                                                                                                                                                                                       "O segundo é quinze",
             "O primeiro é dezesseis",                                                                                                                                                                                                                                                                                    "O segundo é dezesseis",
             "O primeiro é dezessete",                                                                                                                                                                                                                                                                                    "O segundo é dezessete",
             "O primeiro é dezoito",                                                                                                                                                                                                                                                                                      "O segundo é dezoito",
             "O primeiro é dezenove",                                                                                                                                                                                                                                                                                     "O segundo é dezenove",
             "O primeiro é vinte", "O primeiro é vinte um","O primeiro é vinte dois","O primeiro é vinte três","O primeiro é vinte quatro","O primeiro é vinte cinco","O primeiro é vinte seis","O primeiro é vinte sete","O primeiro é vinte oito","O primeiro é vinte nove",                                            "O segundo é vinte", "O segundo é vinte um","O segundo é vinte dois","O segundo é vinte três","O segundo é vinte quatro","O segundo é vinte cinco","O segundo é vinte seis","O segundo é vinte sete","O segundo é vinte oito","O segundo é vinte nove",
             "O primeiro é trinta",                                                                                                                                                                                                                                                                                       "O segundo é trinta", "O segundo é trinta um","O segundo é trinta dois","O segundo é trinta três","O segundo é trinta quatro","O segundo é trinta cinco","O segundo é trinta seis","O segundo é trinta sete","O segundo é trinta oito","O segundo é trinta nove",
             "O primeiro é quarenta",                                                                                                                                                                                                                                                                                     "O segundo é quarenta", "O segundo é quarenta um","O segundo é quarenta dois","O segundo é quarenta três","O segundo é quarenta quatro","O segundo é quarenta cinco","O segundo é quarenta seis","O segundo é quarenta sete","O segundo é quarenta oito","O segundo é quarenta nove",
             "O primeiro é cinquenta",                                                                                                                                                                                                                                                                                    "O segundo é cinquenta", "O segundo é cinquenta um","O segundo é cinquenta dois","O segundo é cinquenta três","O segundo é cinquenta quatro","O segundo é cinquenta cinco","O segundo é cinquenta seis","O segundo é cinquenta sete","O segundo é cinquenta oito","O segundo é cinquenta nove",
             "O primeiro é sessenta",                                                                                                                                                                                                                                                                                     "O segundo é sessenta", "O segundo é sessenta um","O segundo é sessenta dois","O segundo é sessenta três","O segundo é sessenta quatro","O segundo é sessenta cinco","O segundo é sessenta seis","O segundo é sessenta sete","O segundo é sessenta oito","O segundo é sessenta nove",
             "O primeiro é setenta",                                                                                                                                                                                                                                                                                      "O segundo é setenta",  "O segundo é setenta um","O segundo é setenta dois","O segundo é setenta três","O segundo é setenta quatro","O segundo é setenta cinco","O segundo é setenta seis","O segundo é setenta sete","O segundo é setenta oito","O segundo é setenta nove",
             "O primeiro é oitenta",                                                                                                                                                                                                                                                                                      "O segundo é oitenta",  "O segundo é oitenta um","O segundo é oitenta dois","O segundo é oitenta três","O segundo é oitenta quatro","O segundo é oitenta cinco","O segundo é oitenta seis","O segundo é oitenta sete","O segundo é oitenta oito","O segundo é oitenta nove",
             "O primeiro é noventa",                                                                                                                                                                                                                                                                                      "O segundo é noventa",  "O segundo é noventa um","O segundo é noventa dois","O segundo é noventa três","O segundo é noventa quatro","O segundo é noventa cinco","O segundo é noventa seis","O segundo é noventa sete","O segundo é noventa oito","O segundo é noventa nove",
             "O primeiro é cem",                                                                                                                                                                                                                                                                                          "O segundo é cem", "O segundo é cento e um","O segundo é cento e dois","O segundo é cento e três","O segundo é cento e quatro","O segundo é cento e cinco","O segundo é cento e seis","O segundo é cento e sete","O segundo é cento e oito","O segundo é cento e nove",

             "O primeiro é duzentos",                                                                                                                                                                                                                                                                                     "O segundo é duzentos",
             "O primeiro é trezentos",                                                                                                                                                                                                                                                                                    "O segundo é trezentos",
             "O primeiro é quatrocentos",                                                                                                                                                                                                                                                                                 "O segundo é quatrocentos",
             "O primeiro é quinhentos",                                                                                                                                                                                                                                                                                   "O segundo é quinhentos",
             "O primeiro é seiscentos",                                                                                                                                                                                                                                                                                   "O segundo é seiscentos",
             "O primeiro é setecentos",                                                                                                                                                                                                                                                                                   "O segundo é setecentos",
             "O primeiro é oitocentos",                                                                                                                                                                                                                                                                                   "O segundo é oitocentos",
             "O primeiro é novecentos",                                                                                                                                                                                                                                                                                   "O segundo é novecentos",
             "O primeiro é mil",                                                                                                                                                                                                                                                                                          "O segundo é mil",
             "O primeiro é dois mil",                                                                                                                                                                                                                                                                                     "O segundo é dois mil",
             "O primeiro é três mil",                                                                                                                                                                                                                                                                                     "O segundo é três mil",
             "O primeiro é quatro mil",                                                                                                                                                                                                                                                                                   "O segundo é quatro mil",
             "O primeiro é cinco mil",                                                                                                                                                                                                                                                                                    "O segundo é cinco mil",
             "O primeiro é seis mil",                                                                                                                                                                                                                                                                                     "O segundo é seis mil",
             "O primeiro é sete mil",                                                                                                                                                                                                                                                                                     "O segundo é sete mil",
             "O primeiro é oito mil",                                                                                                                                                                                                                                                                                     "O segundo é oito mil",
             "O primeiro é nove mil",                                                                                                                                                                                                                                                                                     "O segundo é nove mil",
             "O primeiro é dez mil",                                                                                                                                                                                                                                                                                      "O segundo é dez mil",
             "O primeiro é cem mil",                                                                                                                                                                                                                                                                                      "O segundo é cem mil",
             "O primeiro é um milhão",                                                                                                                                                                                                                                                                                    "O segundo é um milhão",
             "O primeiro é um bilhão",                                                                                                                                                                                                                                                                                    "O segundo é um bilhão"












            }; // comandos para o programa
            Choices c_comandos = new Choices(comandosSist);
            GrammarBuilder gb_comandos = new GrammarBuilder();
            gb_comandos.Append(c_comandos);
            Grammar g_comandos = new Grammar(gb_comandos);
            g_comandos.Name = "sistema";

            engine.LoadGrammar(g_gramatica);
            engine.LoadGrammar(g_comandos);

            engine.SpeechRecognized += rec;
            engine.RecognizeAsync(RecognizeMode.Multiple); // inicializador
            Console.Write("\nRose iniciada......");
            Console.ReadLine();
        }

        private static void rec(object re, SpeechRecognizedEventArgs resul)
        {
            if (resul.Result.Confidence >= 0.4f)
            {
                string resposta = resul.Result.Text;

                Console.WriteLine("voce disse{0} confiança{1}", resposta, resul.Result.Confidence);


                switch (resul.Result.Grammar.Name)
                {
                    case "grama":
                        proceGrama(resposta);
                        break;

                    case "sistema":
                        procesistem(resposta);
                        break;
                    default:
                        break;
                }

                
                
            }
            else
            {
                speak("Não ouvi sua voz");
            }
        }

        private static void proceGrama(string grama)
        {

            string periodo = "";
            double hr = 18;
            hr = double.Parse(DateTime.Now.ToString("HH"));
            if (hr >= 12 && hr < 18)
            {
                periodo = "boa tarde";
            }
            else
            {
                if (hr >= 00 && hr < 12)
                {
                    periodo = "bom dia";
                }
                else
                {
                    periodo = "boa noite";
                }
            }

            switch (grama)
            {
                case "qual é o seu nome":
                    speak("Rose");
                    break;
                case "Rose":
                    Random rd = new Random();
                    string[] res = { "Estou ouvindo", "Estou aqui", "Em que posso ajudar ?" };
                    speak(res[rd.Next(3)]);

                    break;

                case "como você está":
                    speak("Ótima, sou um programa, então enquanto a maquina estiver ligada, eu estarei bem.");
                    break;

                case "Olá":
                    speak("Olá, como vai");

                    break;

                case "boa noite":
                    if (periodo == "boa noite")
                    {
                        speak("boa noite");

                    }
                    else
                    {
                        speak("boa noite, " + "apesar de ser " + periodo);
                    }
                    break;
                case "bom dia":
                    if (periodo == "bom dia")
                    {
                        speak("bom dia");
                    }
                    else
                    {
                        speak("bom dia , " + "apesar de ser " + periodo);
                    }
                    break;
                case "boa tarde":
                    if (periodo == "boa tarde")
                    {
                        speak("boa tarde");
                    }
                    else
                    {
                        speak("Boa tarde, " + "apesar de ser " + periodo);
                    }
                    break;
                




            }
        }
        
        private static void procesistem(string comando)
        {

            double result = 0; 

            switch (comando)
            {
                case "calculadora":
                    speak("qual o primeiro número de 0 a 10 ?");
                    break;

                case "Operação soma":
                    result = nro1 + nro2;
                    speak("O resultado é "+Convert.ToString(result));
                    nro1 = 0; nro2 = 0;
                    break;

                case "Operação divisão":
                    result = nro1 / nro2;
                    speak("O resultado é " + Convert.ToString(result));
                    nro1 = 0; nro2 = 0;
                    break;

                case "Operação multiplicação":
                    result = nro1 * nro2;
                    speak("O resultado é " + Convert.ToString(result));
                    nro1 = 0; nro2 = 0;
                    break;

                case "Operação subtração":
                    if (nro1 > nro2)
                    {
                        result = nro1 - nro2;
                    }
                    else
                    {
                        result = nro2 - nro1;
                    }
                    
                    speak("O resultado é " + Convert.ToString(result));
                    nro1 = 0; nro2 = 0;
                    break;








                case "O primeiro é um":
                    nro1 += 1;
                    speak("Qual o segundo número ?");
                    break;

                case "O primeiro é dois":
                    nro1 += 2;
                    speak("Qual o segundo número ?");
                    break;

                case "O primeiro é três":
                    nro1 += 3;
                    speak("Qual o segundo número ?");
                    break;

                case "O primeiro é quatro":
                    nro1 += 4;
                    speak("Qual o segundo número ?");
                    break;

                case "O primeiro é cinco":
                    nro1 += 5;
                    speak("Qual o segundo número ?");
                    break;

                case "O primeiro é seis":
                    nro1 += 6;
                    speak("Qual o segundo número ?");
                    break;

                case "O primeiro é sete":
                    nro1 += 7;
                    speak("Qual o segundo número ?");
                    break;

                case "O primeiro é oito":
                    nro1 += 8;
                    speak("Qual o segundo número ?");
                    break;

                case "O primeiro é nove":
                    nro1 += 9;
                    speak("Qual o segundo número ?");
                    break;

                case "O primeiro é dez":
                    nro1 += 10;
                    speak("Qual o segundo número ?");
                    break;







                case "O segundo é um":
                    nro2 += 1;
                    speak("Qual a operação desejada ?");
                    break;

                case "O segundo é dois":
                    nro2 += 2;
                    speak("Qual a operação desejada ?");
                    break;

                case "O segundo é três":
                    nro2 += 3;
                    speak("Qual a operação desejada ?");
                    break;

                case "O segundo é quatro":
                    nro2 += 4;
                    speak("Qual a operação desejada ?");
                    break;

                case "O segundo é cinco":
                    nro2 += 5;
                    speak("Qual a operação desejada ?");
                    break;

                case "O segundo é seis":
                    nro2 += 6;
                    speak("Qual a operação desejada ?");
                    break;

                case "O segundo é sete":
                    nro2 += 7;
                    speak("Qual a operação desejada ?");
                    break;

                case "O segundo é oito":
                    nro2 += 8;
                    speak("Qual a operação desejada ?");
                    break;

                case "O segundo é nove":
                    nro2 += 9;
                    speak("Qual a operação desejada ?");
                    break;

                case "O segundo é dez":
                    nro2 += 10;
                    speak("Qual a operação desejada ?");
                    break;






                case "Que horas são":

                    speak(DateTime.Now.ToShortTimeString());
                    break;

                case "Que dia é hoje":

                    speak(DateTime.Now.ToShortDateString());
                    break;

                case "Abrir google":

                    System.Diagnostics.Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe");
                    break;

                case "Fechar google":

                    foreach (Process p in Process.GetProcesses())
                    {
                        string nome = p.ProcessName.ToLower();
                        if (nome == "chrome") p.Kill();
                    }
                    break;
                
                case "Encerrar Rose":
                   
                    Environment.Exit(0);
                    break;

                case "me conte uma piada":
                    Random pi = new Random();
                    string[] piadas = {
                     "Chefe, quero um aumento... Saiba o senhor que tem três empresas atrás de mim. Quais?.... A de água, a de luz e a de telefone, sou a melhor em contar piadas, kkkkk",
                     "Sabe o que o melão estava fazendo de mãos dadas com o mamão perto de Copacabana?.Levando o mamão papaya, eu dou risada por você, kkkkk",
                     "Quanto é o cafezinho?. 2 reais. E o açúcar?. O açúcar a gente não cobra. Então pode me ver 2 quilos, por favor, kkkkk, eu sei essa foi boa",
                     "Um pai disse ao filho: Se você tirar nota baixa na prova de amanhã, me esqueça!. No dia seguinte, quando ele voltou da escola, o pai perguntou: E aí, como foi na prova?. O filho respondeu: Quem é você ?, só a melhores piadas, kkkk",
                     "Frágil, fraco, e sem forças... Mas chega de falar de você, e vamos para a piada kkkk"
                    };
                    speak(piadas[pi.Next(5)]);
                    break;

                case "leia meu texto":
                    string ler = "";
                    StreamReader read = new StreamReader(@"C:\dados\daniel.txt");
                    
                    //ler = read.ReadToEnd();// le o txt todo

                    speak(ler = read.ReadToEnd());
                    read.Close();
                    break;


            }
            





        }



        private static void speak(string text)
        {
            voz.SpeakAsyncCancelAll();
            voz.SpeakAsync(text);
        }





        static double pegadouble(string msg)
        {
            double x = 0;
            Console.Write(msg);

            double.TryParse(Console.ReadLine(), out x);
            return x;
        }

        static int pegaint(string msg)
        {
            int x = 0;
            Console.Write(msg);

            int.TryParse(Console.ReadLine(), out x);
            return x;
        }



    }
}   
