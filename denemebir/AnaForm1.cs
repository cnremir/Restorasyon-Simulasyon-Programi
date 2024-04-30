using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static denemebir.main1;



namespace denemebir
{
    public partial class AnaForm1 : Form
    {
        static Random random = new Random();
        static Button baslaButton = new Button();
        public static List<Masa> masalar = new List<Masa>();
        public static List<Button> masalarButton = new List<Button>();
        public static List<Button> siraButton = new List<Button>();

        Random rand = new Random();
        public static List<Label> butonLabelleri = new List<Label>();
        public static List<Button> chefButton = new List<Button>();
        public static List<Button> garsonButton = new List<Button>();
        public static List<Label> asciButonLabel = new List<Label>();
        public static List<Label> garsonButonLabel = new List<Label>();
        static TabControl tab;
        static Panel asciPanel;
        static Panel garsonPanel;
        static Panel masalarPanel;
        static Panel siraPanel;
        static Panel mainPanel;
        static Panel kasaPanel;
        static int yukseklik = 140;
        public static List<Button> siraButon = new List<Button>();
        public static string logFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        public static string logFileName = $"log_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";
        public static string logFilePath = Path.Combine(logFolderPath, logFileName);
        public static int customerEarned = 0;
        public static int totalIncome = 0;
        public static int customerLeftQueue = 0;
        private static readonly object fileLock = new object();
        public AnaForm1()
        {
            InitializeComponent();
            this.Load += AnaForm_Load;
            //  garsonOlustur();
        }
        public static void MasaAnimasyonPaneliEkle()
        {

            masalarPanel.AutoScroll = true; // Otomatik kaydırma etkinleştir

            int totalHeight = 0; // Toplam yükseklik
            int buttonHeight = 100; // Buton yüksekliği (ayarlayabilirsiniz)
            for (int i = 0; i < main1.tableCount; i++)
            {
                Masa masa = new Masa();
                masalar.Add(masa);
            }



            for (int i = 0; i < masalar.Count; i++)
            {
                

                Button masaButton = new Button();
                masaButton.Text = "Masa " + masalar[i].id;
                masaButton.Width = 4 * masalarPanel.Width / 5;
                masaButton.Height = buttonHeight;
                masaButton.Location = new Point(masalarPanel.Size.Width / 8, totalHeight);
                totalHeight += buttonHeight;

                Label butonEtiketi = new Label();
                butonEtiketi.BackColor = Color.White;
                butonEtiketi.Size = new System.Drawing.Size(4 * masaButton.Width / 5, 20);
                butonEtiketi.Location = new System.Drawing.Point(masaButton.Location.X + 25, masaButton.Location.Y + 70);
                butonLabelleri.Add(butonEtiketi);

                masalarPanel.Controls.Add(butonEtiketi);
                masalarPanel.Controls.Add(masaButton);
                masalarButton.Add(masaButton);
            }
            if (totalHeight > masalarPanel.Height)
            {
                masalarPanel.AutoScrollMinSize = new Size(0, totalHeight);
            }
            masalariBoya();




            }

