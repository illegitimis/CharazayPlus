namespace AndreiPopescu.CharazayPlus
{
  using System;
  using System.Xml.Serialization;
  using BrightIdeasSoftware;

  public class Coach
  {

    private Xsd2.charazayCoach m_coach;
    public Coach (Xsd2.charazayCoach coach) { m_coach = coach; }


    [OLVColumn(DisplayIndex = 0, IsEditable = false, Width = 130, MinimumWidth = 100, MaximumWidth = 200)]
    public string FullName
    {
      get { return string.Format("{0} {1}", m_coach.basic.name, m_coach.basic.surname); }
      set { }
    }

    public byte Age { get { return m_coach.basic.age; } }
    public ulong Price { get { return m_coach.price; } }
    public ulong Salary { get { return m_coach.salary; } }
    public uint Id { get { return m_coach.id; } }
    public byte CountryId { get { return m_coach.countryid; } }

    //skills
    [OLVColumn(DisplayIndex = 1, IsEditable = false, Width = 60, MinimumWidth = 45, MaximumWidth = 75)]
    public byte Defence { get { return m_coach.skills.defence; } }
    [OLVColumn(DisplayIndex = 2, IsEditable = false, Width = 60, MinimumWidth = 45, MaximumWidth = 75)]
    public byte Freethrows { get { return m_coach.skills.freethrow; } }
    [OLVColumn(DisplayIndex = 3, IsEditable = false, Width = 60, MinimumWidth = 45, MaximumWidth = 75)]
    public byte TwoPoint { get { return m_coach.skills.twopoint; } }
    [OLVColumn(DisplayIndex = 4, IsEditable = false, Width = 60, MinimumWidth = 45, MaximumWidth = 75)]
    public byte ThreePoint { get { return m_coach.skills.threepoint; } }
    [OLVColumn(DisplayIndex = 5, IsEditable = false, Width = 60, MinimumWidth = 45, MaximumWidth = 75)]
    public byte Dribling { get { return m_coach.skills.dribling; } }
    [OLVColumn(DisplayIndex = 6, IsEditable = false, Width = 60, MinimumWidth = 45, MaximumWidth = 75)]
    public byte Passing { get { return m_coach.skills.passing; } }
    [OLVColumn(DisplayIndex = 7, IsEditable = false, Width = 60, MinimumWidth = 45, MaximumWidth = 75)]
    public byte Speed { get { return m_coach.skills.speed; } }
    [OLVColumn(DisplayIndex = 8, IsEditable = false, Width = 60, MinimumWidth = 45, MaximumWidth = 75)]
    public byte Footwork { get { return m_coach.skills.footwork; } }
    [OLVColumn(DisplayIndex = 9, IsEditable = false, Width = 60, MinimumWidth = 45, MaximumWidth = 75)]
    public byte Rebounds { get { return m_coach.skills.rebounds; } }
    [OLVColumn(DisplayIndex = 10, IsEditable = false, Width = 60, MinimumWidth = 45, MaximumWidth = 75)]
    public byte Experience { get { return m_coach.skills.experience; } }

  }
}