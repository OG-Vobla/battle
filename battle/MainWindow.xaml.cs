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

namespace battle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Character FirstPalyer;
        Character SecondPalyer;
        bool isFight;
        bool MPressed;
        bool LPressed;
        bool PPressed;
        bool ZPressed;
        bool APressed;
        bool QPressed;
        public MainWindow()
        {
            InitializeComponent();
             MPressed = false;
             LPressed = false;
            PPressed = false;
            ZPressed = false;
            APressed = false;
            QPressed = false;
        }

        private void BeginFight_Click(object sender, RoutedEventArgs e)
        {
            isFight = true;
            FirstPalyer = new Character();
            SecondPalyer = new Character();
            FightInfo.Text += "Бой начался" + '\n';
            /*            while ((FirstPalyer.Hp > 0 || SecondPalyer.Hp > 0) && isFight)
                        {
                            if(FightInfo.Text.Split('\n').Length > 10)
                            {
                                FightInfo.Text = "";
                            }
                        }*/
        }

        async private void EndFight_Click(object sender, RoutedEventArgs e)
        {
            isFight = false;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(isFight)
            {
                if (FightInfo.Text.Split('\n').Length > 10)
                {
                    FightInfo.Text = "";
                }
                if (e.Key == Key.M)//Маг урон 2 игрока
                {
                    MPressed = true;
                }
                else if (e.Key == Key.P)//Физ урон 2 игрока
                {
                    PPressed = true;
                }
                else if (e.Key == Key.L)//Блок 2 игрока
                {
                    LPressed = true;
                }
                if (MPressed)
                {
                    if (e.Key == Key.N) //Ноги
                    {
                        SecondPalyer.AttPart = "Ноги";
                        FightInfo.Text += "Второй игрок атакует" + '\n' + SecondPalyer.MHit(FirstPalyer);
                    }
                    else if (e.Key == Key.J) //Тело
                    {
                        SecondPalyer.AttPart = "Тело";
                        FightInfo.Text += "Второй игрок атакует" + '\n' + SecondPalyer.MHit(FirstPalyer);
                    }
                    else if (e.Key == Key.K) //Руки
                    {
                        SecondPalyer.AttPart = "Руки";
                        FightInfo.Text += "Второй игрок атакует" + '\n' + SecondPalyer.MHit(FirstPalyer);
                    }
                    else if (e.Key == Key.U) //Голова
                    {
                        SecondPalyer.AttPart = "Голова";
                        FightInfo.Text += "Второй игрок атакует" + '\n' + SecondPalyer.MHit(FirstPalyer);
                    }
                }
                else if (PPressed)//Физ урон 2 игрока
                {
                    if (e.Key == Key.N) //Ноги
                    {
                        SecondPalyer.AttPart = "Ноги";
                        FightInfo.Text += "Второй игрок атакует" + '\n' + SecondPalyer.PHit(FirstPalyer);
                    }
                    else if (e.Key == Key.J) //Тело
                    {
                        SecondPalyer.AttPart = "Тело";
                        FightInfo.Text += "Второй игрок атакует" + '\n' + SecondPalyer.PHit(FirstPalyer);
                    }
                    else if (e.Key == Key.K) //Руки
                    {
                        SecondPalyer.AttPart = "Руки";
                        FightInfo.Text += "Второй игрок атакует" + '\n' + SecondPalyer.PHit(FirstPalyer);

                    }
                    else if (e.Key == Key.U) //Голова
                    {
                        SecondPalyer.AttPart = "Голова";
                        FightInfo.Text += "Второй игрок атакует" + '\n' + SecondPalyer.PHit(FirstPalyer);

                    }

                }
                else if (LPressed)//Блок 2 игрока
                {
                    if (e.Key == Key.N) //Ноги
                    {
                        SecondPalyer.BlockPart = "Ноги";
                    }
                    else if (e.Key == Key.J) //Тело
                    {
                        SecondPalyer.BlockPart = "Тело";
                    }
                    else if (e.Key == Key.K) //Руки
                    {
                        SecondPalyer.BlockPart = "Руки";
                    }
                    else if (e.Key == Key.U) //Голова
                    {
                        SecondPalyer.BlockPart = "Голова";
                    }
                }
                /////////
                if (e.Key == Key.Z)//Маг урон 1 игрока
                {
                    ZPressed = true;
                }
                else if (e.Key == Key.A)//Физ урон 1 игрока
                {
                    APressed = true;
                }
                else if (e.Key == Key.Q)//Блок 1 игрока
                {
                    QPressed = true;

                }
                if (ZPressed)//Маг урон 1 игрока
                {
                    if (e.Key == Key.D) //Ноги
                    {
                        FirstPalyer.AttPart = "Ноги";
                        FightInfo.Text += "Первый игрок атакует" + '\n' + FirstPalyer.MHit(SecondPalyer);
                    }
                    else if (e.Key == Key.X) //Тело
                    {
                        FirstPalyer.AttPart = "Ноги";
                        FightInfo.Text += "Первый игрок атакует" + '\n' + FirstPalyer.MHit(SecondPalyer);
                    }
                    else if (e.Key == Key.F) //Руки
                    {
                        FirstPalyer.AttPart = "Ноги";
                        FightInfo.Text += "Первый игрок атакует" + '\n' + FirstPalyer.MHit(SecondPalyer);
                    }
                    else if (e.Key == Key.V) //Голова
                    {
                        FirstPalyer.AttPart = "Ноги";
                        FightInfo.Text += "Первый игрок атакует" + '\n' + FirstPalyer.MHit(SecondPalyer);
                    }

                }
                else if (APressed)//Физ урон 1 игрока
                {
                    if (e.Key == Key.D) //Ноги
                    {
                        FirstPalyer.AttPart = "Ноги";
                        FightInfo.Text += "Первый игрок атакует" + '\n' + FirstPalyer.PHit(SecondPalyer);
                    }
                    else if (e.Key == Key.X) //Тело
                    {
                        FirstPalyer.AttPart = "Ноги";
                        FightInfo.Text += "Первый игрок атакует" + '\n' + FirstPalyer.PHit(SecondPalyer);
                    }
                    else if (e.Key == Key.F) //Руки
                    {
                        FirstPalyer.AttPart = "Ноги";
                        FightInfo.Text += "Первый игрок атакует" + '\n' + FirstPalyer.PHit(SecondPalyer);
                    }
                    else if (e.Key == Key.V) //Голова
                    {
                        FirstPalyer.AttPart = "Ноги";
                        FightInfo.Text += "Первый игрок атакует" + '\n' + FirstPalyer.PHit(SecondPalyer);
                    }

                }
                else if (QPressed)//Блок 1 игрока
                {
                    if (e.Key == Key.D) //Ноги
                    {
                        FirstPalyer.AttPart = "Ноги";
                    }
                    else if (e.Key == Key.X) //Тело
                    {
                        FirstPalyer.AttPart = "Ноги";
                    }
                    else if (e.Key == Key.F) //Руки
                    {
                        FirstPalyer.AttPart = "Ноги";
                    }
                    else if (e.Key == Key.V) //Голова
                    {
                        FirstPalyer.AttPart = "Ноги";
                    }

                }
                if (FirstPalyer.Hp <= 0)
                {
                    FightInfo.Text += "Выйграл Первый игрок";

                }
                else if (SecondPalyer.Hp <= 0)
                {
                    FightInfo.Text += "Выйграл Второй игрок";
                }
            }
            else
            {
                if(FirstPalyer.Hp < SecondPalyer.Hp)
                {
                    FirstPalyer.ExpUp(SecondPalyer.Hp);
                }
                FightInfo.Text = "Бой не идёт";
            }
            
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.M)//Маг урон 2 игрока
            {
                MPressed = false;
            }
            else if (e.Key == Key.P)//Физ урон 2 игрока
            {
                PPressed = false;
            }
            else if (e.Key == Key.L)//Блок 2 игрока
            {
                LPressed = false;
            }
            if (e.Key == Key.Z)//Маг урон 1 игрока
            {
                ZPressed = false;
            }
            else if (e.Key == Key.A)//Физ урон 1 игрока
            {
                APressed = false;
            }
            else if (e.Key == Key.Q)//Блок 1 игрока
            {
                QPressed = false;

            }
        }
    }
}
