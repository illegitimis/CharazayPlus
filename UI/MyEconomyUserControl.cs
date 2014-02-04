namespace AndreiPopescu.CharazayPlus.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;

  public partial class MyEconomyUserControl : UserControl
  {
    public MyEconomyUserControl ( )
    {
      InitializeComponent();
    }

    /// <summary>
    /// my team transfer history
    /// tab: My Economy
    /// </summary>
    public void InitDgMyTransfers ( Xsd2.charazayTransfer[] _myTransfers)
    {
#if DOTNET30
      dgTeamTransfers.initGridPrologue ();            
      dgTeamTransfers.GenerateTextBoxColumn( "Seller", "Seller");
      dgTeamTransfers.GenerateTextBoxColumn( "Buyer", "Buyer");
      dgTeamTransfers.GenerateTextBoxColumn( "Date", "Date");
      dgTeamTransfers.GenerateTextBoxColumn( "Player", "Player");
      dgTeamTransfers.GenerateTextBoxColumn( "Skill Index", "si");
      dgTeamTransfers.GenerateTextBoxColumn( "Price", "price");
      dgTeamTransfers.initGridEpilogue<Xsd2.charazayTransfer> (_myTransfers);      
#else
      DataGridExtensions.initGridPrologue(dgTeamTransfers);
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Seller", "Seller");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Buyer", "Buyer");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Date", "Date");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Player", "Player");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Skill Index", "si");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Price", "price");
      DataGridExtensions.initGridEpilogue<Xsd2.charazayTransfer>(dgTeamTransfers, _myTransfers);
#endif
    }

    public void InitDgMyTransfers(XsdMerge.team_transfers _myTransfers)
    {
#if DOTNET30
      dgTeamTransfers.initGridPrologue ();            
      dgTeamTransfers.GenerateTextBoxColumn( "Seller", "Seller");
      dgTeamTransfers.GenerateTextBoxColumn( "Buyer", "Buyer");
      dgTeamTransfers.GenerateTextBoxColumn( "Date", "Date");
      dgTeamTransfers.GenerateTextBoxColumn( "Player", "Player");
      dgTeamTransfers.GenerateTextBoxColumn( "Skill Index", "si");
      dgTeamTransfers.GenerateTextBoxColumn( "Price", "price");
      dgTeamTransfers.initGridEpilogue<Xsd2.charazayTransfer> (_myTransfers);      
#else
        DataGridExtensions.initGridPrologue(dgTeamTransfers);
        DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Seller", "Seller");
        DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Buyer", "Buyer");
        DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Date", "Date");
        DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Player", "Player");
        DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Skill Index", "si");
        DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Price", "price");
        DataGridExtensions.initGridEpilogue<XsdMerge.transfer>(dgTeamTransfers, _myTransfers.transfer);
#endif
    }
    
    public void InitEconomyUserControls ( Xsd2.charazayEconomy _economy)
    {
      //ucEconomyWeek.Income = _economy.economy_week.income;
      //ucEconomyWeek.Expences = _economy.economy_week.expences;
      //ucEconomyWeek.IsWeek = true;

      //ucEconomySeason.Income = _economy.economy_season.income;
      //ucEconomySeason.Expences = _economy.economy_season.expences;
      //ucEconomySeason.IsWeek = false;

      ucEconomyWeek.LabelsInit(_economy.economy_week.income, _economy.economy_week.expences, true);
      ucEconomySeason.LabelsInit(_economy.economy_season.income, _economy.economy_season.expences, false);
    }

    public void InitEconomyUserControls(XsdMerge.economy _economy)
    {
        ucEconomyWeek.LabelsInit(_economy.economy_week.income, _economy.economy_week.expences, true);
        ucEconomySeason.LabelsInit(_economy.economy_season.income, _economy.economy_season.expences, false);
    }

  }
}