        public static void AsciAnimasyonPaneliEkle()
        {
           





            for (int i = 0; i < chefs.Count; i++)
            {

                Button chefButon = new Button();
                chefButon.Name = chefs[i].Name;
                chefButon.BackColor = Color.Wheat;
                chefButon.Text = chefs[i].Name;
                chefButon.Width = 4 * asciPanel.Width / 5;
                chefButon.Height = 100;
                chefButon.Location = new Point(asciPanel.Size.Width / 8, i * (asciPanel.Size.Height / (chefs.Count + 1)));

                Label butonEtiketi = new Label();
                butonEtiketi.Name = chefs[i].Name;
                butonEtiketi.BackColor = Color.White;
                butonEtiketi.Size = new System.Drawing.Size(4 * chefButon.Width / 5, 20);
                butonEtiketi.Location = new System.Drawing.Point(chefButon.Location.X + 25, chefButon.Location.Y + 70);
                asciButonLabel.Add(butonEtiketi);
                asciPanel.Controls.Add(butonEtiketi); 
                asciPanel.Controls.Add(chefButon); 
                chefButton.Add(chefButon);
            }






        }
        public static void GarsonAnimasyonPaneliEkle()
        {
            




            for (int i = 0; i < waiters.Count; i++)
            {

                Button waiterButon = new Button();
                waiterButon.Name = waiters[i].Name;
                waiterButon.BackColor = Color.Wheat;
                waiterButon.Text = waiters[i].Name;
                waiterButon.Width = 4 * garsonPanel.Width / 5;
                waiterButon.Height = 100;
                waiterButon.Location = new Point(garsonPanel.Size.Width / 8, i * (garsonPanel.Size.Height / (waiters.Count + 1)));

                Label butonEtiketi = new Label();
                butonEtiketi.Name = waiters[i].Name;
                butonEtiketi.BackColor = Color.White;
                butonEtiketi.Size = new System.Drawing.Size(4 * waiterButon.Width / 5, 20);
                butonEtiketi.Location = new System.Drawing.Point(waiterButon.Location.X + 25, waiterButon.Location.Y + 70);
                garsonButonLabel.Add(butonEtiketi);
                garsonPanel.Controls.Add(butonEtiketi);
                garsonPanel.Controls.Add(waiterButon); 
                garsonButton.Add(waiterButon);



            }


           




        }
        private void AnaForm_Load(object sender, EventArgs e)
        {
           
            mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            this.Controls.Add(mainPanel);
            asciPanel = new Panel();
            asciPanel.Location = new Point(0, 0);
            asciPanel.Size = new Size(320, 800);
            asciPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(asciPanel);
            garsonPanel = new Panel();
            garsonPanel.Location = new Point(320, 0);
            garsonPanel.Size = new Size(320, 800);
            garsonPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(garsonPanel);
            masalarPanel = new Panel();
            masalarPanel.Location = new Point(960, 0);
            masalarPanel.Size = new Size(320, 800);
            masalarPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(masalarPanel);
            kasaPanel = new Panel();
            kasaPanel.Location = new Point(640, 0);
            kasaPanel.Size = new Size(320, 800);

            kasaPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(kasaPanel);

            Button kasa = new Button();
            kasa.Size = new Size(300, 100);
            kasa.Location = new Point(10, 20);
            kasa.Text = "KASA";
            kasa.BackColor = Color.Brown;
            kasaPanel.Controls.Add(kasa);
            baslaButton.Text = "BAŞLA";

            baslaButton.Location = new Point(1720, 220);
            baslaButton.Click += BaslaButton_Click;
            mainPanel.Controls.Add(baslaButton);
            siraPanel = new Panel();
            siraPanel.Location = new Point(1280, 0);
            siraPanel.Size = new Size(320, 800);
            siraPanel.BorderStyle = BorderStyle.FixedSingle;
            
            if (!Directory.Exists(logFolderPath))
            {
                Directory.CreateDirectory(logFolderPath);
            }
            mainPanel.Controls.Add(siraPanel);







        }

        private static void BaslaButton_Click(object sender, EventArgs e)
        {
            baslaButton.Enabled = false;
            fieldChefCount.Enabled = false;
            fieldCustomerCount.Enabled = false;
            fieldTableCount.Enabled = false;
            fieldWaiterCount.Enabled = false;
            asciZamanNum.Enabled = false;
            garsonZamanNum.Enabled = false;
            masaZamanNum.Enabled = false;
            kasaZamanNum.Enabled = false;
            siraZamanNum.Enabled = false;
            donguZamanNum.Enabled = false;
            simulasyonZamanNum.Enabled = false;
            musteriUretmeNum.Enabled = false;
            asciZamanKatsayisi = (int)(asciZamanNum.Value * 1000);
            garsonZamanKatsayisi = (int)(garsonZamanNum.Value * 1000);
            musteriYemekZamanKatsayisi = (int)(masaZamanNum.Value * 1000);
            kasaZamanKatsayisi = (int)(kasaZamanNum.Value * 1000);
            siraBeklemeZamanKatsayisi = (int)(siraZamanNum.Value);
            donguZamanKatsayisi = (int)(donguZamanNum.Value * 1000);
            simulasyonHiziZamanKatsayisi = (float)simulasyonZamanNum.Value;
            musteriUretmeZamanKatsayisi = (int)(musteriUretmeNum.Value * 1000);
            main1 main = new main1();
            main1.Main();


        }

        

        

