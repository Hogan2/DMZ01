using GMap.NET;
using GMap.NET.MapProviders;
using System.Windows.Forms;

namespace Misson.Views
{
    /// <summary>
    /// GMapCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class GMapCtrl : System.Windows.Controls.UserControl
    {
        int tooType = 5;
        bool setHome = false;
        int alt1 = 100;

        private enum ToolType
        {
            toolArrow,
            toolZoomIn,
            toolZoomOut,
            toolMove,
            toolDistance,
            toolCourse,
            toolAutoCourse
        }

        public GMapCtrl()
        {
            InitializeComponent();
            GMapInitialize();
        }
        private void GMapInitialize()
        {
            mapCtrl1.Init(104.0790, 30.6545, 10, 0, 0.0, 0.0);
            mapCtrl1.CacheLocation = @"E:\MapDB";
            mapCtrl1.MapProvider = GMapProviders.GoogleChinaSatelliteMap;
            mapCtrl1.Manager.Mode = AccessMode.ServerAndCache;
            //mapCtrl1.Position = new PointLatLng(30.6545, 104.0790);  //中心点的纬度，经度            
            mapCtrl1.ShowCenter = false;//不显示中心十字点            
            mapCtrl1.DragButton = MouseButtons.Right;//右键拖拽地图
            mapCtrl1.MinZoom = 5;   //最小缩放  
            mapCtrl1.MaxZoom = 18;  //最大缩放  
            //mapCtrl1.Zoom = 10;     //当前缩放

            Init_handles();
        }
        private void Init_handles()
        {
            mapCtrl1.MouseDoubleClick += new MouseEventHandler(this.on_mouse_click);
            mapCtrl1.MouseUp += new MouseEventHandler(this.on_mouse_up);
            mapCtrl1.MouseMove += new MouseEventHandler(this.on_mouse_move);
        }

        private void on_mouse_move(object sender, MouseEventArgs e)
        {
            //此方法有个小bug，未改mapCtrl1.m_markerCurentRect
            //PointLatLng point = mapCtrl1.FromLocalToLatLng(e.X, e.Y);
            //for (int i = 0; i <= mapCtrl1.Course_GetPointCount(); i++)
            //{
            //    if (e.Button == MouseButtons.Left && mapCtrl1.GetWaypointSelected(i))
            //    {
            //        listView1.Items[i].SubItems[1].Text = point.Lng.ToString("0.0000000");
            //        listView1.Items[i].SubItems[2].Text = point.Lat.ToString("0.0000000");
            //        mapCtrl1.TextOverlay_SetCurMarkerPosition(point.Lng, point.Lat);
            //    }
            //}

            //改mapCtrl1.m_markerCurentRect (private --> public)
            PointLatLng point = mapCtrl1.FromLocalToLatLng(e.X, e.Y);
            if (e.Button == MouseButtons.Left && mapCtrl1.GetWaypointSelectedCount() > 0 && tooType == (int)ToolType.toolCourse)
            {
                try
                {
                   
                    mapCtrl1.TextOverlay_SetCurMarkerPosition(point.Lng, point.Lat);
                }
                catch { }
            }
        }

        private void on_mouse_up(object sender, MouseEventArgs e)
        {

        }

        private void on_mouse_click(object sender, MouseEventArgs e)
        {
            PointLatLng point = mapCtrl1.FromLocalToLatLng(e.X, e.Y);
            //point1 = point;

            if (e.Button == MouseButtons.Left)
            {
                if (tooType == 0 && setHome)
                {
                    mapCtrl1.Position = new PointLatLng(point.Lat, point.Lng);
                }
                else if (tooType == (int)ToolType.toolCourse)
                {
                    //++WPnIndex;
                    //WPnIndex1 = mapCtrl1.Course_GetPointCount();
                    mapCtrl1.Course_AddPoint(point.Lng, point.Lat, alt1, mapCtrl1.Course_GetPointCount() + 1);
                }
            }
        }

    }
}
