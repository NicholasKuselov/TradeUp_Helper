using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TradeUpHelper.Constants;
using TradeUpHelper.Controllers;
using TradeUpHelper.Controllers.MarketChecker;
using TradeUpHelper.Models.MarketChecker;
using TradeUpHelper.ViewModels;

namespace TradeUpHelper.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { this.DragMove(); };
            DataContext = new MainWindowVM();
            this.SourceInitialized += new EventHandler(Window1_SourceInitialized);
        }

        void Window1_SourceInitialized(object sender, EventArgs e)
        {
            WindowSizing.WindowInitialized(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(Assembly.GetExecutingAssembly().Location.Replace("TradeUpHelper.exe",""));
            //List<RarityPainSeedScin> Scins = new List<RarityPainSeedScin>();
            //RarityPainSeedScin tmp = new RarityPainSeedScin();
            //tmp.ImageUrl = "http://media.steampowered.com/apps/730/icons/econ/default_generated/weapon_awp_hy_zodiac2_light_large.67da534322361569bd9637688b704b57232529fa.png";
            //tmp.Name = "AWP | Солнце в знаке льва";
            //List<RariryPainSeed> sssss = new List<RariryPainSeed>();
            //sssss.Add(new RariryPainSeed { Name = "Солнце в центре", Seeds = new int[] { 102, 190, 255, 308, 379, 648, 649 } });
            //sssss.Add(new RariryPainSeed { Name = "2 солнца (приклад+центр)", Seeds = new int[] { 633, 712, 772, 777, 797, 902, 910, 941, 977 } });
            //sssss.Add(new RariryPainSeed { Name = "Солнце на прикладе", Seeds = new int[] { 209, 640, 672, 791, 43, 216, 397, 424, 615, 676, 689, 765, 769, 814, 909, 961, 963 } });
            //sssss.Add(new RariryPainSeed { Name = "2 солнца в центре", Seeds = new int[] { 159, 749, 752, 762, 776 } });
            //sssss.Add(new RariryPainSeed { Name = "3 солнца", Seeds = new int[] { 302, 443 } });
            //sssss.Add(new RariryPainSeed { Name = "4 солнца", Seeds = new int[] { 420 } });
            //sssss.Add(new RariryPainSeed { Name = "Без солнца", Seeds = new int[] { 280, 389, 507, 693, 804, 993 } });

            //tmp.Seeds = sssss;
            //Scins.Add(tmp);

            //tmp = new RarityPainSeedScin();
            //tmp.ImageUrl = "http://media.steampowered.com/apps/730/icons/econ/default_generated/weapon_tec9_cu_tec9_sandstorm_light_large.e38b0daacb3aa5d8f692a5ee05ad4bc0885808cd.png";
            //tmp.Name = "Тек-9 | Песчаная Буря";
            //sssss = new List<RariryPainSeed>();
            //sssss.Add(new RariryPainSeed { Name = "Фулл фиолетовый", Seeds = new int[] { 55, 66, 86, 104, 178, 221, 222, 227, 245, 255, 268, 292, 346, 425, 450, 487, 511, 519, 570, 683, 696, 703, 705, 706, 714, 723, 739, 760, 784, 844 } });
            //sssss.Add(new RariryPainSeed { Name = "Капля", Seeds = new int[] { 70, 83, 100, 125, 271, 383, 391, 526, 558, 713, 772, 991 } });
            //sssss.Add(new RariryPainSeed { Name = "Полоска", Seeds = new int[] { 328, 337, 471, 736, 761 } });
            //tmp.Seeds = sssss;
            //Scins.Add(tmp);

            //tmp = new RarityPainSeedScin();
            //tmp.ImageUrl = "http://media.steampowered.com/apps/730/icons/econ/default_generated/weapon_glock_am_nuclear_pattern1_glock_light_large.01e91d2930e04d43215becb90447b2ebec1cb8d9.png";
            //tmp.Name = "Glock | Реактор";
            //sssss = new List<RariryPainSeed>();
            //sssss.Add(new RariryPainSeed { Name = "Желтый реактор", Seeds = new int[] { 345, 274, 11, 87, 213, 274, 278, 287, 396, 454, 461, 471, 541, 577, 589, 601, 636, 657, 690, 872 } });
            //sssss.Add(new RariryPainSeed { Name = "Зубы", Seeds = new int[] { 923, 281, 152, 743 } });
            //sssss.Add(new RariryPainSeed { Name = "Ядерный знак", Seeds = new int[] { 108, 126, 395, 511, 527, 571, 628, 702, 742, 763, 848, 892 } });
            //tmp.Seeds = sssss;
            //Scins.Add(tmp);

            //tmp = new RarityPainSeedScin();
            //tmp.ImageUrl = "http://media.steampowered.com/apps/730/icons/econ/default_generated/weapon_fiveseven_hy_kami_light_large.ce4939fe41b30c6143f487879a57e4f5f227e811.png";
            //tmp.Name = "FiveSeven | Ками";
            //sssss = new List<RariryPainSeed>();
            //sssss.Add(new RariryPainSeed { Name = "Женские", Seeds = new int[] { 486, 582, 590, 607, 660, 662, 909 } });
            //sssss.Add(new RariryPainSeed { Name = "Рожа на торце", Seeds = new int[] { 37, 64, 97, 120, 134, 150, 157, 166, 167, 184, 285, 345, 350, 371, 403, 452, 479, 492, 537, 628, 710, 887 } });
            //sssss.Add(new RariryPainSeed { Name = "Рожа на левой стороне", Seeds = new int[] { 445, 734, 746, 991 } });
            //sssss.Add(new RariryPainSeed { Name = "Белый Ками", Seeds = new int[] { 27, 360, 472, 483, 550, 617, 645, 740, 753, 757, 770, 801, 809, 831, 844, 939 } });
            //sssss.Add(new RariryPainSeed { Name = "Текстово-числовые", Seeds = new int[] { 685, 762, 773, 886, 950, 990 } });
            //sssss.Add(new RariryPainSeed { Name = "Бомбический Ками", Seeds = new int[] { 31, 204, 257, 322, 334, 347, 357, 361, 365, 428, 437, 456, 460, 516, 545, 576, 594, 615, 621, 639, 640, 681, 704, 716, 743, 758, 760, 768, 791, 824, 830, 859, 902 } });
            //sssss.Add(new RariryPainSeed { Name = "Солнечный Ками", Seeds = new int[] { 111, 211, 314, 382, 399, 481, 804, 903, 975 } });
            //sssss.Add(new RariryPainSeed { Name = "Вкусный Ками", Seeds = new int[] { 187, 424, 447, 458, 475, 573, 815, 818, 979 } });
            //sssss.Add(new RariryPainSeed { Name = "Летающая Курица", Seeds = new int[] { 25, 318, 465, 520 } });
            //tmp.Seeds = sssss;
            //Scins.Add(tmp);

            //tmp = new RarityPainSeedScin();
            //tmp.ImageUrl = "http://media.steampowered.com/apps/730/icons/econ/default_generated/weapon_p250_aa_p250_gravediggers_light_large.df680e4648f5e08ec6e92ed36a5b9c05ae8bc5f4.png";
            //tmp.Name = "P250 | Ворон";
            //sssss = new List<RariryPainSeed>();
            //sssss.Add(new RariryPainSeed { Name = "Ворон с расправленными крыльями", Seeds = new int[] { 73, 191, 249, 375, 401, 513, 749, 793, 798, 910 } });
            //sssss.Add(new RariryPainSeed { Name = "Кричащий ворон", Seeds = new int[] { 74, 127, 263, 478, 542775, 861, 905, 970, 978 } });
            //sssss.Add(new RariryPainSeed { Name = "Молчащий ворон ", Seeds = new int[] { 708, 888 } });
            //sssss.Add(new RariryPainSeed { Name = "Два Ворона", Seeds = new int[] { 858, 890, 923 } });
            //tmp.Seeds = sssss;
            //Scins.Add(tmp);

            //tmp = new RarityPainSeedScin();
            //tmp.ImageUrl = "http://media.steampowered.com/apps/730/icons/econ/default_generated/weapon_deagle_aa_vertigo_light_large.85a16e4bfb8b1cc6393ca5d0c6d3a1e6e6023323.png";
            //tmp.Name = "Deagle | Гипноз";
            //sssss = new List<RariryPainSeed>();
            //sssss.Add(new RariryPainSeed { Name = "Full Zebra’s Eye", Seeds = new int[] { 12, 86, 104, 245, 302, 346, 399, 487, 511, 514, 583, 654, 703, 786, 990 } });
            //sssss.Add(new RariryPainSeed { Name = "Full Zebra", Seeds = new int[] { 57, 73, 84, 87, 89, 103, 109, 137, 140, 168, 172, 223, 236, 278, 314, 396, 403, 429, 446, 455, 468, 481, 508, 550, 572, 584, 597, 636, 639, 648, 651, 665, 690, 714, 735, 752, 758, 774, 800, 827, 829, 849, 860, 872, 897, 910, 911, 936, 944, 961 } });
            //sssss.Add(new RariryPainSeed { Name = "Fake Zebra", Seeds = new int[] { 47, 61, 95, 114, 117, 136, 139, 145, 150, 154, 161, 173, 295, 312, 313, 319, 380, 416, 421, 447, 453, 465, 475, 521, 527, 533, 536, 604, 608, 633, 697, 719, 726, 737, 740, 793, 804, 813, 819, 823, 830, 831, 834, 840, 848, 850, 856, 864, 884, 886, 892, 905, 921, 942, 943, 968, 984 } });
            //tmp.Seeds = sssss;
            //Scins.Add(tmp);

            //tmp = new RarityPainSeedScin();
            //tmp.ImageUrl = "http://media.steampowered.com/apps/730/icons/econ/default_generated/weapon_glock_aa_vertigo_blue_light_large.0f4a3ec87faf17bb8557aa3b57a99606ac24c44e.png";
            //tmp.Name = "Glock | Дальний свет";
            //sssss = new List<RariryPainSeed>();
            //sssss.Add(new RariryPainSeed { Name = "Fake Full High Beam", Seeds = new int[] { 481, 500, 519, 521, 536, 558, 563, 575, 599, 604, 615, 665, 726, 735, 760, 771, 783, 801, 821, 823, 827, 830, 831, 837, 849, 910, 960, 961, 984, 991 } });
            //sssss.Add(new RariryPainSeed { Name = "Full High Beam", Seeds = new int[] { 245, 255, 298, 314, 346, 361, 379, 391, 396, 399, 455, 460, 514, 572, 583, 584, 636, 648, 651, 654, 690, 703, 714, 752, 758, 774, 786, 829, 835, 860, 872, 911, 944, 990 } });
            //sssss.Add(new RariryPainSeed { Name = "Max High Beam", Seeds = new int[] { 302, 487, 508, 597, 639, 800, 936 } });
            //sssss.Add(new RariryPainSeed { Name = "Extreme High Beam", Seeds = new int[] { 511, 550, 897 } });
            //tmp.Seeds = sssss;
            //Scins.Add(tmp);

            //tmp = new RarityPainSeedScin();
            //tmp.ImageUrl = "http://media.steampowered.com/apps/730/icons/econ/default_generated/weapon_ssg08_aq_leviathan_light_large.0d0ce425b5374642d0d1fbfd0c0ec634eb8570fb.png";
            //tmp.Name = "SSG 08 | Пучина";
            //sssss = new List<RariryPainSeed>();
            //sssss.Add(new RariryPainSeed { Name = "qwe", Seeds = new int[] { 1, 2, 3 } });
            //sssss.Add(new RariryPainSeed { Name = "qwe", Seeds = new int[] { 1, 2, 3 } });
            //tmp.Seeds = sssss;
            //Scins.Add(tmp);



            //File.WriteAllText("sss.txt", JsonSerializer.Serialize<List<RarityPainSeedScin>>(Scins));

            Updater.CheckUpdateSilence();
            ((MainWindowVM)DataContext).LoadInventory();
            if (SettingController.IsFirstStart)
            {
                new ChangeLogWindow().Show();
                SettingController.IsFirstStart = false;
            }
            //TODO : Добавить проверку на наличие инета при запуске проги

            PriceHandler.Load();
        }



        private void TopBar_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (this.WindowState == WindowState.Maximized) this.WindowState = WindowState.Normal;
                else this.WindowState = WindowState.Maximized;
            }
        }
    }
}
