﻿using Nhom9_QuanLyTour.Views;
using System;
using System.Windows.Forms;

namespace Nhom9_QuanLyTour
{
    internal static class Program
    { 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangNhap()
            {

            });
        }
    }
}
