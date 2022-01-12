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
using System.Windows.Shapes;

namespace TabMenu
{
    /// <summary>
    /// Interaction logic for TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        public TableWindow()
        {
            InitializeComponent();
        }

        public TableWindow(Dictionary<char, List<bool>> lattersCodes)
        {
            InitializeComponent();

            Dictionary<string, string> temp = new Dictionary<string, string>();

            foreach (var elem in lattersCodes)
            {
                string str = "";
                for (int i =0; i<elem.Value.Count; i++)
                {
                    if (elem.Value[i] == true) str += "1";
                    else str += "0";
                }

                string str1 = elem.Key.ToString();

                switch (elem.Key)
                {
                    case ' ':
                        str1 = "SPACE";
                        break;
                    case '\n':
                        str1 = "\\n";
                        break;
                    case '\r':
                        str1 = "\\r";
                        break;
                    case '\t':
                        str1 = "\\t";
                        break;

                }

                temp.Add(str1, str);
            }
            Items.ItemsSource = temp;

        }
    }
}
