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
using OSGeo.GDAL;
using OSGeo.OGR;

namespace HydroGIS
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

        }
        private static void PrintDriversGdal()
        {
            int num = Gdal.GetDriverCount();
            for (int i = 0; i < num; i++) {
                var driver = Gdal.GetDriver(i);
                Console.WriteLine(string.Format("GDAL {0}: {1}-{2}", i, driver.ShortName, driver.LongName));
            }
        }

        private static void PrintDriversOgr()
        {
            int num = Ogr.GetDriverCount();
            for (int i = 0; i < num; i++) {
                var driver = Ogr.GetDriver(i);
                Console.WriteLine(string.Format("OGR {0}: {1}", i, driver.name));
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Gdal.AllRegister();
            Ogr.RegisterAll();
            PrintDriversGdal();
            PrintDriversOgr();
        }
    }
}
