using System;
using System.Diagnostics;
using System.Windows;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace SpeechAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        Choices choices = new Choices();
        SpeechRecognitionEngine speechRecognition = new SpeechRecognitionEngine();
        bool awake = true;
        public MainWindow()
        {
            InitializeComponent();

            InputTxt.IsReadOnly = true;
            OutputTxt.IsReadOnly = true;

            GreetMe();

            choices.Add(new string[] { "hello", "how are you", "what time is it", "open google", "sleep", "wake", "restart", "open git", "close git " });

            Grammar grammar = new Grammar(new GrammarBuilder(choices));

            try
            {
                speechRecognition.RequestRecognizerUpdate();
                speechRecognition.LoadGrammar(grammar);
                speechRecognition.SpeechRecognized += SpeechRecognitionOnSpeechRecognized;
                speechRecognition.SetInputToDefaultAudioDevice();
                speechRecognition.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void GreetMe()
        {
            synthesizer.Speak("Hello Pavel");
        }

        private void Say(string text)
        {
            OutputTxt.AppendText(text + "\n");
            synthesizer.Speak(text);
        }

        private void SpeechRecognitionOnSpeechRecognized(object sender,
            SpeechRecognizedEventArgs speechRecognizedEventArgs)
        {
            string text = speechRecognizedEventArgs.Result.Text;


            if (text.Equals("wake"))
            {
                awake = true;
                Statelbl.Content = "Awake";
            }
            if (text.Equals("sleep"))
            {
                awake = false;
                Statelbl.Content = "Sleeping";
            }


            if (awake == true)
            {
                if (text.Equals("hello"))
                {
                    Say("Hey");
                }
                if (text.Equals("how are you"))
                {
                    Say("I'm good, how are you?");
                }
                if (text.Equals("what time is it"))
                {
                    Say(DateTime.Now.ToString("h:mm tt"));
                }
                if (text.Equals("open google"))
                {
                    Process.Start(
                        "https://www.youtube.com/watch?v=DraCptKRg28&index=13&list=PLuTSXWlOadXOCEfgFic0Q4CwaydRRYJrr");
                }
                if (text.Equals("restart"))
                {
                    Process.Start(@"C:\Users\oture\Source\Repos\SpeechAI\bin\Debug\SpeechAI.exe");
                    Environment.Exit(0);
                }
                if (text.Equals("open git"))
                {
                    Process.Start(@"C:\Program Files\Git\git-bash.exe");
                }
                if (text.Equals("close git"))
                {
                    KillProcess("");
                }
                InputTxt.AppendText(text + "\n");
            }
        }

        public static void KillProcess(string processName)
        {
            Process[] processes = null;
            try
            {
                processes = Process.GetProcessesByName(processName);
                Process process = processes[0];

                if (!process.HasExited)
                {
                    process.Kill();
                }
            }
            finally
            {
                if (processes != null)
                {
                    foreach (var p in processes)
                    {
                        p.Dispose();
                    }
                }
            }

        }
    }
}