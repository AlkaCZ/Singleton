using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Singleton
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    /// 
    class SingletonDictionary
    {
        static SingletonDictionary singleSingletonDictionary = null;
        private static Dictionary<string, string[]> Dict;
        private static readonly object lockingObject = new object();

        //public static void AddToDict(string key, string[] info)
        //{
        //    if (!Dict.ContainsKey(key))
        //    {
        //        Dict.Add(key, info);
        //    }
        //    else
        //    {
        //        Dict[key] = info;
        //    }
        //}
        public string[] CreateField(string jmeno, string prijmeni, string datumNarozeni, string rodneCislo)
        {
            string[] s = new string[4];

            s[0] = jmeno;
            s[1] = prijmeni;
            s[2] = datumNarozeni;
            s[3] = rodneCislo;

            return s;


        }
        private SingletonDictionary()
        {
            Dict = new Dictionary<string, string[]>();
            Dict["Pavel"] = CreateField("Pavel", "Novak", "20.1.2000", "000120/358");
            Dict["Petr"] = CreateField("Petr", "Kubin", "10.12.2012", "121210/388");
            Dict["Olex"] = CreateField("Olex", "Svarta", "12.5.2007", "070512/008");


        }
        public static SingletonDictionary Instance
        {
            get
            {
                lock(lockingObject)
                {
                    if (singleSingletonDictionary == null)
                    {
                        singleSingletonDictionary = new SingletonDictionary();
                    }
                }
                MessageBox.Show("Dictionary je už vytvořen", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return singleSingletonDictionary;
            }
           
        }

        public void View(string key, TextBox tb)
        {
            if (tb.Text == "Empty")
            {
                foreach (string item in Dict[key])
                {
                    tb.Text += item;
                    tb.Text += " ";
                }
            }
            else
            {
                foreach (string item in Dict[key])
                {
                    tb.Text += item;
                    tb.Text += " ";
                }
            }
            tb.Text += "\n";
          
            
        }
    }
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {

            InitializeComponent();
            //string[] osoba1 = CreateField("Pavel", "Novotný", "20.1.2000", "000120/363");
                
                
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            tbOut.Clear();
            SingletonDictionary MyDic = SingletonDictionary.Instance;
            MyDic.View("Pavel",tbOut);
            MyDic.View("Petr", tbOut);
            MyDic.View("Olex", tbOut);
        }
    }
}
