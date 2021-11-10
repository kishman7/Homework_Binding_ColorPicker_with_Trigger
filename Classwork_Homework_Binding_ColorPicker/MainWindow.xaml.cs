using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;

namespace Classwork_Homework_Binding_ColorPicker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged  // INotifyPropertyChanged - інтерфейс для повноцінної реалізації механізму прив’язки
    {
        public SolidColorBrush Brush { get; set; } //властивість для закрашування фону лейби
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private int red;
        public int Red //реалізація властивості по зміні кольору
        {
            get { return red; }
            set
            {
                red = value;
                Brush = new SolidColorBrush(Color.FromRgb(Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue)));
                OnNotify("Brush");
            }
        }

        private int green;
        public int Green
        {
            get { return green; }
            set
            {
                green = value;
                Brush = new SolidColorBrush(Color.FromRgb(Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue)));
                OnNotify("Brush");
            }
        }

        private int blue;

        public event PropertyChangedEventHandler PropertyChanged; //як тільки буде мінятись якась властивість, то ми будемо негайно сповіщати про це інтерфейс,
                                                                  // і якщо в нас є Binding, то ця властивість буде оновлюватись
        public int Blue
        {
            get { return blue; }
            set
            {
                blue = value;
                Brush = new SolidColorBrush(Color.FromRgb(Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue)));
                OnNotify("Brush");
            }
        }

        //обробка події PropertyChanged
        public void OnNotify([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //реалізація checkBox
        private void checkBox1_Click(object sender, RoutedEventArgs e)
        {
            //if (checkBox1.IsChecked == true)
            //{
            //    slider1.Value = 100;
            //    slider1.IsEnabled = false;
            //}
            //else
            //{
            //    slider1.IsEnabled = true;
            //}
        }

        private void checkBox2_Click(object sender, RoutedEventArgs e)
        {
            //if (checkBox2.IsChecked == true)
            //{
            //    slider2.Value = 100;
            //    slider2.IsEnabled = false;
            //}
            //else
            //{
            //    slider2.IsEnabled = true;
            //}
        }

        private void checkBox3_Click(object sender, RoutedEventArgs e)
        {
            //if (checkBox3.IsChecked == true)
            //{
            //    slider3.Value = 100;
            //    slider3.IsEnabled = false;
            //}
            //else
            //{
            //    slider3.IsEnabled = true;
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e) //обробка кнопки додавання кольору у ListView
        {
            Bind bind = new Bind() { Color = lblColor.Background.ToString(), Brush = (SolidColorBrush)lblColor.Background };
            listView.Items.Add(bind);
        }
               
        class Bind //клас, який створює назву кольору та заливку рамки
        {
            public string Color { set; get; } = "";
            public SolidColorBrush Brush { set; get; } = new SolidColorBrush(Colors.Black);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //реалізація кнопки delete
        {
            listView.Items.Remove(listView.SelectedItem);
        }
        
    }
}
