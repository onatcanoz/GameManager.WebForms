<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Oyunlar.aspx.cs" Inherits="UserInterface1.Oyunlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
    <asp:GridView ID="gvOyunlar" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" Width="1018px" OnSelectedIndexChanged="gvOyunlar_SelectedIndexChanged" ForeColor="Black">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Seç" ShowSelectButton="True">
            <HeaderStyle Width="40px" />
            </asp:CommandField>
            <asp:BoundField DataField="Id" />
            <asp:BoundField DataField="Adi" HeaderText="Oyun Adı" >
            <HeaderStyle Width="170px" />
            </asp:BoundField>
            <asp:BoundField DataField="Maliyeti" HeaderText="Oyun Maliyeti" >
            <HeaderStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="Kazanci" HeaderText="Oyunun Kazancı" >
            <HeaderStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="KarZarar" HeaderText="Kar/Zarar">
            <HeaderStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="Yapimci" HeaderText="Yapımcı" >
            <HeaderStyle Width="180px" />
            </asp:BoundField>
            <asp:BoundField DataField="YapimTarihiFormat" HeaderText="Yapım Tarihi" >
            <HeaderStyle Width="140px" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:LinkButton ID="lbYeni" runat="server" OnClick="lbYeni_Click">Yeni Oyun</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbDuzenle" runat="server" OnClick="lbDuzenle_Click">Oyun Duzenle</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbSil" runat="server" OnClick="lbSil_Click">Oyun Sil</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbDetay" runat="server" OnClick="lbDetay_Click">Oyun Detay</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbYapimciDuzenleme" runat="server" OnClick="lbYapimciDuzenleme_Click">Yapimci Duzenle</asp:LinkButton>
</p>
    <p>
        <asp:Label ID="lMesaj" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="#FF3300"></asp:Label>
        <asp:GridView ID="gvYapimcilar" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False" Width="589px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="Seç" ShowSelectButton="True" />
                <asp:BoundField DataField="Id" />
                <asp:BoundField DataField="Adi" HeaderText="Adi" />
                <asp:BoundField DataField="UlkeAdi" HeaderText="Ulke" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
</p>
    <p>
