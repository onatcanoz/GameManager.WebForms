using Backend;
using Backend.Entities;
using Backend.Models;
using Backend.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterface1
{
    public partial class Oyunlar : System.Web.UI.Page
    {
        private readonly OyunService _oyunService = new OyunService();
        private readonly YapimciService _yapimciService = new YapimciService();
        private readonly TurService _turService = new TurService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // sayfa ilk yüklenirken bunlar çalışıyor. Tekrar tekrar çalışmıyor.
            {
                FillGrid();
                FillYapimcilar(ddlYapimci);
                FillTurler(lbTurler);
                FillGridYapimci();
            }
        }

        private void FillTurler(ListBox listBox)
        {
            List<TurModel> turler = _turService.GetQuery().ToList();
            listBox.DataValueField = "Id";
            listBox.DataTextField = "Adi";
            listBox.DataSource = turler;
            listBox.DataBind();
        }

        private void FillYapimcilar(DropDownList dropDownList)
        {
            //var yapimcilar = _yapimciService.GetQuery().ToList();
            List<YapimciModel> model = _yapimciService.GetQuery().ToList();
            dropDownList.DataValueField = "Id"; //ddlyapimci. ydı dropdownlist'le değiştirdik.
            dropDownList.DataTextField = "Adi";
            dropDownList.DataSource = model;
            dropDownList.DataBind();
            dropDownList.Items.Insert(0, new ListItem()
            {
                Value = "",
                Text = "--Seçiniz--"
            });
        }

        private void SetColumnVisibilities()
        {
            if (gvOyunlar.Rows != null && gvOyunlar.Rows.Count > 0)
            {
                gvOyunlar.HeaderRow.Cells[1].Visible = false;// id'yi başlıktan gizledik. Veriler için loop dönmek lazım.
                foreach (GridViewRow row in gvOyunlar.Rows)
                {
                    row.Cells[1].Visible = false;     //id'nin verilerini gizledik.
                }
            }

        }

        private void FillGrid()
        {
            try
            {
                var oyunlar = _oyunService.GetQuery().ToList();

                //1. yöntem- artık sorgu sonucunu c# dünyasına taşıdığımız için c# üzerinde istediğimiz dönüşüm işlemini yapabılırız.
                //foreach (var oyun in oyunlar) //listeyi aldıktan sonra isteğimiz gibi değişebiliriz. Önce veriyi al sonra modele set et.
                //{
                //    oyun.YapimTarihiFormat = oyun.YapimTarihi.HasValue ? oyun.YapimTarihi.Value.ToShortDateString() : "";
                //} Bu işlemi modelde get ettik.

                gvOyunlar.DataSource = oyunlar;
                gvOyunlar.DataBind();
                SetColumnVisibilities();
                gvOyunlar.SelectedIndex = -1;
            }
            catch (Exception exc)
            {

                string message = exc.Message;
            }

        }

        protected void lbYeni_Click(object sender, EventArgs e)
        {
            pDuzenle.Visible = false;
            pEkle.Visible = true;
            pDetay.Visible = false;
            gvYapimcilar.Visible = false;
            panelYapimci.Visible = false;
            pYapimciDetay.Visible = false;
            pYapimciGuncelle.Visible = false;
            pYeniYapimciEkleme.Visible = false;
        }

        protected void bTemizle_Click(object sender, EventArgs e)
        {
            tbAdi.Text = "";
            tbKazanci.Text = "";
            tbMaliyeti.Text = "";
            cYapimTarihi.SelectedDate = DateTime.Now;

            //dropDownList.SelectedIndex = 0;
            ddlYapimci.SelectedValue = "";
        }

        protected void bKaydet_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(tbAdi.Text))
                {
                    lMesaj.Text = "Adı girilmelidir.";
                    return;
                }
                double? maliyeti = null, kazanci = null;                      //aynı tipteyken yanyana kullanabılırız.
                if (!string.IsNullOrWhiteSpace(tbMaliyeti.Text))
                {
                    //maliyeti = Convert.ToDouble(tbMaliyeti.Text.Replace(",", "."), new CultureInfo("en")); //alttakının aynısı.
                    maliyeti = Convert.ToDouble(tbMaliyeti.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrWhiteSpace(tbKazanci.Text))
                {
                    kazanci = Convert.ToDouble(tbKazanci.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                }
                if (ddlYapimci.SelectedValue == "")
                {
                    lMesaj.Text = "Yapımcı seçilmelidir.";
                    return;
                }
                List<int> turIdleri = new List<int>(); //birden fazla seçilebilecegı ıcın ıtem ıtem donmem lazım.

                //int[] selectedIndices = lbTurler.GetSelectedIndices();  //2. Yöntem
                //for (int i = 0; i < selectedIndices.Length; i++)
                //{
                //    turIdleri.Add(Convert.ToInt32(lbTurler.Items[selectedIndices[i]].Value));
                //}

                foreach (ListItem item in lbTurler.Items)     //1. Yöntem
                {
                    if (item.Selected)
                        turIdleri.Add(Convert.ToInt32(item.Value));
                }

                OyunModel model = new OyunModel()
                {
                    Adi = tbAdi.Text,
                    Maliyeti = maliyeti,
                    Kazanci = kazanci,
                    //YapimTarihi = cYapimTarihi.SelectedDate
                    YapimciId = Convert.ToInt32(ddlYapimci.SelectedValue),
                    TurIdleri = turIdleri
                };
                if (cYapimTarihi.SelectedDates.Count > 0)
                    model.YapimTarihi = cYapimTarihi.SelectedDate;
                _oyunService.Add(model);
                FillGrid();
                pEkle.Visible = false;
                lMesaj.Text = "Oyun kaydedildi!";

                //throw new IndexOutOfRangeException();  Hata yakalamak istersen bunu fırlat aşağıdaki catch yakalar.
            }
            catch (FormatException exc)   //sayısal değer girmezse buraya atacak. Genel bir sorun varsa aşağıdakine atacak.
            {

                lMesaj.Text = "Maliyeti ve kazancı sayısal olmalıdır!";
            }
            catch (Exception exc)
            {
                lMesaj.Text = "İşlem sırasında hata meydana geldi!";
            }
        }

        protected void lbDuzenle_Click(object sender, EventArgs e)

        {
            pEkle.Visible = false;
            pDuzenle.Visible = true;
            pDetay.Visible = false;
            gvYapimcilar.Visible = false;
            panelYapimci.Visible = false;
            pYapimciDetay.Visible = false;
            pYapimciGuncelle.Visible = false;
            pYeniYapimciEkleme.Visible = false;
            FillYapimcilar(ddlYapimciDuzenleme);
            FillTurler(lbTurlerDuzenleme);
            FillDetails();
        }

        private void FillDetails()
        {
            try
            {
                if (gvOyunlar.SelectedIndex == -1)
                {
                    lMesaj.Text = "Kayıt seçiniz.";
                    return;
                }
                int id = Convert.ToInt32(gvOyunlar.SelectedRow.Cells[1].Text);
                OyunModel model = _oyunService.GetQuery().SingleOrDefault(oyun => oyun.Id == id);
                tbAdiDuzenleme.Text = model.Adi;
                tbKazanciDuzenleme.Text = "";
                if (model.Kazanci.HasValue)
                {
                    tbKazanciDuzenleme.Text = model.Kazanci.Value.ToString(new CultureInfo("tr"));
                }
                tbMaliyetiDuzenleme.Text = "";
                if (model.Maliyeti.HasValue)
                {
                    tbMaliyetiDuzenleme.Text = model.Maliyeti.Value.ToString(new CultureInfo("tr"));
                }
                cYapimTarihiDuzenleme.SelectedDates.Clear();
                if (model.YapimTarihi.HasValue)
                {
                    cYapimTarihiDuzenleme.SelectedDate = model.YapimTarihi.Value;
                }
                ddlYapimciDuzenleme.SelectedValue = "";
                if (model.YapimciId.HasValue)
                {
                    ddlYapimciDuzenleme.SelectedValue = model.YapimciId.Value.ToString();
                }
                lbTurlerDuzenleme.ClearSelection();//içindekileri önce kaldırır. Sonra aldığımız veri set edilir.
                foreach (ListItem item in lbTurlerDuzenleme.Items)
                {
                    foreach (int turId in model.TurIdleri)
                    {
                        if (item.Value == turId.ToString())
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception exc)
            {

                lMesaj.Text = "İşlem sırasında hata meydana geldi!" + exc.Message;
            }
        }

        protected void gvOyunlar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void bTemizleDuzenleme_Click(object sender, EventArgs e)
        {
            tbAdiDuzenleme.Text = "";
            tbKazanciDuzenleme.Text = "";
            tbMaliyetiDuzenleme.Text = "";
            cYapimTarihiDuzenleme.SelectedDates.Clear();
            ddlYapimciDuzenleme.SelectedValue = "";
        }

        protected void bKaydetDuzenleme_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvOyunlar.SelectedIndex == -1)
                {
                    lMesaj.Text = " Kayıt seçiniz!";
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbAdiDuzenleme.Text))
                {
                    lMesaj.Text = "Adı girilmelidir.";
                    return;
                }
                double? maliyeti = null, kazanci = null;
                if (!string.IsNullOrWhiteSpace(tbMaliyetiDuzenleme.Text))
                {
                    maliyeti = Convert.ToDouble(tbMaliyetiDuzenleme.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrWhiteSpace(tbKazanciDuzenleme.Text))
                {
                    kazanci = Convert.ToDouble(tbKazanciDuzenleme.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                }
                if (ddlYapimciDuzenleme.SelectedValue == "")
                {
                    lMesaj.Text = "Yapımcı seçilmelidir.";
                    return;
                }
                OyunModel model = new OyunModel()
                {
                    Id = Convert.ToInt32(gvOyunlar.SelectedRow.Cells[1].Text),
                    Adi = tbAdiDuzenleme.Text,
                    Maliyeti = maliyeti,
                    Kazanci = kazanci,
                    YapimTarihi = cYapimTarihiDuzenleme.SelectedDate,
                    YapimciId = Convert.ToInt32(ddlYapimciDuzenleme.SelectedValue)
                };

                //model.TurIdleri = new List<int>();
                //foreach (ListItem listItem in lbTurlerDuzenleme.Items)
                //{
                //    if (listItem.Selected)
                //    {
                //        model.TurIdleri.Add(Convert.ToInt32(listItem.Value));
                //    }
                //}

                model.TurIdleri = lbTurlerDuzenleme.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => Convert.ToInt32(item.Value)).ToList();

                _oyunService.Update(model);
                FillGrid();
                pDuzenle.Visible = false;
                lMesaj.Text = "Oyun kaydedildi!";

            }
            catch (FormatException exc)
            {

                lMesaj.Text = "Maliyeti ve kazancı sayısal olmalıdır!";
            }
            catch (Exception exc)
            {
                lMesaj.Text = "İşlem sırasında hata meydana geldi!";
            }
        }

        protected void lbSil_Click(object sender, EventArgs e)
        {
            if (gvOyunlar.SelectedIndex == -1)
            {
                lMesaj.Text = " Kayıt seçiniz!";
                return;
            }
            int id = Convert.ToInt32(gvOyunlar.SelectedRow.Cells[1].Text);
            _oyunService.Delete(id);
            lMesaj.Text = "Kayıt silindi.";
            FillGrid();    //veritabanından tekrar alıp kayıtları dolduracak.
        }

        protected void lbDetay_Click(object sender, EventArgs e)
        {
            if (gvOyunlar.SelectedIndex == -1)
            {
                lMesaj.Text = " Kayıt seçiniz!";
                return;
            }
            int id = Convert.ToInt32(gvOyunlar.SelectedRow.Cells[1].Text);
            OyunModel model = _oyunService.GetQuery().SingleOrDefault(oyun => oyun.Id == id);
            lAdiDetay.Text = model.Adi;
            lKazanciDetay.Text = model.Kazanci.HasValue ? model.Kazanci.Value.ToString("C2", new CultureInfo("tr")) : "";
            lMaliyetiDetay.Text = model.Maliyeti.HasValue ? model.Maliyeti.Value.ToString("C2", new CultureInfo("tr")) : "";
            lYapimTarihiDetay.Text = model.YapimTarihiFormat;
            lYapimciDetay.Text = model.Yapimci;
            lTurlerDetay.Text = model.TurlerText;
            pDetay.Visible = true;
            pEkle.Visible = false;
            pDuzenle.Visible = false;
            pYapimciDetay.Visible = false;
            pYapimciGuncelle.Visible = false;
            pYeniYapimciEkleme.Visible = false;
        }

        protected void lbYapimciDuzenleme_Click(object sender, EventArgs e)
        {
            pDetay.Visible = false;
            pEkle.Visible = false;
            pDuzenle.Visible = false;
            gvYapimcilar.Visible = true;
            panelYapimci.Visible = true;
            pYapimciDetay.Visible = false;
            pYapimciGuncelle.Visible = false;
            pYeniYapimciEkleme.Visible = false;

        }

        private void FillGridYapimci()
        {
            try
            {
                var yapimcilar = _yapimciService.GetQuery().ToList();
                gvYapimcilar.DataSource = yapimcilar;
                gvYapimcilar.DataBind();
                SetColumnVisibilitiesYapimci();
                gvYapimcilar.SelectedIndex = -1;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
        private void SetColumnVisibilitiesYapimci()
        {
            if (gvYapimcilar.Rows != null && gvYapimcilar.Rows.Count > 0)
            {
                gvYapimcilar.HeaderRow.Cells[1].Visible = false;
                foreach (GridViewRow row in gvYapimcilar.Rows)
                {
                    row.Cells[1].Visible = false;
                }
            }

        }

        protected void lbEkleYeniYapimci_Click(object sender, EventArgs e)
        {
            pYeniYapimciEkleme.Visible = true;
            pYapimciGuncelle.Visible = false;
            FillUlke(ddlYapimciEkleUlke);
            pYapimciDetay.Visible = false;
        }

        protected void bKaydetYeniYapimciEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbYeniYapimciEkleAd.Text))
                {
                    lMesaj.Text = "Yapımcı Adı girilmelidir!";
                    return;
                }
                if (ddlYapimciEkleUlke.SelectedValue == "")
                {
                    lMesaj.Text = "Ulke seçilmelidir.";
                    return;
                }
                YapimciModel model = new YapimciModel()
                {
                    Adi = tbYeniYapimciEkleAd.Text,
                    UlkeId = Convert.ToInt32(ddlYapimciEkleUlke.SelectedValue)
                };
                _yapimciService.Add(model);
                FillGridYapimci();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        protected void bTemizleYeniKayitEkle_Click(object sender, EventArgs e)
        {
            tbYeniYapimciEkleAd.Text = "";
            ddlYapimciEkleUlke.SelectedValue = "";
        }

        protected void FillUlke(DropDownList ulkegetir)
        {
            List<YapimciModel> ulkedoldur = _yapimciService.GetQueryUlke().ToList();
            ulkegetir.DataValueField = "UlkeId";
            ulkegetir.DataTextField = "UlkeAdi";
            ulkegetir.DataSource = ulkedoldur;
            ulkegetir.DataBind();
            ulkegetir.Items.Insert(0, new ListItem()
            {
                Value = "",
                Text = "--Seçiniz--"
            });
        }

        protected void bTemizleGuncelle_Click(object sender, EventArgs e)
        {
            tbYeniYapimciEkleAd.Text = "";
            ddlYapimciEkleUlke.SelectedValue = "";
        }

        protected void lbYeniYapimciGüncelle_Click(object sender, EventArgs e)
        {
            pYapimciGuncelle.Visible = true;
            pYeniYapimciEkleme.Visible = false;
            pYapimciDetay.Visible = false;
            FillUlke(ddlYeniGuncelle);
            FillUlkeDetails();

        }

        private void FillUlkeDetails()
        {
            if (gvYapimcilar.SelectedIndex == -1)
            {
                lMesaj.Text = "Kayıt seçiniz.";
                return;
            }
            int id = Convert.ToInt32(gvYapimcilar.SelectedRow.Cells[1].Text);
            YapimciModel model = _yapimciService.GetQuery().SingleOrDefault(yapimci => yapimci.Id == id);
            tbYeniGuncelle.Text = model.Adi;
            ddlYeniGuncelle.SelectedValue = "";
            ddlYeniGuncelle.SelectedValue = model.UlkeId.ToString();
        }

        protected void bKaydetGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvYapimcilar.SelectedIndex == -1)
                {
                    lMesaj.Text = " Kayıt seçiniz!";
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbYeniGuncelle.Text))
                {
                    lMesaj.Text = "Adı girilmelidir.";
                    return;
                }
                if (ddlYeniGuncelle.SelectedValue == "")
                {
                    lMesaj.Text = "Yapımcı seçilmelidir.";
                    return;
                }
                
                YapimciModel model = new YapimciModel()
                {
                    Id = Convert.ToInt32(gvYapimcilar.SelectedRow.Cells[1].Text),
                    Adi = tbYeniGuncelle.Text,
                    UlkeId = Convert.ToInt32(ddlYeniGuncelle.SelectedValue)
                };

                _yapimciService.Guncelle(model);
                FillGridYapimci();
                pYapimciGuncelle.Visible = false;
                lMesaj.Text = "Yapimci kaydedildi!";
            }
            catch (FormatException exc)
            {

            }
        }

        protected void lbYeniYapimciSil_Click(object sender, EventArgs e)
        {
            if (gvYapimcilar.SelectedIndex == -1)
            {
                lMesaj.Text = "Kayıt seçiniz!";
                return;
            }
            int id = Convert.ToInt32(gvYapimcilar.SelectedRow.Cells[1].Text);
            _yapimciService.Delete(id);
            lMesaj.Text = "Kayıt silindi.";
            FillGridYapimci();
        }
        
        protected void YapimciDetay_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvYapimcilar.SelectedIndex == -1)
                {
                    lMesaj.Text = "Kayıt seçiniz!";
                    return;
                }
                int id = Convert.ToInt32(gvYapimcilar.SelectedRow.Cells[1].Text);
                YapimciModel model = _yapimciService.GetQuery().SingleOrDefault(yapimci => yapimci.Id == id);
                lAdiYapimciDetay.Text = model.Adi;
                lUlkeYapimciDetay.Text = model.UlkeAdi;
                pYapimciDetay.Visible = true;
                pYapimciGuncelle.Visible = false;
                pYeniYapimciEkleme.Visible = false;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}