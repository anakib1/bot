using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bot
{
    public class Store
    {
        Dictionary<string, string[]> goods = new Dictionary<string, string[]>();
        public Store()
        {
            using (StreamReader sr = File.OpenText(@"d:\doc\cc\store.mmc"))
            {

                while (!sr.EndOfStream)
                {
                    string t = sr.ReadLine();
                    goods[t.Split(' ').ToArray()[0]] = t.Split(' ').ToArray();

                }
            }
        }
        private void UpdateFile()
        {
            using (StreamWriter sw = new StreamWriter(@"d:\doc\cc\store.mmc"))
            {

                foreach (string account in goods.Keys)
                {
                    sw.WriteLine(account+" "+goods[account][0]+" "+goods[account][1]);
                }
            }

        }
        public void AddGood(string name, string info, string price)
        {
            string[] tmp = new string[2];
            tmp[0] = info;
            tmp[1] = price;
             goods.Add(name,tmp);
            UpdateFile();
        }
        public bool HasGood(string name)
        {
            if (goods.ContainsKey(name))
                return true;
            else
                return false;
        }
        public int N_of_keys()
        {
            return goods.Keys.Count;
        }
        public string ViewGoods()
        {
            string res = " ";
            int i = 4;
            foreach (string account in goods.Keys)
            {
                
                res+="\n"+ i+") "+goods[account][1] + " " + goods[account][2];
                i++;
            }
            return res;
        }
        public string GetName(int n)
        {
            return goods.Keys.ToArray()[n].ToString();
        }
        public string GetGood(int n)
        {
            return goods[goods.Keys.ToArray()[n].ToString()][1];

        }
        public int Sum_of_b(int n)
        {
            return Convert.ToInt32(goods[goods.Keys.ToArray()[n].ToString()][2]);

        }
        public void DeleteGood(string name)
        {
            goods.Remove(name);
            UpdateFile();
        }

    }
}
