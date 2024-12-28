using System;
using System.Threading;
using System.Windows.Forms;

namespace Synchronization_mechanisms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
              ������� - �������� �������������, ������� ����� ����� �������������� � ��������������� �������������. 
             public Mutex(
             bool initiallyOwned, - �������� true ��� �������������� ����������� ������ ���������� �������� ���������; � ��������� ������ � false.
             string name - ��� ������� Mutex. ���� �������� ����� null, �� � ������� Mutex ��� �����.
             out bool createdNew - ��� �������� �� ������� ������ �������� ���������� ��������, ������ true, 
                      ���� ��� ������ ����� �������; false, ���� ���� �������� ������ �� ������������ ������. 
                      ���� �������� ���������� ��������������������. 
               )
                
              public virtual bool WaitOne(); - ������� ������� �������� � ���������� ���������. 
              public void ReleaseMutex(); - ��������� ������� �� ������������� � ���������� ���������.
              public static Mutex OpenExisting(string name); - ���������� ������ �� ������������ �������. 
              ���� ��� ���, �� ���������� WaitHandleCannotBeOpenedException
             * public virtual void Close(); - ��������� ���������� �������� ���������.
            */
            //������ ������ ����� ����� ����������
            string GUID = "{6F9619FF-8B86-D011-B42D-00CF4FC964FF}";
            bool CreatedNew;
            Mutex mutex = new Mutex(false, GUID, out CreatedNew);
            if (!CreatedNew)//������� ��� ��� ������
            {
                MessageBox.Show("Must be only one copy");
            }
            else //������� �������� ������ ����������� ����������
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            mutex.Dispose();
        }
    }
}
