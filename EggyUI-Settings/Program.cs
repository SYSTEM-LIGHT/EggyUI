/*
 * ============================================================================
 * EggyUI - Windows �������������
 * �������ס������ɶԡ�UI���ķ�˿���δ������ǹٷ�������ҵ��Ŀ
 * ============================================================================
 *  
 * ����: �����С���� (SYSTEM-LIGHT)
 * ������: EggyUI �����Ŷ� (https://github.com/SYSTEM-LIGHT/EggyUI)
 * 
 * ��Ȩ���� (c) 2024-2025 EggyUI �����Ŷ�
 * 
 * ���Э��:
 * ����ĿΪ��˿�������Ͻ������κ���ҵ��;��
 * �����زľ�Ϊ�Ϸ���ȡ�������ػ棬δʹ���κ���Ϸ������ݡ�
 * 
 * ��������:
 * 1. �������΢�������޹أ�Windows �͡������ɶԡ��ֱ�Ϊ��������˾��ע���̱ꡣ
 * 2. ʹ���������ге���ʹ�ñ�������ܴ����ķ��ա�
 * 3. ��ֹ�Ա����������ҵ��ʹ�á��ַ��򼯳�����ҵ��Ʒ�С�
 * 
 * ============================================================================
 */

namespace EggyUI_Settings
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new Settings_Window());
            }
            catch (Exception ex)
            {
                // ����Ӧ�ó�������ʱ���쳣
                MessageBox.Show($"Ӧ�ó�������ʱ��������{ex.Message}", "����",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}