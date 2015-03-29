using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;
using ZedGraph;
using LiveDurationDispersion.Properties;
namespace LiveDurationDispersion.Modules
{
  public partial class FLoadStat : Form
  {
    public delegate void OnDataLoadedDelegate(List<HumanInfo> Peoples);
    public event OnDataLoadedDelegate OnDataLoaded;
    List<HumanInfo> Peoples = new List<HumanInfo>();
    int DayCount = 1;
    Thread dataLoadThread;
    Dictionary<int, List<int>> StatCollection = new Dictionary<int, List<int>>();
#if DEBUG
      int debugCount = 20000;
#endif

    public FLoadStat()
    {
      InitializeComponent();
      OnDataLoaded += FLoadStat_OnDataLoaded;
    }

    void FLoadStat_OnDataLoaded(List<HumanInfo> Peoples)
    {
      MessageBox.Show("Data Loaded Successfuly!!");
     
    }

    private void FLoadStat_Load(object sender, EventArgs e)
    {
      DaysCountNumeric.Value = DayCount;
    }

    private void dataloadparalelfunction()
    {
      DateTime BeginDate = (DateTime)StartDate.ValidateText();
      DateTime StopDate = (DateTime)EndDate.ValidateText();

      //string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;" + @"data source=C:\data\dbase.mdb";
      OleDbConnection conn = new OleDbConnection(Settings.Default.DbConnectionString);
      conn.Open();
      OleDbCommand cmd = new OleDbCommand("SELECT * FROM Главная ", conn);
      OleDbDataReader reader = cmd.ExecuteReader();
      int last = 0;


      while (reader.Read())
      {
        try
        {
          // old
          //Peoples.Add(new HumanInfo(reader));

          HumanInfo person = new HumanInfo(reader);
          if (person.Bdate > BeginDate && person.DethDate < StopDate)
            Peoples.Add(person);
#if DEBUG
          debugCount--;
          if (debugCount < 1)
            break;
#endif
          if (last + 150 < Peoples.Count)
          {
            last = Peoples.Count;
            if (PeopleCountMonitor.InvokeRequired)
            {
              PeopleCountMonitor.BeginInvoke((Action)(() => { PeopleCountMonitor.Text = last.ToString(); }));
            }
            else

              PeopleCountMonitor.Text = last.ToString();
          }
        }
        catch
        {

        }
      }
      OnDataLoaded(Peoples);
    }

