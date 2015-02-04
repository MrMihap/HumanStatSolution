using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
namespace LiveDurationDispersion.Modules
{
  public partial class FHelpForm : Form
  {
    Dictionary<int, List<int>> Statcollection;
    public FHelpForm()
    {
      InitializeComponent();
    }

    public FHelpForm(Dictionary<int, List<int>> collection)
    {
      InitializeComponent();
      Statcollection = collection;
    }

    private void FHelpForm_Load(object sender, EventArgs e)
    {
      GraphPane pane = zedGraph.GraphPane;

      // Очистим список кривых
      pane.CurveList.Clear();

      // Количество столбцов в гистограмме
      int itemscount = 5;

      Random rnd = new Random();

      // Высота столбцов
      PointPairList values = new PointPairList();
      // Заполним данные
      foreach(int day in Statcollection.Keys)
      {
        values.Add(day, Statcollection[day].Count);
      }

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
  }
}