        public static void masalariBoya()
        {
            for (int i = 0; i < masalar.Count; i++)
            {
                if (masalar[i].BosMu)
                {
                    masalarButton.ElementAt(i).BackColor = Color.Wheat;
                }

            }

        }
        public static void logPayment(string message)
        {
            if (kasaKonsol.InvokeRequired)
            {
                kasaKonsol.Invoke(new Action<string>(logPayment), message);
            }
            else
            {
                kasaKonsol.AppendText(message + Environment.NewLine);
            }


        }
        public static void Log(string message)
        {
            if (konsol.InvokeRequired)
            {
                konsol.Invoke(new Action<string>(Log), message);
            }
            else
            {
                konsol.AppendText(message + Environment.NewLine);
                updateTxtFile(message);
            }
        }
        public static void LogCustomer(string message)
        {
            if (masalarKonsol.InvokeRequired)
            {
                masalarKonsol.Invoke(new Action<string>(LogCustomer), message);
            }
            else
            {
                masalarKonsol.AppendText(message + Environment.NewLine);
            }
        }
        public static void LogChef(string message)
        {
            if (asciKonsol.InvokeRequired)
            {
                asciKonsol.Invoke(new Action<string>(LogChef), message);
            }
            else
            {
                asciKonsol.AppendText(message + Environment.NewLine);
            }
        }
        public static void LogWaiter(string message)
        {
            if (garsonKonsol.InvokeRequired)
            {
                garsonKonsol.Invoke(new Action<string>(LogWaiter), message);
            }
            else
            {
                garsonKonsol.AppendText(message + Environment.NewLine);
            }
        }
        public static void LogQueue(string message)
        {
            if (siraKonsol.InvokeRequired)
            {
                siraKonsol.Invoke(new Action<string>(LogQueue), message);
            }
            else
            {
                siraKonsol.AppendText(message + Environment.NewLine);
            }
        }
        public static void updateQueue()
        {
            if (siraPanel.InvokeRequired)
            {
                siraPanel.Invoke(new MethodInvoker(updateQueue));
                return;
            }

            siraPanel.Controls.Clear();
            siraButton.Clear();
            int i = 0;

            foreach (var element in customerQueue.ToList())
            {
                LogQueue("customerqueuecount:" + customerQueue.Count);
                Button queueButton = new Button();
                queueButton.Name = element.Name; 
                 
                queueButton.BackColor = Color.FromArgb(255 - (int)((double)element.beklemeSuresi / siraBeklemeZamanKatsayisi * 250), 111, 0, 255);
                queueButton.Text = element.Name + " Öncelik:" + element.Priority;
                

                queueButton.Width = 4 * siraPanel.Width / 5;
                queueButton.Height = 100;
                queueButton.Location = new Point(siraPanel.Size.Width / 8, i * (siraPanel.Size.Height / (customerQueue.Count + 1)));
                siraPanel.Controls.Add(queueButton);
                siraButton.Add(queueButton);

                i++;
            }
        }
        public static void updateCashierQueue()
        {
            if (kasaPanel.InvokeRequired)
            {
                kasaPanel.Invoke(new MethodInvoker(updateCashierQueue));
                return;
            }

            kasaPanel.Controls.Clear();
            siraButon.Clear();
            Button kasa = new Button();
            kasa.Size = new Size(300, 100);
            kasa.Location = new Point(10, 20);
            kasa.Text = "KASA";
            kasa.BackColor = Color.Brown;
            kasaPanel.Controls.Add(kasa);
            int i = 0;

            foreach (var element in kasaList.ToList())
            {
                
                Button queueButton = new Button();
                queueButton.Name = element.Name;

                queueButton.BackColor = Color.Aqua;
                queueButton.Text = element.Name;


                queueButton.Width = 4 * kasaPanel.Width / 5;
                queueButton.Height = 100;
                queueButton.Location = new Point(kasaPanel.Size.Width / 8, 140+ (i * ((kasaPanel.Size.Height-140) / (customerQueue.Count + 1))));
                kasaPanel.Controls.Add(queueButton);
                siraButon.Add(queueButton);

                i++;
            }
        }


        public static void updateLabels()
        {
            if (lblCustomerEarn.InvokeRequired)
            {
                lblCustomerEarn.Invoke(new MethodInvoker(() => updateLabels()));
            }
            else
            {
                lblCustomerEarn.Text = "Kazanılan Müşteri: " + customerEarned;
            }

            if (lblCustomerLeftQueue.InvokeRequired)
            {
                lblCustomerLeftQueue.Invoke(new MethodInvoker(() => updateLabels()));
            }
            else
            {
                lblCustomerLeftQueue.Text = "Kaybedilen Müşteri: " + customerLeftQueue;
            }

            if (lblTotalIncome.InvokeRequired)
            {
                lblTotalIncome.Invoke(new MethodInvoker(() => updateLabels()));
            }
            else
            {
                lblTotalIncome.Text = "Toplam Kazanç: " + totalIncome;
            }

            if (lblTotalCustomer.InvokeRequired)
            {
                lblTotalCustomer.Invoke(new MethodInvoker(() => updateLabels()));
            }
            else
            {
                lblTotalCustomer.Text = "Gelen Müşteri: " + main1.currentCustomerCount;
            }
        }
        public static void updateTxtFile(string s)
        {
            lock (fileLock)
            {
                

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.Write($"Tarih: {DateTime.Now} : ");
                    writer.WriteLine(s);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }



}