    private void calc_button_Click(object sender, EventArgs e)
    {
      StatCollection = new Dictionary<int, List<int>>();
      List<double>[] preStatDisp = new List<double>[DayCount];
      List<double>[] postStatDisp = new List<double>[DayCount];
      List<double> StatDisp = new List<double>();
      for (int z = 0; z < DayCount; z++)
      {
        preStatDisp[z] = new List<double>();
        postStatDisp[z] = new List<double>();
      }
      foreach (HumanInfo person in Peoples)
      {
        int LifeLength = (person.DethDate - person.Bdate).Days / (int)365;
        int Key = 365 * person.Bdate.Year + person.Bdate.DayOfYear;
        if (!StatCollection.ContainsKey(Key)) StatCollection.Add(Key, new List<int>());
        StatCollection[Key].Add(LifeLength);
      }
      FHelpForm form = new FHelpForm(StatCollection);
      //form.MdiParent = this.MdiParent;
      form.Show();
      //подсчет данных;
      int TrueDataCount = 0;
      foreach (int i in StatCollection.Keys)
      {
        bool Validate = true;
        for (int j = -DayCount; j <= DayCount; j++)
        {
          if (!StatCollection.ContainsKey(i + j))
          {
            Validate = false;
            break;
          }
          if (StatCollection[i + j].Count < 5)
          {
            Validate = false;
            break;
          }
        }
        if (Validate)
        {
          TrueDataCount++;
          for (int j = -DayCount; j <= DayCount; j++)
          {

            double sigma = 0;
            double average = 0;
            average = StatCollection[i + j].Average();
            int Count = StatCollection[i + j].Count;
            List<int> LifeList = new List<int>();
            if (j < 0)
            {
              LifeList = StatCollection[i + j];
              LifeList.AddRange(StatCollection[i]);
            }
            if (j > 0)
            {
              LifeList = StatCollection[i + j];
              LifeList.AddRange(StatCollection[i]);
            }
            if (j == 0)
            {
              LifeList = StatCollection[i];
            }
            for (int z = 0; z < Count; z++)
            {
              sigma += Math.Pow((average - LifeList[z]), 2);
            }
            sigma /= (Count + 1);
            sigma = Math.Sqrt(sigma);
            if (j > 0)
              postStatDisp[j - 1].Add(sigma);
            if (j == 0)
              StatDisp.Add(sigma);
            if (j < 0)
              preStatDisp[DayCount + j].Add(sigma);
          }
        }
      }
      MessageBox.Show("Данные успешно посчитаны, наборов заполненых дат: " + TrueDataCount.ToString());
      // Получим панель для рисования
      GraphPane pane = zedGraph.GraphPane;

      // Очистим список кривых
      pane.CurveList.Clear();

      // Количество столбцов в гистограмме
      int itemscount = 5;

      Random rnd = new Random();

      // Высота столбцов
      PointPairList values = new PointPairList();
      PointPairList errorList = new PointPairList();
      // Заполним данные
      for (int i = 0; i < DayCount; i++)
      {
        values.Add(1 + i, postStatDisp[i].Average());
        values.Add(-1 - i, preStatDisp[i].Average());
        errorList.Add(i - 2, values[i].Y - 10, values[i].Y + 10);
      }
      values.Add(0, StatDisp.Average());

      // Создадим точки ошибок
      ErrorBarItem errorCurve = pane.AddErrorBar("Error", errorList, Color.Black);
      // Создадим кривую-гистограмму
      BarItem curve = pane.AddBar("Гистограмма", values, Color.Blue);

      // !!!
      // Установим цвет для столбцов гистограммы
      curve.Bar.Fill.Color = Color.YellowGreen;

      // Отключим градиентную заливку
      curve.Bar.Fill.Type = FillType.Solid;

      // Сделаем границы столбцов невидимыми
      curve.Bar.Border.IsVisible = false;

      // !!! Расстояния между кластерами (группами столбиков) гистограммы = 0.0
      // У нас в кластере только один столбик.
      pane.BarSettings.MinClusterGap = 0.5f;
      pane.BarSettings.MinBarGap = 0.5f;
      pane.BarSettings.Type = BarType.Overlay;
      // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
      zedGraph.AxisChange();

      // Обновляем график
      zedGraph.Invalidate();
    }

    private void zedGraph_Load(object sender, EventArgs e)
    {
      this.zedGraph.GraphPane.XAxis.Title.IsVisible = false;
      this.zedGraph.GraphPane.YAxis.Title.IsVisible = false;
      this.zedGraph.GraphPane.Margin.Left = 0;
      this.zedGraph.GraphPane.Margin.Left = 0;
      this.zedGraph.GraphPane.IsFontsScaled = false;
    }

    private void DaysCountNumeric_ValueChanged(object sender, EventArgs e)
    {
      DayCount = (int)DaysCountNumeric.Value;
    }

    private void FLoadStat_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (dataLoadThread != null && dataLoadThread.IsAlive)
        dataLoadThread.Abort();
    }

    private void LoadDBbutton_Click(object sender, EventArgs e)
    {
      dataLoadThread = new Thread(dataloadparalelfunction);
      dataLoadThread.Start();
    }
  }
  public class HumanInfo
  {
    public string id;
    public string Name;
    public DateTime Bdate;
    public string addr;
    public char sex;
    public DateTime DethDate;
    public HumanInfo() { }
    public HumanInfo(OleDbDataReader reader)
    {
      Dictionary<string, string> Fields = new Dictionary<string, string>();
      for (int i = 0; i < reader.FieldCount; i++)
      {
        Fields.Add(reader.GetName(i), reader.GetValue(i).ToString());
      }
      try
      {
        this.id = Fields["N baza"];
        this.Name = Fields["ФИО"];
        this.addr = Fields["адрес"];
        this.Bdate = DateTime.Parse(Fields["дата рождения"]);
        this.DethDate = DateTime.Parse(Fields["дата смерти"]);
        this.sex = Fields["пол"][0];
        if (Bdate.Month == 11 && Bdate.Day == 11)
          throw new InvalidOperationException("11.11 special error code");
      }
      catch (Exception e)
      {
        throw new InvalidOperationException("bad fields: " + e.Message);
      }
    }
  }
}
