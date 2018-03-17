using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace english_tests_bot
{
    public class Brake
    {
        //Dictionary<string, string> words = new Dictionary<string, string>();
        string[] ewords;
        public string now_word;
        public void SetDic(string[] w)
        {
            
            ewords = w;
            
        }
        public string w()
        {
            return ewords[0];
        }
        public char[] brakingC()
        {
            Random random = new Random();
            int index = random.Next(0, ewords.Length);
            now_word = ewords[index];
            char[] res = ewords[index].ToCharArray();
            char[] res2 = res.OrderBy(x => random.Next()).ToArray();
            return res2;
        }
        public char[] brakingC(string worda)
        {
            Random random = new Random();
            char[] res = worda.ToCharArray();
            char[] res2 = res.OrderBy(x => random.Next()).ToArray();
            return res2;
        }
        public bool GetRes(string res)
        {
            if(ewords.Contains(res.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public partial class Form1 : Form
    {
        BackgroundWorker bw;
        public Form1()
        {
            this.bw = new BackgroundWorker();
            this.bw.DoWork += this.bw_DoWork;
            InitializeComponent();
        }
        async void bw_DoWork(object sender,DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            Telegram.Bot.Types.User u = new Telegram.Bot.Types.User();
            var key = e.Argument as String;
            bool setwords = false;
            bool settranslate = false;
            string[] words=null;
            string[] wordstranslate;
            bool answer=false;
            bool second_c = false;
            string w=String.Empty;
            int n_of_tests = 0;
            bool test = false;
            Brake brake = new Brake();
            try
            {
                var Bot = new Telegram.Bot.TelegramBotClient(key);
                await Bot.SetWebhookAsync("");
                int offset = 0;
                while(true)
                {
                    var updates = await Bot.GetUpdatesAsync(offset);
                    foreach( var update in updates)
                    {
                        var message = update.Message;
                        if (message == null)
                            continue;
                        if(message.Type==Telegram.Bot.Types.Enums.MessageType.TextMessage)
                        {
                            /*
                            if (settranslate)
                            {
                                wordstranslate = message.Text.ToLower().Split(' ');
                                settranslate = false;
                                await Bot.SendTextMessageAsync(message.Chat.Id, "good, now you can practise!");
                                try
                                {
                                    brake.SetDic(wordstranslate, words);
                                }
                                catch(Exception)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "error");

                                }


                            }*/
                            if (setwords)
                            {
                                words = message.Text.ToLower().Split(' ');
                                brake.SetDic(words);
                                await Bot.SendTextMessageAsync(message.Chat.Id, "now you can start test");
                                setwords = false;

                            }
                            if (message.Text.Contains("/starttest"))
                            {
                                test = true;

                            }
                            if (message.Text.Contains("/setwords"))
                            {
                                try
                                {
                                    setwords = true;
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "please insert words in one string");
                                    test = false;
                                    n_of_tests = 0;
                                    answer = false;
                                }
                                catch(Exception)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "error");

                                }
                            }
                            if(answer)
                            {
                                if(brake.GetRes(message.Text.ToLower()))
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "yes, it`s true");
                                    second_c = false;
                                }
                                else
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "NO, try once more");
                                    second_c = true;
                                    w = brake.now_word;
                                    n_of_tests--;
                                }
                                n_of_tests++;
                            }
                           
                           
                            
                            
                            if(test)
                            {
                                try
                                {
                                    if (n_of_tests < words.Length)
                                    {
                                        if (second_c)
                                        {
                                            try
                                            {


                                                char[] tmp = brake.brakingC(w);
                                                string r = String.Empty;
                                                for (int i = 0; i < tmp.Length; i++)
                                                {
                                                    r += tmp[i] + " ";
                                                }
                                                await Bot.SendTextMessageAsync(message.Chat.Id, r);
                                            }
                                            catch (Exception)
                                            {

                                                await Bot.SendTextMessageAsync(message.Chat.Id, "error");
                                            }
                                            finally
                                            {
                                                await Bot.SendTextMessageAsync(message.Chat.Id, "Now insert word from this letters");
                                                answer = true;
                                            }
                                        }
                                        if (!second_c)
                                        {
                                            try
                                            {
                                                char[] tmp = brake.brakingC();
                                                string r = String.Empty;
                                                for (int i = 0; i < tmp.Length; i++)
                                                {
                                                    r += tmp[i] + " ";
                                                }
                                                await Bot.SendTextMessageAsync(message.Chat.Id, r);
                                            }
                                            catch (Exception)
                                            {

                                                await Bot.SendTextMessageAsync(message.Chat.Id, "error");
                                                test = false;
                                            }
                                            finally
                                            {
                                                await Bot.SendTextMessageAsync(message.Chat.Id, "Now insert word from this letters");
                                                answer = true;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        answer = false;
                                        n_of_tests = 0;
                                        test = false;
                                    }
                                }
                                catch(Exception)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id,"error");
                                }
                            }
                        }
                        offset = update.Id + 1;
                    }
                }
            }
            catch(Telegram.Bot.Exceptions.ApiRequestException)
            { 

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var text = @token_box.Text;
            if(text!=""&&!this.bw.IsBusy)
            {
                this.bw.RunWorkerAsync(text);
            }
        }
    }
}
