using GMap.NET;
using GMap.NET.MapProviders;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Misson.Views
{
    /// <summary>
    /// GMapCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class GMapCtrl : System.Windows.Controls.UserControl
    {
        public GMapCtrl()
        {
            InitializeComponent();
            mapCtrl1.MapProvider = GMapProviders.GoogleChinaSatelliteMap;
            mapCtrl1.Manager.Mode = AccessMode.ServerAndCache;
            mapCtrl1.Position = new PointLatLng(30.6545, 104.0790);  //中心点的纬度，经度       
            //不显示中心十字点
            mapCtrl1.ShowCenter = false;
            //左键拖拽地图
            mapCtrl1.DragButton = MouseButtons.Left;
            mapCtrl1.MinZoom = 5;   //最小缩放  
            mapCtrl1.MaxZoom = 18;  //最大缩放  
            mapCtrl1.Zoom = 10;      //当前缩放 
        }
    }
}
