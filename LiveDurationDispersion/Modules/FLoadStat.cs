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
using ZedGraph;
using LiveDurationDispersion.Properties;
namespace LiveDurationDispersion.Modules
{
  public partial class FLoadStat : Form
  {
    List<HumanInfo> Peoples = new List<HumanInfo>();
    Dictionary<int, List<int>> LiveDurationDisp = new Dictionary<int, List<int>>();
    HumanDBDataSet _db = new HumanDBDataSet();
    int DayCount = 1;
    public FLoadStat()
    {
      InitializeComponent();
    }

    private void FLoadStat_Load(object sender, EventArgs e)
    {

    }

    private void calc_button_Click(object sender, EventArgs e)
    {
      DateTime BeginDate = (DateTime)StartDate.ValidateText();
      DateTime StopDate = (DateTime)EndDate.ValidateText();

      //string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;" + @"data source=C:\data\dbase.mdb";
      OleDbConnection conn = new OleDbConnection(Settings.Default.DbConnectionString);
      conn.Open();
      OleDbCommand cmd = new OleDbCommand("SELECT * FROM Главная ", conn);
      OleDbDataReader reader = cmd.ExecuteReader();
      while (reader.Read())
      {
        try
        {
          //Peoples.Add(new HumanInfo(reader));
        }
        catch
        {

        }
      }
      MessageBox.Show("Data Loaded Successfuly");

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
      for (int i = 0; i < itemscount; i++)
      {
        values.Add(i-2, rnd.Next(100));
        errorList.Add(i-2, values[i].Y - 10, values[i].Y + 10);
      }

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
    public DataSet WareHouseCon()
    {
      string command = "SELECT * FROM Store";
      OleDbConnection cnn = new OleDbConnection(Settings.Default.DbConnectionString);
      cnn.Open();
      DataSet ds = new DataSet();
      OleDbDataAdapter adapter = new OleDbDataAdapter(command, cnn);
      adapter.Fill(ds);
      cnn.Close();
      return ds;
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
      }
      catch (Exception e)
      {
        throw new InvalidOperationException("bad fields: " + e.Message);
      }
    }
  }
}
