using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace bot
{
    public class EnCrypt
    {
        public string EncryptOrDecrypt(string text, string key)
        {
            var result = new StringBuilder();
            while (key.Length < text.Length)
                key = "0" + key;
            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c]));

            return result.ToString();
        }
    }
    //mmc class
    class MMC
    {
        Dictionary<string, int> accounts = new Dictionary<string, int>();

        public void Transfer(string sender, string getter, uint sum)
        {
            if (accounts[sender] >= sum)
            {
                UpdateBalance(sender, Convert.ToInt32(-sum));
                UpdateBalance(getter, Convert.ToInt32(sum));

            }


        }
        public void UpdateBalance(string @account, int sum)
        {
            accounts[@account] += sum;
            UpdateFile();
        }
        public void UpdateFile()
        {
            using (StreamWriter sw = new StreamWriter(@"d:\doc\cc\data.mmc"))
            {

                foreach (string account in accounts.Keys)
                {
                    sw.WriteLine(account + " " + accounts[account]);
                }
            }

        }
        public string ViewBalance(string user)
        {
            return accounts[user].ToString();
        }
        public MMC()
        {
            using (StreamReader sr = File.OpenText(@"d:\doc\cc\data.mmc"))
            {

                while (!sr.EndOfStream)
                {
                    string t = sr.ReadLine();
                    accounts[t.Split(' ').ToArray()[0]] = Convert.ToInt32(t.Split(' ').ToArray()[1]);

                }
            }
        }
    }
    //ban class alfa
    public class Ban
    {
        string[] message;
        public void GetMessage(string message)
        {
            this.message = message.Split(' ').ToArray();
        }
        public bool NeedToBan()
        {
            bool res = true;
            int points = 0;
            try
            {
                if (Convert.ToInt32(message[1]) > 0 && Convert.ToInt32(message[1]) < 5)
                {
                    points++;
                }
                if (Convert.ToInt32(message[1]) > 4)
                {
                    points += 3;
                }
            }
            catch (Exception)
            {
                return false;
            }
            if (message[2] == "0")
            {
                points++;
            }
            if (message[3] == "0")
            {
                points++;
            }
            points += Convert.ToInt32(message[4]);
            points += Convert.ToInt32(message[5]) * 5;
            points += Convert.ToInt32(message[6]);
            var rnd = new Random();
            int good_score = rnd.Next(7, 14);
            if (points > good_score)
                res = true;
            else
                res = false;
            return res;
        }
        public string Name()
        {
            try
            {
                return message[7];
            }
            catch (Exception)
            {
                return "error";
            }
        }
    }
    //mamkate class

    public class Mamkate
    {

        int time;
        public void GetTime(int time)
        {
            this.time = Convert.ToInt32(Convert.ToDouble(time) / 0.00005);
        }
        public int years()
        {

            return time / 31536000;
        }
        public int days()
        {
            return (time - years() * 31536000) / 86400;
        }
        public int hours()
        {
            return (time - years() * 31536000 - days() * 86400) / 3600;
        }

        public int minutes()
        {
            return (time - years() * 31536000 - days() * 86400 - hours() * 3600) / 60;
        }
        public int seconds()
        {
            return (time - years() * 31536000 - days() * 86400 - hours() * 3600 - minutes() * 60);
        }
        public string Timer()
        {
            string r = " ";
            if (years() != 0)
                r += Convert.ToString(years()) + " years";
            if (days() != 0)
                r += Convert.ToString(days()) + " days";
            if (hours() != 0)
                r += Convert.ToString(hours()) + " hours";
            if (minutes() != 0)
                r += Convert.ToString(minutes()) + " minutes";
            if (seconds() != 0)
                r += Convert.ToString(seconds()) + " seconds";
            return r;
        }
        public string tr(string word)
        {
            string res = word;
            if (res.Length < 2)
            {
                res = "mamka" + res;
                return res;
            }

            while (res.Length < 6)
            {
                res = "0" + res;
            }
            if (res.Contains("i"))
            {
                res = "mamki" + res.Substring(3);
                return res;
            }
            if (res.Contains("e"))
            {
                res = "mamke" + res.Substring(3);
                return res;
            }
            if (res.Contains("o"))
            {
                res = "mamko" + res.Substring(3);
                return res;
            }
            if (res.Contains("ya"))
            {
                res = "mamkia" + res.Substring(3);
                return res;
            }
            if (res.Contains("u") || res.Contains("yu"))
            {
                res = "mamku" + res.Substring(3);
                return res;
            }
            if (res.Contains("a"))
            {
                res = "mamka" + res.Substring(3);
                return res;
            }
            else
            {
                res = "mamka" + res.Substring(3);
                return res;
            }

        }
    }
    //tranlate class
    public class Translate
    {

        public string tr(string word)
        {
            string res = word;
            if (res.Length < 2)
            {
                res = "hui" + res;
                return res;
            }

            while (res.Length < 6)
            {
                res = "0" + res;
            }
            if (res.Contains("i"))
            {
                res = "huy" + res.Substring(3);
                return res;
            }
            if (res.Contains("e"))
            {
                res = "hue" + res.Substring(3);
                return res;
            }
            if (res.Contains("o"))
            {
                res = "huy" + res.Substring(3);
                return res;
            }
            if (res.Contains("ya"))
            {
                res = "huya" + res.Substring(3);
                return res;
            }
            if (res.Contains("u") || res.Contains("yu"))
            {
                res = "huyu" + res.Substring(3);
                return res;
            }
            if (res.Contains("a"))
            {
                res = "huya" + res.Substring(3);
                return res;
            }
            else
            {
                res = "hui" + res.Substring(3);
                return res;
            }

        }
    }
    //zinia class
    public class Zinia
    {
        string[] frases = new string[]
        {
            "И жучок, и паучок это понимают, а ты нет","Опарыш ты опарыш","сейчас почешешь свое правое ухо левой рукой через задницу","Ну тюлень! Один в один!","Кубик-рубик Артурик покатился к доске, а ты покатился нах",
            "А ты, Артурик, у нас один?","Артурик, как ты думаеш, почему я всю ночь не спал?","Дежурные Кододач и Палиенко... О! Тюлень! Иди вытри доску","Богатыри!","Если светит в левый глаз значит едешь на кавказ"
        };
        public string res(Telegram.Bot.Types.Message message)
        {
            string r;
            Random random = new Random();
            int ind = random.Next(0, 11);
            if (ind == 10)
            {
                r = message.From.FirstName.ToString() + " " + message.From.LastName.ToString() + ", ты понимаешь, что ты тянешь наш класс вниз? Из-за таких разгильдяев как ты...";
            }
            else
            {
                r = frases[ind];
            }
            return r;
        }
    }
    //manvelian class
    public class Manvelka
    {
        string[] frases = new string[]
        {
            "Твоя мать - шлюха","Я ебал твою мамку","АНУ МОЛИСЬ СВЯТОЙ МАМКЕ","я нарисую карту на пзде твоей мамке и все будут знать географию","мамке своей это скажешь",
            "ты пишешь такие большие сообщения чтоб компенсировать свой маленький член","мамка","иди нахуй","я твоя мамка","плохая мамка плохая"
        };
        public string res(Telegram.Bot.Types.Message message)
        {
            string r;
            Random random = new Random();
            int ind = random.Next(0, 11);
            if (ind == 10)
            {
                r = message.From.FirstName.ToString() + " " + message.From.LastName.ToString() + ", ты понимаешь, что я ебал твою мать?";
            }
            else
            {
                r = frases[ind];
            }
            return r;
        }
    }
    //math class
    public class Math_1
    {
        long a, b, c;
        long d;
        public string input_message(string message)
        {
            try
            {
                int[] ia = message.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
                a = ia[0];
                b = ia[1];
                c = ia[2];
                return "OK";
            }
            catch (Exception e)
            {
                return "error";
            }
        }
        public void x1x2(ref double x1, ref double x2)
        {
            d = (b * b) - (4 * a * c);
            if (d == 0)
            {
                try
                {
                    x1 = (-b) / (2 * a);
                }
                catch (Exception e)
                {
                    x1 = 2.228;
                }

                x2 = 2.228;
            }
            if (d > 0)
            {
                try
                {
                    x1 = (-b + Math.Sqrt(d)) / (2 * a);

                }
                catch (Exception e)
                {
                    x1 = 2.228;
                }
                try
                {
                    x2 = (-b - Math.Sqrt(d)) / (2 * a);
                }
                catch (Exception e)
                {
                    x2 = 2.228;
                }
            }
            if (d < 0)
            {
                x1 = 2.228;
                x2 = 2.228;
            }

        }
    }
    public partial class Form1 : Form
    {
        Math_1 math_1 = new Math_1();
        BackgroundWorker bw;
        anime_stack.stack as1 = new anime_stack.stack();
        public Form1()
        {
            InitializeComponent();
            this.bw = new BackgroundWorker();
            this.bw.DoWork += this.bw_DoWork;

        }

        async void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            bool answer = false;
            var translate = new Translate();
            var worker = sender as BackgroundWorker;
            Telegram.Bot.Types.User u = new Telegram.Bot.Types.User();
            var key = e.Argument as String;
            try
            {
                var Bot = new Telegram.Bot.TelegramBotClient(key);
                await Bot.SetWebhookAsync("");

                int offset = 0;
                while (true)
                {
                    var updates = await Bot.GetUpdatesAsync(offset);

                    foreach (var update in updates)
                    {
                        var message = update.Message;
                        if (message == null)
                        {
                            continue;
                        }/*
                        if ((message.Type == Telegram.Bot.Types.Enums.MessageType.StickerMessage)&&(message.From.FirstName=="Infinity"))
                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);*/
                        if (message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage)
                        {
                            //music
                            /*if(message.Text.Contains("/music"))
                            {
                                Telegram.Bot.Types.FileToSend f = new Telegram.Bot.Types.FileToSend("https://www.dropbox.com/s/1nwbwwe8d4m58uk/Death%20Note%20-%20L%27s%20Theme%20%28full%29.mp3");
                                await Bot.SendDocumentAsync(message.Chat.Id, f, "here it`s");
                            }*/
                            //crypt
                            //MMC bank = new MMC();
                            DateTime d = DateTime.Now;
                            /*
                            if (d.Minute % 15 == 0)
                                await Bot.SendTextMessageAsync(message.Chat.Id, "have you done your homework?");
                                */
                            if (message.Text.Contains("/encrypt"))
                            {
                                EnCrypt crypt = new EnCrypt();

                                try
                                {
                                    string[] s = message.Text.Split(' ').ToArray();
                                    string res = crypt.EncryptOrDecrypt(message.Text.Substring(message.Text.IndexOf("t") + 2), "1234");
                                    await Bot.SendTextMessageAsync(message.Chat.Id, res, replyToMessageId: message.MessageId);


                                }
                                catch (Exception)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "error", replyToMessageId: message.MessageId);
                                }
                                try
                                {
                                    await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                }
                                catch (Exception)
                                {

                                }


                            }
                            if(message.Text.Contains("/addanime"))
                            {
                                try
                                {
                                    string[] s = message.Text.Split(' ').ToArray();
                                    as1.anime_links = s[1];
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "completed");
                                }
                                catch(Exception)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "error");

                                }

                            }
                            if (message.Text.Contains("/getanime"))
                            {
                                try
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, as1.anime_links);
                                }
                                catch(Exception)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "error");

                                }
                            }
                            if (message.Text == "/resetanimelist")
                            {
                                try
                                {
                                    as1.restart();
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "completed");

                                }
                                catch (Exception)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "error");

                                }
                            }
                            /*
                        if (message.Text.Contains("/storeinfo"))
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "1) unban 1 day - 10mmc\n2) pirozhok - 500 mmc\n3) admin rights - 5000 mmc ");
                        }
                        if (message.Text.Contains("/buy"))
                        {
                            string[] s = message.Text.Split(' ').ToArray();
                            if (s.Length < 2)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "invalid syntax", replyToMessageId: message.MessageId);
                                // await Bot.SendTextMessageAsync(message.Chat.Id, s[1], replyToMessageId: message.MessageId);

                                continue;
                            }



                            int sum = 1000000;
                            string action = String.Empty;
                            switch (s[1])
                            {
                                case "1":
                                    {
                                        sum = 10;
                                        action = "@pauchok1love please give -1 day of ban to @" + message.From.Username;
                                        break;
                                    }
                                case "2":
                                    {
                                        sum = 500;
                                        action = "@pauchok1love please give pirozhok to @" + message.From.Username;
                                        break;
                                    }
                                case "3":
                                    {
                                        sum = 5000;
                                        action = "@pauchok1love please give admin rights to @" + message.From.Username;

                                        break;
                                    }
                                default:
                                    {
                                        await Bot.SendTextMessageAsync(message.Chat.Id, "invalid syntax", replyToMessageId: message.MessageId);
                                        continue;


                                    }
                            }
                            if (Convert.ToInt32(bank.ViewBalance("@" + message.From.Username)) >= sum)
                            {
                                try
                                {
                                    bank.UpdateBalance("@" + message.From.Username, -sum);
                                    await Bot.SendTextMessageAsync(message.Chat.Id, action, replyToMessageId: message.MessageId);
                                }
                                catch (Exception)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "invalid syntax", replyToMessageId: message.MessageId);
                                }
                            }
                        }
                        if (message.Text.Contains("/viewbalance"))
                        {
                            try
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, bank.ViewBalance(message.Text.Split(' ').ToArray()[1]), replyToMessageId: message.MessageId);
                            }
                            catch (Exception)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "invalid syntax", replyToMessageId: message.MessageId);
                            }

                        }
                        if (message.Text.Contains("/updatebalance"))
                        {
                            if (message.From.Username == "pauchok1love")
                            {
                                try
                                {
                                    bank.UpdateBalance(message.Text.Split(' ').ToArray()[1], Convert.ToInt32(message.Text.Split(' ').ToArray()[2]));
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "completed!", replyToMessageId: message.MessageId);

                                }
                                catch (Exception)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "invalid syntax", replyToMessageId: message.MessageId);

                                }

                            }
                            else
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "u have no rights for that", replyToMessageId: message.MessageId);
                            }
                        }
                        if (message.Text.Contains("/transfer"))
                        {

                            string[] s = message.Text.Split(' ').ToArray();
                            if (s.Length < 4)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "invalid syntax", replyToMessageId: message.MessageId);
                                continue;
                            }

                            if (Convert.ToInt32(s[3]) > 0 && message.From.Username == s[1].Substring(1))
                            {
                                try
                                {
                                    bank.Transfer(s[1], s[2], Convert.ToUInt32(s[3]));
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "completed!", replyToMessageId: message.MessageId);
                                }
                                catch (Exception)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "invalid syntax", replyToMessageId: message.MessageId);

                                }
                            }
                            else
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "please, insert positive sum, whic you have on your balance", replyToMessageId: message.MessageId);

                            }
                        }*/
                            //rev
                            if (message.Text.ToLower().Contains("/realrevolution"))
                            {

                                try
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "It`s a revolution.", replyToMessageId: message.MessageId);
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "В основном(5 человек) поддержали идею свержения Дани за:");
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "•	Смену названия группы");
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "•	Ненависть к аниме");
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "•	Нечестные глосования(накрутка)");
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Итак, мы свергаем его, и всеми банами/нарушениями будет заниматся БОТ. Только система будет определять меру присечения человека.");

                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Админами будут я Бот, и тот, кого выберут на новом голо-и.");
                                    await Bot.SetChatTitleAsync(message.Chat.Id, "AAA club oficial");
                                }
                                catch (Exception)
                                {

                                }
                            }
                            //ban

                            if (message.Text.ToLower().Contains("/ban"))
                            {

                                var ban = new Ban();
                                try
                                {
                                    ban.GetMessage(message.Text);
                                }
                                catch (Exception)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, message.From.FirstName + " " + message.From.LastName + "(" + message.From.Username + " pidor ne lamay bota");
                                }

                                if (ban.NeedToBan())
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Sviatoslav(@pauchok1love) ban please " + ban.Name(), replyToMessageId: message.MessageId);

                                }
                                else
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "system don`t need to ban " + ban.Name(), replyToMessageId: message.MessageId);


                            }
                            //counter
                            if (message.Text.ToLower().Contains("/counter"))
                            {
                                if (message.Text.Substring(message.Text.IndexOf("r") + 2).Length > 5)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "error");
                                    continue;
                                }
                                Mamkate mamkate = new Mamkate();
                                mamkate.GetTime(Convert.ToInt32(message.Text.Substring(message.Text.IndexOf("r") + 2)));

                                try
                                {

                                    await Bot.SendTextMessageAsync(message.Chat.Id, mamkate.Timer());
                                }
                                catch (Exception)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "error");
                                }
                            }
                            //trigger
                            if (message.Text.Contains("/trigger"))
                            {
                                if (message.Text.ToLower().Contains("dania") || message.Text.ToLower().Contains("даня"))
                                {
                                    Telegram.Bot.Types.FileToSend f = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/ee1rvx/image.png");
                                    Telegram.Bot.Types.FileToSend f2 = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/mR9Gfx/20180228_073506_1.jpg");
                                    Telegram.Bot.Types.FileToSend f1 = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/janjhc/image.png");
                                    await Bot.SendPhotoAsync(message.Chat.Id, f, "trigger #1");
                                    await Bot.SendPhotoAsync(message.Chat.Id, f1, "trigger #2");
                                    await Bot.SendPhotoAsync(message.Chat.Id, f2, "trigger #3");
                                }
                                if (message.Text.ToLower().Contains("mark") || message.Text.ToLower().Contains("марк"))
                                {
                                    Telegram.Bot.Types.FileToSend f = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/nMRLOH/image.png");

                                    Telegram.Bot.Types.FileToSend f1 = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/dOnMVx/image.png");
                                    await Bot.SendPhotoAsync(message.Chat.Id, f, "trigger #1");
                                    await Bot.SendPhotoAsync(message.Chat.Id, f1, "trigger #2");
                                }
                                if (message.Text.ToLower().Contains("slavka") || message.Text.ToLower().Contains("славка"))
                                {
                                    Telegram.Bot.Types.FileToSend f = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/gjhzHc/image.png");
                                    Telegram.Bot.Types.FileToSend f2 = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/jsLiCn/image.png");
                                    Telegram.Bot.Types.FileToSend f1 = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/cJvEiH/image.png");
                                    await Bot.SendPhotoAsync(message.Chat.Id, f, "trigger #1");
                                    await Bot.SendPhotoAsync(message.Chat.Id, f1, "trigger #2");
                                    await Bot.SendPhotoAsync(message.Chat.Id, f2, "trigger #3");
                                }
                                if (message.Text.ToLower().Contains("artur") || message.Text.ToLower().Contains("arturik") || message.Text.ToLower().Contains("артур") || message.Text.ToLower().Contains("артурик"))
                                {
                                    Telegram.Bot.Types.FileToSend f = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/cC4tAx/image.png");
                                    Telegram.Bot.Types.FileToSend f1 = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/e3PRVx/image.png");
                                    Telegram.Bot.Types.FileToSend f2 = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/bMt8Sc/image.png");
                                    await Bot.SendPhotoAsync(message.Chat.Id, f, "trigger #1");
                                    await Bot.SendPhotoAsync(message.Chat.Id, f1, "trigger #2");
                                    await Bot.SendPhotoAsync(message.Chat.Id, f2, "trigger #3");
                                }
                                if (message.Text.ToLower().Contains("paliy") || message.Text.ToLower().Contains("палий"))
                                {
                                    Telegram.Bot.Types.FileToSend f = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/mYqBxc/image.png");
                                    Telegram.Bot.Types.FileToSend f1 = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/ddXmfx/image.png");
                                    await Bot.SendPhotoAsync(message.Chat.Id, f, "trigger #1");
                                    await Bot.SendPhotoAsync(message.Chat.Id, f1, "trigger #2");
                                }
                            }
                            //fox
                            if (message.Text.ToLower().Contains("fox"))
                            {
                                Telegram.Bot.Types.FileToSend fs = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/cfkqJS/image.png");
                                await Bot.SendPhotoAsync(message.Chat.Id, fs, "here is a fox #1");
                                Telegram.Bot.Types.FileToSend fs1 = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/h0hqk7/image.png");
                                await Bot.SendPhotoAsync(message.Chat.Id, fs1, "here is a fox #2");
                            }
                            //say(need to upgrate)

                            if (message.Text == "/say" || message.Text == "/say@aaaclub_bot")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "slavka", replyToMessageId: message.MessageId);

                            }
                            //anime need to upgrate
                            if (message.Text == "/anime" || message.Text == "/anime@aaaclub_bot")
                            {

                                //await Bot.SendTextMessageAsync(message.Chat.Id, "Chose ganre", replyToMessageId: message.MessageId);
                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[]
                                    {
                                        new[]
                                        {
                                        new Telegram.Bot.Types.KeyboardButton("for paliy"),
                                        new Telegram.Bot.Types.KeyboardButton("for Fedka"),
                                new Telegram.Bot.Types.KeyboardButton("for normal people"),
                                new Telegram.Bot.Types.KeyboardButton("for artuturik")
                                        },

                                    },
                                    ResizeKeyboard = true
                                };
                                keyboard.OneTimeKeyboard = true;
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Chose ganre?", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
                            }
                            //monday
                            if (message.Text == "/monday" || message.Text == "/monday@aaaclub_bot")
                            {
                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[]
                                    {
                                        new[]
                                        {
                                        new Telegram.Bot.Types.KeyboardButton("yes, i`m ready"),
                                new Telegram.Bot.Types.KeyboardButton("no, i`m not ready")
                                        },
                                    },
                                    ResizeKeyboard = true
                                };
                                keyboard.OneTimeKeyboard = true;

                                await Bot.SendTextMessageAsync(message.Chat.Id, "are u ready to zalupa?", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
                            }
                            //answer to sqr
                            if (answer)
                            {
                                try
                                {
                                    string s = message.Text.ToLower();
                                    if (math_1.input_message(s) == "error")
                                    {
                                        await Bot.SendTextMessageAsync(message.Chat.Id, "error", replyToMessageId: message.MessageId);
                                    }
                                    else
                                    {
                                        double x1 = 0, x2 = 0;
                                        math_1.x1x2(ref x1, ref x2);
                                        if (x1 == 2.228 && x2 == 2.228)
                                        {
                                            await Bot.SendTextMessageAsync(message.Chat.Id, "there are no roots", replyToMessageId: message.MessageId);
                                        }
                                        if (x2 == 2.228 && x1 != 2.228)
                                        {
                                            await Bot.SendTextMessageAsync(message.Chat.Id, "there is one root: " + Convert.ToString(x1), replyToMessageId: message.MessageId);
                                        }
                                        if (x1 != 2.228 && x2 != 2.228)
                                        {
                                            await Bot.SendTextMessageAsync(message.Chat.Id, "thereare two roots: " + Convert.ToString(x1) + " " + Convert.ToString(x2), replyToMessageId: message.MessageId);
                                        }
                                    }
                                    answer = false;
                                }
                                catch (Telegram.Bot.Exceptions.ApiRequestException ex)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "error", replyToMessageId: message.MessageId);
                                }
                            }
                            //sqr
                            if (message.Text == "/sqr" || message.Text == "/sqr@aaaclub_bot")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "send me numbers", replyToMessageId: message.MessageId);
                                answer = true;
                            }
                            //manvelka answer
                            if (message.Text.ToLower().Contains("manv") || message.Text.ToLower().Contains("манв") || message.Text.ToLower().Contains("monv") || message.Text.ToLower().Contains("монв"))
                            {
                                Manvelka manvelka = new Manvelka();

                                await Bot.SendTextMessageAsync(message.Chat.Id, manvelka.res(message), replyToMessageId: message.MessageId);
                            }
                            //zinia answer
                            if ((message.Text.ToLower().Contains("zinia") || message.Text.ToLower().Contains("зиня")) && !message.Text.ToLower().Contains("/zinia"))
                            {
                                Zinia zinia = new Zinia();

                                await Bot.SendTextMessageAsync(message.Chat.Id, zinia.res(message), replyToMessageId: message.MessageId);
                            }
                            //photo #1
                            if (message.Text == "/mamka" || message.Text == "/mamka@aaaclub_bot")
                            {

                                Telegram.Bot.Types.FileToSend fs = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/joBJ7c/image.png");
                                await Bot.SendPhotoAsync(message.Chat.Id, fs, "mamka");
                            }
                            //photo #2
                            if (message.Text == "/doge" || message.Text == "/doge@aaaclub_bot")
                            {

                                Telegram.Bot.Types.FileToSend fs = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/dHKuxc/image.png");
                                await Bot.SendPhotoAsync(message.Chat.Id, fs, "doge #1");
                                Telegram.Bot.Types.FileToSend fs2 = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/eV56Ax/image.png");
                                await Bot.SendPhotoAsync(message.Chat.Id, fs2, "doge #2");
                                Telegram.Bot.Types.FileToSend fs3 = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/cQhQ3H/image.png");
                                await Bot.SendPhotoAsync(message.Chat.Id, fs3, "doge #3");
                                Telegram.Bot.Types.FileToSend fs4 = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/cgajxc/image.png");
                                await Bot.SendPhotoAsync(message.Chat.Id, fs4, "doge #4");
                            }
                            //mark`s code
                            if (message.Text == "/pron" || message.Text == "/pron@aaaclub_bot")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "zaidi v kod marka: https://drive.google.com/open?id=1_MTeOLrL1KMg2bP7jCob7fRSeOL0-osg", replyToMessageId: message.MessageId);
                            }
                            //nakuzin
                            if (message.Text == "/nakuzin")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "hAAAAA NAEBAL!");
                            }
                            //mining
                            if (message.Text == "/mining" || message.Text == "/mining@aaaclub_bot")
                            {
                                Telegram.Bot.Types.FileToSend fs = new Telegram.Bot.Types.FileToSend("https://media.giphy.com/media/cAy7aIZ4dv5KiOAjFs/giphy.gif");
                                await Bot.SendDocumentAsync(message.Chat.Id, fs, "mayni dogecoini: https://cryptocash.guru/coin/dogecoin/majning-kriptovalyuty-dogecoin/");
                            }
                            //answers
                            if (message.Text.ToLower() == "yes, i`m ready")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "then u will die from biologi", replyToMessageId: message.MessageId);
                            }

                            if (message.Text.ToLower() == "no, i`m not ready")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "you will die on zalupa", replyToMessageId: message.MessageId);
                            }
                            if (message.Text.ToLower() == "for normal people")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "go to yummyanime.com/catalog/item/milyj-vo-frankce", replyToMessageId: message.MessageId);
                            }
                            if (message.Text.ToLower() == "for paliy")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "https://yummyanime.com/catalog/item/lyubovnye-nepriyatnosti-tv1", replyToMessageId: message.MessageId);
                            }
                            if (message.Text.ToLower() == "for artuturik")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "https://yummyanime.com/catalog/item/plastikovye-vospominaniya", replyToMessageId: message.MessageId);

                            }
                            if (message.Text.ToLower() == "for fedka")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "https://yummyanime.com/catalog/item/neveroyatnye-priklyucheniya-dzhodzho-tv-1", replyToMessageId: message.MessageId);

                            }
                            //anime hater
                            if ((message.Text.ToLower().Contains("anime") || message.Text.ToLower().Contains("аниме")) && !message.Text.ToLower().Contains("/"))
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "ANIME - tupoe govno tupogo govna", replyToMessageId: message.MessageId);
                            }
                            //translate

                            if (message.Text.ToLower().Contains("/translate"))
                            {
                                int index = message.Text.ToLower().IndexOf("e");
                                string s_res = String.Empty;
                                try
                                {
                                    s_res = message.Text.ToLower().Substring(index + 2);
                                }
                                catch (Exception)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "error", replyToMessageId: message.MessageId);
                                }
                                await Bot.SendTextMessageAsync(message.Chat.Id, translate.tr(s_res), replyToMessageId: message.MessageId);
                            }
                            //mamkate
                            if (message.Text.ToLower().Contains("/mamkate"))
                            {
                                int index = message.Text.ToLower().IndexOf("e");
                                string s_res = String.Empty;
                                try
                                {
                                    s_res = message.Text.ToLower().Substring(index + 2);
                                }
                                catch (Exception)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "error", replyToMessageId: message.MessageId);
                                }
                                Mamkate mamkate = new Mamkate();
                                await Bot.SendTextMessageAsync(message.Chat.Id, mamkate.tr(s_res), replyToMessageId: message.MessageId);
                            }
                            //analis rechi 2117
                            if (message.Text.ToLower().Contains("kofe") || message.Text.ToLower().Contains("кофе"))
                            {
                                Telegram.Bot.Types.FileToSend file = new Telegram.Bot.Types.FileToSend("https://image.ibb.co/jag72c/image.png");
                                await Bot.SendPhotoAsync(message.Chat.Id, file, "buy kofee for me, " + message.From.FirstName);
                            }
                            if (message.Text.ToLower().Contains("didur") || message.Text.ToLower().Contains("дидур"))
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "BLYAT DIDUR PIDOR", replyToMessageId: message.MessageId);
                            }
                            if (message.Text.ToLower().Contains("amd") || message.Text.ToLower().Contains("амд"))
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "AMD IS THE BEST KOMPANY", replyToMessageId: message.MessageId);
                            }
                            if (message.Text.ToLower().Contains("intel") || message.Text.ToLower().Contains("интел"))
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "INTEL HUINIA)", replyToMessageId: message.MessageId);
                            }
                            if (message.Text.ToLower().Contains("думал") || message.Text.ToLower().Contains("думать"))
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Не надо думать, у вас такого органа нет", replyToMessageId: message.MessageId);
                            }

                            
                            if (message.Text.ToLower() .Contains("slavka daun")|| message.Text.ToLower().Contains("slavka eblan")|| message.Text.ToLower().Contains("славка даун") || message.Text.ToLower().Contains("славка еблан"))
                            {
                                //ban
                               
                                //u = message.From;
                                try
                                {
                                    await Bot.SetChatDescriptionAsync(message.Chat.Id, message.Chat.Description + "         " + message.From.FirstName + " " + message.From.LastName + " - pidrila");
                                    await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                }
                                catch(Exception)
                                {

                                }
                              
                            }/*
                            if(u.FirstName!=null)
                            if(message.From.FirstName.ToLower()==u.FirstName.ToLower())
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "SASAT, pidrila", replyToMessageId: message.MessageId);
                            }
                            */
                        }
                        offset = update.Id + 1;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            textBox1.Text = "running..";
            if (text != "" && this.bw.IsBusy != true)
            {
                this.bw.RunWorkerAsync(text);
            }

        }
    }
}
