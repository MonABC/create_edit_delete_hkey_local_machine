using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRegedit02090822
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // đoạn code này chỉ tạo được trên HKEY_CURRENT_USER
            //Microsoft.Win32.RegistryKey key;
            //key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Names");
            //key.SetValue("Name", "Isabella");
            //key.Close();

            // da tao duoc trong LocalMachine -> Software -> Wow6432doe -> tao ra duoc file co ten la Names
            //Microsoft.Win32.RegistryKey key;
            //key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software\\Wow6432Node\\Names");
            //key.SetValue("Name", "Isabella");
            //key.Close();

            //them doan code nay vao doan code duoi va sua theo no 
            //var baseReg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            //var reg = baseReg.CreateSubKey("Software\\Test");

            //Microsoft.Win32.RegistryKey key;
            //key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software\\Wow6432Node\\Names");
            //key.SetValue("Name", "Isabella");
            //key.Close();

            //sau khi them song no da tao duoc file theo duong dan LocalMachine -> Software - -> tao ra duoc file co ten la Test123 nho import DONE
            //var baseReg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            //var reg = baseReg.CreateSubKey("Software\\Test123");
            //reg.SetValue("Name", "Isabella");
            //reg.Close();

            //====================BAI TAP DA HOAN THANH=======================

            //tao moi regetdit
            Console.WriteLine("===tao regedit moi===");
            Console.WriteLine("nhap ten key");
            string keyName = Console.ReadLine();
            Console.WriteLine("nhap ten gia tri");
            string nameValue = Console.ReadLine();
            Console.WriteLine("nhap gia tri cho no");
            string value = Console.ReadLine();

            createRegistryKey($"{keyName}", $"{nameValue}", $"{value}");
            Console.WriteLine("check lai regedit xem nao ban oi!");

            //sua value cua key
            //editRegistryKey("Test123", "Name", "12345456456");

            //xoa key thu muc
            //deleteRegistryKey("viet");

            
         

        }
        public static void createRegistryKey(string keyName, string nameValue, string value)
        {
            var baseReg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            var reg = baseReg.CreateSubKey("Software\\" + keyName);
            reg.SetValue(nameValue, value);
            reg.Close();
        }

        public static void editRegistryKey(string pathName, string nameValue, string value)
        {
            var baseReg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            var reg = baseReg.OpenSubKey("Software\\"+pathName, true);
            reg.SetValue(nameValue, value);
            reg.Close();
        }

        public static void deleteRegistryKey(string keyName)
        {
            var baseReg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            var reg = baseReg.OpenSubKey("Software", true);
            reg.DeleteSubKey(keyName);
            reg.Close();
        }


    }
}
