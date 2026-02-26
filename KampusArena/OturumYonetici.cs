using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{

    public static class OturumYonetici
    {
        private static DateTime _sonEtkinlikZamani = DateTime.Now;
        private static System.Windows.Forms.Timer _timer;

        public static void Baslat(Form aktifForm)
        {
            _sonEtkinlikZamani = DateTime.Now;

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000*60 ; 
            _timer.Tick += (s, e) =>
            {
                TimeSpan gecenSure = DateTime.Now - _sonEtkinlikZamani;

                if (gecenSure.TotalMinutes >= 30)
                {
                    _timer.Stop();

                    MessageBox.Show("30 dakikadır işlem yapılmadı. Oturum sonlandırılıyor.", "Oturum Süresi Doldu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    aktifForm.Invoke((MethodInvoker)(() =>
                    {
                        
                        Thread thread = new Thread(() =>
                        {
                            Application.Run(new Formkullanicigiris());
                        });
                        thread.SetApartmentState(ApartmentState.STA); 
                        thread.Start();


                        foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                        {
                            if (form != null && !form.IsDisposed && form != aktifForm)
                            {
                                form.Close();
                            }
                        }

                        aktifForm.Close();

                    }));
                }
            };
            _timer.Start();

            Application.AddMessageFilter(new KullaniciEtkinlikFiltresi(() =>
            {
                _sonEtkinlikZamani = DateTime.Now;
            }));
        }

        public static void Durdur()
        {
            _timer?.Stop();
        }

        private class KullaniciEtkinlikFiltresi : IMessageFilter
        {
            private readonly Action _etkinlikHandler;

            public KullaniciEtkinlikFiltresi(Action handler)
            {
                _etkinlikHandler = handler;
            }

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == 0x200 || m.Msg == 0x201 || m.Msg == 0x100 || m.Msg == 0x101)
                {
                    // 0x200: Mouse hareketi
                    //0x201: Mouse click(basmak)
                    //0x100: Klavyeye tuş basmak
                    //0x101: Klavyeden tuş bırakmak
                    _etkinlikHandler.Invoke();
                }
                return false;
            }
        }
    }

    }