</p>
    <asp:Panel ID="pEkle" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Size="Small" Visible="False">
        Oyun Ekleme<br />
        <asp:Label ID="Label1" runat="server" Text="Adi"></asp:Label>
        :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbAdi" runat="server" BorderColor="#66FF66" Height="21px" Width="287px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Maliyeti"></asp:Label>
        :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbMaliyeti" runat="server" BorderColor="#99FF99" Height="21px" Width="291px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Kazanci"></asp:Label>
        :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbKazanci" runat="server" BorderColor="#99FF99" Height="21px" Width="294px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Yapım Tarihi"></asp:Label>
        :&nbsp;&nbsp;
        <asp:Calendar ID="cYapimTarihi" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Yapimci"></asp:Label>
        :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlYapimci" runat="server" Font-Size="12pt" Height="25px" Width="237px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lTurler" runat="server" Text="Turler:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="lbTurler" runat="server" Height="127px" SelectionMode="Multiple" Width="235px"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="bKaydet" runat="server" OnClick="bKaydet_Click" Text="KAYDET" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bTemizle" runat="server" OnClick="bTemizle_Click" Text="TEMİZLE" />
        <br />
    </asp:Panel>
    <p>
        &nbsp;</p>
    <p>
    <asp:Panel ID="pDuzenle" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Size="Small" Visible="False">
        Oyun Düzenleme<br />
        <asp:Label ID="Label6" runat="server" Text="Adi"></asp:Label>
        :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbAdiDuzenleme" runat="server" BorderColor="#66FF66" Height="21px" Width="287px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Maliyeti"></asp:Label>
        :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbMaliyetiDuzenleme" runat="server" BorderColor="#99FF99" Height="21px" Width="291px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Kazanci"></asp:Label>
        :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbKazanciDuzenleme" runat="server" BorderColor="#99FF99" Height="21px" Width="294px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Yapım Tarihi"></asp:Label>
        :&nbsp;&nbsp;
        <asp:Calendar ID="cYapimTarihiDuzenleme" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Yapimci"></asp:Label>
        :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlYapimciDuzenleme" runat="server" Font-Size="12pt" Height="25px" Width="237px">
        </asp:DropDownList>
        <br />
        <br />
        Turler:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="lbTurlerDuzenleme" runat="server" Height="127px" SelectionMode="Multiple" Width="235px"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="bKaydetDuzenleme" runat="server" OnClick="bKaydetDuzenleme_Click" Text="KAYDET" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bTemizleDuzenleme" runat="server" OnClick="bTemizleDuzenleme_Click" Text="TEMİZLE" />
    </asp:Panel>
    <p>
    </p>
    <asp:Panel ID="pDetay" runat="server" Visible="False">
        <asp:Label ID="lAdi" runat="server" Text="Adi"></asp:Label>
        :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lAdiDetay" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="#FF3300"></asp:Label>
        <br />
        <asp:Label ID="lMaliyeti" runat="server" Text="Maliyeti"></asp:Label>
        :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lMaliyetiDetay" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="#FF3300"></asp:Label>
        &nbsp;
        <br />
        <asp:Label ID="lKazanci" runat="server" Text="Kazanci"></asp:Label>
        :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lKazanciDetay" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="#FF3300"></asp:Label>
        <br />
        <asp:Label ID="lYapimTarihi" runat="server" Text="Yapim Tarihi"></asp:Label>
        :&nbsp;&nbsp;
        <asp:Label ID="lYapimTarihiDetay" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="#FF3300"></asp:Label>
        <br />
        <asp:Label ID="lYapimci" runat="server" Text="Yapimci"></asp:Label>
        :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lYapimciDetay" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="#FF3300"></asp:Label>
        <br />
        <asp:Label ID="lTurler0" runat="server" Text="Turler"></asp:Label>
        :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="lTurlerDetay" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="#FF3300"></asp:Label>
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
    <asp:Panel ID="panelYapimci" runat="server" Visible="False">
        <asp:LinkButton ID="lbEkleYeniYapimci" runat="server" OnClick="lbEkleYeniYapimci_Click">Yeni Yapimci Ekle</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbYeniYapimciGüncelle" runat="server" OnClick="lbYeniYapimciGüncelle_Click">Yapimci Güncelle</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbYeniYapimciSil" runat="server" OnClick="lbYeniYapimciSil_Click">Yapimci Sil</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="YapimciDetay" runat="server" OnClick="YapimciDetay_Click">Yapımcı Detayları</asp:LinkButton>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="pYeniYapimciEkleme" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False">
        <asp:Label ID="lYeniYapimciEklemeAd" runat="server" Text="Yapimci Adı: "></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbYeniYapimciEkleAd" runat="server" Width="187px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lYeniYapimciEklemeUlke" runat="server" Text="Yapimci Ulkesi: "></asp:Label>
        <asp:DropDownList ID="ddlYapimciEkleUlke" runat="server" Font-Size="12pt" Height="25px" Width="237px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="bKaydetDuzenleme0" runat="server" OnClick="bKaydetYeniYapimciEkle_Click" Text="KAYDET" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bTemizleDuzenleme0" runat="server" OnClick="bTemizleYeniKayitEkle_Click" Text="TEMİZLE" />
        <br />
        <br />
    </asp:Panel>
&nbsp;
    <br />
    <asp:Panel ID="pYapimciGuncelle" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False" Width="1121px">
        <asp:Label ID="lYeniYapimciEklemeAd0" runat="server" Text="Yeni Yapimci Adı: "></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbYeniGuncelle" runat="server" Width="180px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lYeniYapimciEklemeUlke0" runat="server" Text="Yeni Yapimci Ulkesi: "></asp:Label>
        <asp:DropDownList ID="ddlYeniGuncelle" runat="server" Font-Size="12pt" Height="25px" Width="237px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="bKaydetGuncelle" runat="server" OnClick="bKaydetGuncelle_Click" Text="KAYDET" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bTemizleGuncelle" runat="server" OnClick="bTemizleGuncelle_Click" Text="TEMİZLE" />
    </asp:Panel>
    <asp:Panel ID="pYapimciDetay" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False" Width="1121px">
        <asp:Label ID="lAddd" runat="server" Text="Yapımcı Adı:"></asp:Label>
        <asp:Label ID="lAdiYapimciDetay" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lUlkeeee" runat="server" Text="Yapımcı Ülkesi:"></asp:Label>
        <asp:Label ID="lUlkeYapimciDetay" runat="server"></asp:Label>

    </asp:Panel>

</asp:Content>
